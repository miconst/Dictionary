using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace MakeGetRequest
{
    public partial class Form_Main : Form
    {
        WMPLib.WindowsMediaPlayer Player;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string sURL;
            //sURL = @"http://dictionary.cambridge.org/dictionary/english/apropos";

           // WebRequest wrGETURL;
            //wrGETURL = WebRequest.Create(sURL);

            //WebProxy myProxy = new WebProxy("myproxy", 80);
            //myProxy.BypassProxyOnLocal = true;

            //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            //Stream objStream;
            //objStream = wrGETURL.GetResponse().GetResponseStream();

           // StreamReader objReader = new StreamReader(objStream);

            //string strResponse = objReader.ReadToEnd();

            //string sLine = "";
            //int i = 0;

            //while (sLine != null)
            //{
            //    i++;
            //    sLine = objReader.ReadLine();
            //    if (sLine != null)
            //        Console.WriteLine("{0}:{1}", i, sLine);
            //}
            //Console.ReadLine();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange += Player_PlayStateChange;
            Player.MediaError += Player_MediaError;

            string DB_HOST = "localhost";
            string DB_NAME = "dictionary";
            string DB_USER = "test_user";
            string DB_PASS = "12345670";

            string connStr = string.Format("server={0};user={1};database={2};port=3306;password={3};charset=utf8;",
                DB_HOST, DB_USER, DB_NAME, DB_PASS);

            // Create a connection object.
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = "SELECT word FROM wordlist WHERE mark > '2016-08-26 00:00:00' AND user='" + DB_USER + "'";

            MySqlDataReader rdr = (new MySqlCommand(query, conn)).ExecuteReader();
            while (rdr.Read())
            {
                listBox_Words.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            conn.Close();
        }

        private void Player_MediaError(object pMediaObject)
        {
            Log("MediaPlayer", pMediaObject.ToString());
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                button_Play.Enabled = true;
            }
        }

        private void Log(string subject, string message)
        {
            textBox_Output.Text += "[" + subject + "] ";
            textBox_Output.Text += message + "\r\n";
        }

        private void listBox_Words_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Word.Text = listBox_Words.SelectedItem.ToString();
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            string url = listBox_Urls.SelectedItem.ToString();
            string fname = Path.GetFileName(url);

            if (!File.Exists(fname))
            {
                using (var wc = new WebClient())
                {
                    wc.DownloadFile(url, fname);
                }
            }

            if (File.Exists(fname) && Path.GetExtension(fname).ToLower() != ".ogg")
            {
                Player.URL = fname;

                button_Play.Enabled = false;
                Player.controls.play();
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string url = listBox_Urls.SelectedItem.ToString();
            string fname = Path.GetFileName(url);
            string ext = Path.GetExtension(fname);
            string word = textBox_Word.Text; //listBox_Words.SelectedItem.ToString();

            if (!File.Exists(fname))
            {
                using (var wc = new WebClient())
                {
                    wc.DownloadFile(url, fname);
                }
            }

            if (File.Exists(fname))
            {
                
                string country = "us";
                if (url.Contains("uk_pron"))
                {
                    country = "gb";
                }

                saveFileDialog.FileName = word + "." + country + ext;
                saveFileDialog.Filter = "Files|*" + ext;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(fname, saveFileDialog.FileName, true);
                }
            }
        }

        private void textBox_Word_TextChanged(object sender, EventArgs e)
        {
            string word = textBox_Word.Text;
            if(word.Length <= 0)
            {
                return;
            }

            textBox_Output.Text = "";
            listBox_Urls.Items.Clear();

            string url = @"http://dictionary.cambridge.org/dictionary/english/" + word;

            WebRequest wr = WebRequest.Create(url);

            Log("url", url);
            try
            {
                Stream sm = wr.GetResponse().GetResponseStream();

                string response = (new StreamReader(sm)).ReadToEnd();

                string pattern = @"(?<=data\-src\-mp3\=)\""([^\""]*)\""";
                foreach (Match match in Regex.Matches(response, pattern))
                {
                    string s = match.Groups[1].Value;
                    Log("Match", match.Groups[1].Value);

                    if (!listBox_Urls.Items.Contains(s))
                    {
                        listBox_Urls.Items.Add(s);
                    }
                }

                pattern = @"(?<=data\-src\-ogg\=)\""([^\""]*)\""";
                foreach (Match match in Regex.Matches(response, pattern))
                {
                    string s = match.Groups[1].Value;
                    Log("Match", match.Groups[1].Value);

                    if (!listBox_Urls.Items.Contains(s))
                    {
                        listBox_Urls.Items.Add(s);
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                Log("error", ex.Message);
            }
        }
    }
}
