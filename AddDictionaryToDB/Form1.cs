using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace AddDictionaryToDB
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();

            comboBox_DictionaryEncoding.BeginUpdate();
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                var li = new EncodingListItem(ei.GetEncoding());
                comboBox_DictionaryEncoding.Items.Add(li);
                if (li.e.Equals(Encoding.UTF8))
                {
                    comboBox_DictionaryEncoding.SelectedItem = li;
                }
            }
            comboBox_DictionaryEncoding.EndUpdate();
        }

        private void button_OpenDictionary_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Dictionary.ShowDialog() == DialogResult.OK)
            {
                textBox_DictionaryPath.Text = openFileDialog_Dictionary.FileName;
            }
        }

        private void button_LoadDictionary_Click(object sender, EventArgs e)
        {
            Encoding enc = ((EncodingListItem)comboBox_DictionaryEncoding.SelectedItem).e;

            using (var sm = new StreamReader(textBox_DictionaryPath.Text, enc))
            {
                button_LoadDictionary.Enabled = false;
                comboBox_DictionaryWords.BeginUpdate();

                DictionaryFileItem fi = null;
                List<string> entry = new List<string>();

                while (!sm.EndOfStream)
                {
                    string s = sm.ReadLine();
                    if (s.StartsWith("\t"))
                    {
                        entry.Add(s.Substring(1));
                    }
                    else
                    {
                        if (fi != null)
                        {
                            fi.entry = entry.ToArray();
                            entry.Clear();
                        }
                        fi = new DictionaryFileItem(s, null);
                        comboBox_DictionaryWords.Items.Add(fi);
                    }
                }

                if (fi != null)
                {
                    fi.entry = entry.ToArray();
                    entry.Clear();
                }

                comboBox_DictionaryWords.EndUpdate();
                button_LoadDictionary.Enabled = true;

            }
        }

        private void textBox_DictionaryPath_TextChanged(object sender, EventArgs e)
        {
            button_LoadDictionary.Enabled = File.Exists(textBox_DictionaryPath.Text);
        }

        private void comboBox_DictionaryWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            DictionaryFileItem fi = (DictionaryFileItem)comboBox_DictionaryWords.SelectedItem;
            textBox_DictionaryEntry.Lines = fi.entry;
        }

        private void button_AddToDB_Click(object sender, EventArgs e)
        {
            ////////////////////////////
            string DB_HOST = "localhost";
            string DB_NAME = "dictionary"; //"publications";
            string DB_USER = "test_user";
            string DB_PASS = "12345670";

            string connStr = string.Format("server={0};user={1};database={2};port=3306;password={3};charset=utf8;",
                DB_HOST, DB_USER, DB_NAME, DB_PASS);

            // Create a connection object.
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Open the connection.
                conn.Open();

                Encoding enc = ((EncodingListItem)comboBox_DictionaryEncoding.SelectedItem).e;

                using (var sm = new StreamReader(textBox_DictionaryPath.Text, enc))
                {
                    button_LoadDictionary.Enabled = false;
                    button_AddToDB.Enabled = false;

                    MySqlCommand cmd = null;
                    string query = "INSERT INTO words(auto, word, info, book) VALUES(NULL, @word, @info, '5')";
                    string info = string.Empty;

                    while (!sm.EndOfStream)
                    {
                        string s = sm.ReadLine();
                        if (s.StartsWith("\t"))
                        {
                            info += s.Substring(1) + "\n";
                        }
                        else
                        {
                            if (info != string.Empty)
                            {
                                // Perform database operations here.
                                //info = MySql.Data.MySqlClient.MySqlHelper.EscapeString(info);
                                cmd.Parameters.AddWithValue("@info", info);
                                cmd.ExecuteNonQuery();
                                info = string.Empty;
                            }
                            cmd = new MySqlCommand(query, conn);
                            //MySql.Data.MySqlClient.MySqlHelper.EscapeString(s);
                            cmd.Parameters.AddWithValue("@word", s);
                        }
                    }
                    if (info != string.Empty)
                    {
                        //info = MySql.Data.MySqlClient.MySqlHelper.EscapeString(info);
                        cmd.Parameters.AddWithValue("@info", info);
                        cmd.ExecuteNonQuery();
                        info = string.Empty;
                    }

                    button_LoadDictionary.Enabled = true;
                    button_AddToDB.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // Close the connection to the database.
            conn.Close();

        }
    }

    public class DictionaryFileItem
    {
        public string word;
        public string[] entry;

        public DictionaryFileItem(string word, string[] entry)
        {
            this.word = word;
            this.entry = entry;
        }

        public override string ToString()
        {
            return word;
        }
    }

    public class EncodingListItem
    {
        public Encoding e;
        public override string ToString()
        {
            return e.EncodingName;
        }

        public EncodingListItem(Encoding e)
        {
            this.e = e;
        }
    }

}
