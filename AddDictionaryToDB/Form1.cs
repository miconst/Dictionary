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
            AddDictionaryToDB(false);
        }

        private void ExecuteNonQuery(MySqlCommand cmd)
        {
            textBox_DatabaseLog.Text += cmd.CommandText + "\r\n";
            cmd.ExecuteNonQuery();
            textBox_DatabaseLog.Text += "Ok.\r\n";
        }

        private object ExecuteScalar(MySqlCommand cmd)
        {
            textBox_DatabaseLog.Text += cmd.CommandText + "\r\n";
            object obj = cmd.ExecuteScalar();
            textBox_DatabaseLog.Text += "Ok.\r\n";
            return obj;
        }

        private bool AddDictionaryToDB(bool replace)
        {
            try
            {
                string query;
                MySqlCommand cmd;
                string table_name = "book_";

                if (replace)
                {
                    DictionaryDBItem it = (DictionaryDBItem)comboBox_DB_Dictionaries.SelectedItem;
                    string name = textBox_DB_DictionaryName.Text;
                    string info = textBox_DB_DictionaryInfo.Text;
                    if (name != it.name || info != it.info)
                    {
                        query = "UPDATE books SET name=@name, info=@info WHERE id=@id";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@info", info);
                        cmd.Parameters.AddWithValue("@id", it.id);

                        ExecuteNonQuery(cmd);

                        it.name = name;
                        it.info = info;
                    }
                    table_name += it.id;

                    query = "TRUNCATE " + table_name;
                    cmd = new MySqlCommand(query, conn);
                    ExecuteNonQuery(cmd);
                }
                else
                {
                    // Insert a new book into books table.
                    query = "INSERT INTO books(id, name, info) VALUES(NULL, @name, @info)";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBox_DB_DictionaryName.Text);
                    cmd.Parameters.AddWithValue("@info", textBox_DB_DictionaryInfo.Text);

                    ExecuteNonQuery(cmd);
                    table_name += cmd.LastInsertedId.ToString();

                    // Create our book table.
                    string word_collation = comboBox_DB_Collation_Word.SelectedItem.ToString();
                    string desc_collation = comboBox_DB_Collation_Desc.SelectedItem.ToString();

                    query = "SELECT CHARACTER_SET_NAME FROM INFORMATION_SCHEMA.COLLATIONS WHERE COLLATION_NAME=@name";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", word_collation);
                    string word_charset = ExecuteScalar(cmd).ToString();
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", desc_collation);
                    string desc_charset = ExecuteScalar(cmd).ToString();

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
                    ExecuteNonQuery(cmd);
                }

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
                            cmd.Parameters.AddWithValue("@word", s);
                        }
                    }
                    if (info != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@info", info);
                        cmd.ExecuteNonQuery();
                        info = string.Empty;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                textBox_DatabaseLog.Text += ex.ToString() + "\r\n";
                return false;
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
                textBox_DatabaseLog.Text += "Openning the conection...\r\n";
                conn.Open();
                textBox_DatabaseLog.Text += "Ok.\r\n";

                textBox_DatabaseLog.Text += "Reading COLLATION_NAME from INFORMATION_SCHEMA.COLLATIONS...\r\n";
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
                textBox_DatabaseLog.Text += "Ok.\r\n";

                comboBox_DB_Collation_Word.SelectedItem = "utf16_unicode_ci";
                comboBox_DB_Collation_Desc.SelectedItem = "utf16_unicode_ci";

                comboBox_DB_Collation_Word.EndUpdate();
                comboBox_DB_Collation_Desc.EndUpdate();

                textBox_DatabaseLog.Text += "Reading from dictionary.books...\r\n";
                query = "SELECT id, name, info FROM books";
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();

                comboBox_DB_Dictionaries.Update();
                comboBox_DB_Dictionaries.Items.Clear();

                while (rdr.Read())
                {
                    comboBox_DB_Dictionaries.Items.Add(new DictionaryDBItem(
                        rdr[0].ToString(),
                        rdr[1].ToString(),
                        rdr[2].ToString())
                    );
                }
                rdr.Close();
                textBox_DatabaseLog.Text += "Ok.\r\n";

                comboBox_DB_Dictionaries.SelectedIndex = 0;
                comboBox_DB_Dictionaries.EndUpdate();
            }
            catch (Exception ex)
            {
                conn = null;
                textBox_DatabaseLog.Text += ex.ToString() + "\r\n";
                ((Control)sender).Enabled = true;
            }
        }

        private void textBox_DB_DictionaryName_TextChanged(object sender, EventArgs e)
        {
            button_DB_Add.Enabled
                 = button_LoadDictionary.Enabled
                && textBox_DB_DictionaryName.Text.Length > 0
                && conn != null
                ;
        }

        private void comboBox_DB_Dictionaries_SelectedIndexChanged(object sender, EventArgs e)
        {
            DictionaryDBItem it = (DictionaryDBItem)comboBox_DB_Dictionaries.SelectedItem;
            textBox_DB_DictionaryName.Text = it.name;
            textBox_DB_DictionaryInfo.Text = it.info;
        }

        private void button_DB_Replace_Click(object sender, EventArgs e)
        {
            AddDictionaryToDB(true);
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

    public class DictionaryDBItem
    {
        public string id;
        public string name;
        public string info;

        public DictionaryDBItem(string id, string name, string info)
        {
            this.id = id;
            this.name = name;
            this.info = info;
        }

        public override string ToString()
        {
            return name;
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
