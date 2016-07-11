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
        MySqlConnection conn;

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
                comboBox_DictionaryWords.Items.Clear();

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
                            fi = null;

                            if (comboBox_DictionaryWords.Items.Count >= 100)
                            {
                                break;
                            }
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
                comboBox_DictionaryWords.SelectedIndex = 0;
                button_LoadDictionary.Enabled = true;

            }
        }

        private void textBox_DictionaryPath_TextChanged(object sender, EventArgs e)
        {
            button_LoadDictionary.Enabled = File.Exists(textBox_DictionaryPath.Text);
            textBox_DB_DictionaryName_TextChanged(sender, e);
        }

        private void comboBox_DictionaryWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            DictionaryFileItem fi = (DictionaryFileItem)comboBox_DictionaryWords.SelectedItem;
            textBox_DictionaryEntry.Lines = fi.entry;
        }

        private void button_AddToDB_Click(object sender, EventArgs e)
        {
            try
            {
                // Insert a new book into books table.
                string query = "INSERT INTO books(id, name, info) VALUES(NULL, @name, @info)";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", textBox_DB_DictionaryName.Text);
                cmd.Parameters.AddWithValue("@info", textBox_DB_DictionaryInfo.Text);
                cmd.ExecuteNonQuery();
                string table_name = "book_" + cmd.LastInsertedId.ToString();

                // Create our book table.
                string word_collation = comboBox_DB_Collation_Word.SelectedItem.ToString();
                string desc_collation = comboBox_DB_Collation_Desc.SelectedItem.ToString();

                query = "SELECT CHARACTER_SET_NAME FROM INFORMATION_SCHEMA.COLLATIONS WHERE COLLATION_NAME=@name";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", word_collation);
                string word_charset = cmd.ExecuteScalar().ToString();
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", desc_collation);
                string desc_charset = cmd.ExecuteScalar().ToString();

                query = string.Format(
                    "CREATE TABLE {0}(id INT NULL AUTO_INCREMENT,"
                    + "word VARCHAR(128) CHARACTER SET {1} COLLATE {2} NOT NULL,"
                    + "definition TEXT CHARACTER SET {3} COLLATE {4} NOT NULL,"
                    + "PRIMARY KEY(id), INDEX(word)) ENGINE = MyISAM",
                    table_name,
                    word_charset, word_collation,
                    desc_charset, desc_collation
                    );
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                // Fill it in.
                query = "INSERT INTO " + table_name + "(id, word, definition) VALUES(NULL, @word, @info)";
                Encoding enc = ((EncodingListItem)comboBox_DictionaryEncoding.SelectedItem).e;
                using (var sm = new StreamReader(textBox_DictionaryPath.Text, enc))
                {
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
                }
            }
            catch (Exception ex)
            {
                textBox_DatabaseLog.Text = ex.ToString();
            }
        }

        private void button_ConnectToDB_Click(object sender, EventArgs e)
        {
            ((Control)sender).Enabled = false;

            ////////////////////////////
            string DB_HOST = "localhost";
            string DB_NAME = "dictionary";
            string DB_USER = "test_user";
            string DB_PASS = "12345670";

            string connStr = string.Format("server={0};user={1};database={2};port=3306;password={3};charset=utf8;",
                DB_HOST, DB_USER, DB_NAME, DB_PASS);

            // Create a connection object.
            conn = new MySqlConnection(connStr);
            try
            {
                // Open the connection.
                conn.Open();

                string query = "SELECT DISTINCT COLLATION_NAME FROM INFORMATION_SCHEMA.COLLATIONS ORDER BY COLLATION_NAME";
                var cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                comboBox_DB_Collation_Word.Update();
                comboBox_DB_Collation_Word.Items.Clear();
                comboBox_DB_Collation_Desc.Update();
                comboBox_DB_Collation_Desc.Items.Clear();

                while (rdr.Read())
                {
                    comboBox_DB_Collation_Word.Items.Add(rdr[0]);
                    comboBox_DB_Collation_Desc.Items.Add(rdr[0]);
                }
                rdr.Close();

                comboBox_DB_Collation_Word.SelectedItem = "utf16_unicode_ci";
                comboBox_DB_Collation_Desc.SelectedItem = "utf16_unicode_ci";

                comboBox_DB_Collation_Word.EndUpdate();
                comboBox_DB_Collation_Desc.EndUpdate();

            }
            catch (Exception ex)
            {
                conn = null;
                textBox_DatabaseLog.Text = ex.ToString();
                ((Control)sender).Enabled = true;
            }
        }

        private void textBox_DB_DictionaryName_TextChanged(object sender, EventArgs e)
        {
            button_AddToDB.Enabled
                 = button_LoadDictionary.Enabled
                && textBox_DB_DictionaryName.Text.Length > 0
                && conn != null
                ;
        }

        private void label_DB_DictionaryName_Click(object sender, EventArgs e)
        {

        }

        private void label_DB_DictionaryInfo_Click(object sender, EventArgs e)
        {

        }

        private void textBox_DB_DictionaryInfo_TextChanged(object sender, EventArgs e)
        {

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
