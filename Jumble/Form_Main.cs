using System;
using System.Configuration;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

#if DEBUG
using MySql.Data;
using MySql.Data.MySqlClient;
#endif

namespace Jumble
{
    public partial class Form_Main : Form
    {
        List<string> wordsList = new List<string>();
        List<string> answersList = new List<string>();
        Random random = new Random();
        //List<PuzzleTile> tiles = new List<PuzzleTile>();
        string puzzle = string.Empty;
        string answer = string.Empty;

        //bool isMouseDown = false;
        int mouseX = 0;
        int mouseY = 0;
        Control selectedTile = null;

        public Form_Main()
        {
            InitializeComponent();
        }

        public void SaveWordlist(string fname)
        {
            using (StreamWriter writer = new StreamWriter(fname))
            {
                char[] sep = new char[] { '\r', '\n' };
                for (int i = 0; i < wordsList.Count; i++)
                {
                    writer.WriteLine(wordsList[i]);
                    foreach(string s in answersList[i].Split(sep, StringSplitOptions.RemoveEmptyEntries))
                    {
                        writer.WriteLine("\t" + s);
                    }
                }
            }
        }

        public void LoadWordlist(string fname)
        {
            using (StreamReader reader = new StreamReader(fname))
            {
                string word = string.Empty;
                string answer = string.Empty;
                for(string s; (s = reader.ReadLine()) != null;)
                {
                    if (s.StartsWith("\t"))
                    {
                        answer += s.Trim() + "\r\n";
                    }
                    else
                    {
                        if(word.Length > 0)
                        {
                            wordsList.Add(word);
                            answersList.Add(answer);
                        }
                        word = s.Trim();
                        answer = string.Empty;
                    }
                }
                if (word.Length > 0)
                {
                    wordsList.Add(word);
                    answersList.Add(answer);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Read settings.
            var appSettings = ConfigurationManager.AppSettings;
#if DEBUG
            try
            {
                string connStr = string.Format(
                    "server={0};user={1};database={2};port=3306;password={3};charset=utf8;",
                    Properties.Settings.Default.DB_HOST,
                    Properties.Settings.Default.DB_USER,
                    Properties.Settings.Default.DB_NAME,
                    Properties.Settings.Default.DB_PASS
                );

                // Create a connection object.
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "SELECT word,definition FROM wordlist WHERE user=@user_name";
                var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user_name", Properties.Settings.Default.DB_USER);

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    wordsList.Add(rdr.GetString(0));
                    answersList.Add(rdr.GetString(1));
                }
                rdr.Close();

                conn.Close();
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SaveWordlist(Properties.Settings.Default.DB_USER + ".txt");
#endif // DEBUG

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //e.Graphics.DrawString(puzzle, Font, Brushes.Black, 10, 10);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        private void button_NextWord_Click(object sender, EventArgs e)
        {
            if (wordsList.Count > 0)
            {
                int next = random.Next(0, wordsList.Count);
                answer = answersList[next];
                SetWord(wordsList[next]);
                ShuffleTiles();
            }
        }

        void SetWord(string word)
        {
            puzzle = word;

            selectedTile = null;
            panel_Puzzle.Controls.Clear();
            
            foreach(char ch in word)
            {
                PuzzleTile t = new PuzzleTile("" + ch);
                t.Size = new Size(32, 32);
                t.Parent = panel_Puzzle;
            }

            panel_Puzzle.Invalidate();
        }

        void ShuffleTiles()
        {
            selectedTile = null;

            int cx = panel_Puzzle.ClientSize.Width - 32;
            int cy = panel_Puzzle.ClientSize.Height - 32;

            foreach(Control t in panel_Puzzle.Controls)
            {
                t.Location = new Point(random.Next(cx), random.Next(cy));
            }
            for(int i = 0; i < panel_Puzzle.Controls.Count; i++)
            {
                panel_Puzzle.Controls[random.Next(panel_Puzzle.Controls.Count)].BringToFront();
            }
            panel_Puzzle_OnChange();
        }

        private void panel_Puzzle_MouseDown(object sender, MouseEventArgs e)
        {
            selectedTile = null;
            Rectangle rc = new Rectangle();
            foreach (Control t in panel_Puzzle.Controls)
            {
                rc.Location = t.Location;
                rc.Size = t.Size;
                if (rc.Contains(e.X, e.Y))
                {
                    mouseX = e.X;
                    mouseY = e.Y;
                    selectedTile = t;
                    selectedTile.BringToFront();
                    break;
                }
            }
        }

        private void panel_Puzzle_MouseUp(object sender, MouseEventArgs e)
        {
            if(selectedTile != null)
            {
                if(Control.ModifierKeys == Keys.Control)
                {
                    panel_Puzzle_DoubleClick(sender, e);
                }
                else
                {
                    Rectangle rc = new Rectangle(0, 0, 32 * puzzle.Length, 32);
                    int x = selectedTile.Location.X + selectedTile.Size.Width / 2;
                    int y = selectedTile.Location.Y + selectedTile.Size.Height / 2;
                    if (rc.Contains(x, y))
                    {
                        int n = x / 32;
                        x = 32 * n;
                        y = 0;

                        if(panel_Puzzle_GetTileAt(x, y) == null)
                        {
                            selectedTile.Location = new Point(x, y);
                        }
                    }

                    selectedTile = null;
                    panel_Puzzle_OnChange();
                }
            }
        }

        private void panel_Puzzle_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedTile != null && (e.X != mouseX || e.Y != mouseY))
            {
                int x = selectedTile.Location.X + e.X - mouseX;
                int y = selectedTile.Location.Y + e.Y - mouseY;
                if(x < 0)
                {
                    x = 0;
                }
                if (x > panel_Puzzle.Size.Width - 32)
                {
                    x = panel_Puzzle.Size.Width - 32;
                }
                if (y < 0)
                {
                    y = 0;
                }
                if (y > panel_Puzzle.Size.Height - 32)
                {
                    y = panel_Puzzle.Size.Height - 32;
                }

                selectedTile.Location = new Point(x, y);
                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        private void panel_Puzzle_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, 32, 32);
            for(int i = 0; i < puzzle.Length; i++)
            {
                rc.X = i * 32;
                e.Graphics.DrawRectangle(Pens.Black, rc);
            }
        }

        private Control panel_Puzzle_GetTileAt(int x, int y)
        {
            foreach(Control c in panel_Puzzle.Controls)
            {
                if(c.Location.X == x && c.Location.Y == y)
                {
                    return c;
                }
            }
            return null;
        }

        private void panel_Puzzle_OnChange()
        {
            string guess = string.Empty;
            for(int i = 0; i < puzzle.Length; i++)
            {
                Control c = panel_Puzzle_GetTileAt(i * 32, 0);
                if(c != null)
                {
                    guess += c.Text;
                }
                else
                {
                    break;
                }
            }
            label_Guess.Text = guess;
        }

        private void label_Guess_TextChanged(object sender, EventArgs e)
        {
            if(label_Guess.Text == puzzle)
            {
                textBox_Answer.Text = "Yes!\r\n\r\n" + answer;
            }
            else
            {
                textBox_Answer.Text = string.Empty;
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            textBox_Answer.Text = answer;
        }

        private void panel_Puzzle_DoubleClick(object sender, EventArgs e)
        {
            if (selectedTile != null)
            {
                // Get it into a first free cell.
                for (int i = 0; i < puzzle.Length; i++)
                {
                    Control c = panel_Puzzle_GetTileAt(i * 32, 0);
                    if (c == null)
                    {
                        selectedTile.Location = new Point(i * 32, 0);
                        selectedTile = null;
                        panel_Puzzle_OnChange();
                        break;
                    }
                }
                selectedTile = null;
            }
        }

        private void button_OpenWordFile_Click(object sender, EventArgs e)
        {
            if(openWordFileDialog.ShowDialog() == DialogResult.OK)
            {
                wordsList.Clear();
                answersList.Clear();
                LoadWordlist(openWordFileDialog.FileName);
            }
        }
    }

    class PuzzleTile : UserControl
    {
        public PuzzleTile(string name)
        {
            Text = name;
            Enabled = false; // no keyboard events to the tile
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var g = e.Graphics;

            g.Clear(SystemColors.Control);

            var cx = Size.Width;
            var cy = Size.Height;
            var wx = SystemInformation.FrameBorderSize.Width;
            var wy = SystemInformation.FrameBorderSize.Height;

            var pts = new Point[]
            {
                new Point(0,  cy), new Point(0, 0),
                new Point(cx,  0), new Point(cx - wx, wy),
                new Point(wx, wy), new Point(wx, cy - wy),
            };
            g.FillPolygon(SystemBrushes.ControlLightLight, pts);

            pts = new Point[]
            {
                new Point(cx, 0), new Point(cx, cy),
                new Point(0, cy), new Point(wx, cy - wy),
                new Point(cx - wx, cy - wy), new Point(cx- wx, wy),
            };
            g.FillPolygon(SystemBrushes.ControlDark, pts);

            var f = new Font("Arial", 24);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, f, SystemBrushes.ControlText, ClientRectangle, sf);
        }
    }
}
