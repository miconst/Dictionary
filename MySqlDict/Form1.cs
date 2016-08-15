using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySqlDict
{
    public partial class Form_Main : Form
    {
        MySqlConnection conn;
        Dictionary<uint, List<Keyword>> keywords;

        public Form_Main()
        {
            InitializeComponent();
        }

        void LoadKeywords()
        {
            keywords = new Dictionary<uint, List<Keyword>>();

            string query = "SELECT dict_id, pcre_pattern, opening_tag, closing_tag FROM keywords;";

            MySqlDataReader rdr = (new MySqlCommand(query, conn)).ExecuteReader();
            while (rdr.Read())
            {
                uint dict_id;
                if (UInt32.TryParse(rdr[0].ToString(), out dict_id))
                {
                    if (!keywords.ContainsKey(dict_id))
                    {
                        keywords[dict_id] = new List<Keyword>();
                    }

                    keywords[dict_id].Add(new Keyword(rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString()));
                }
            }
            rdr.Close();
        }

        List<Keyword> LoadKeywords(uint dict_id)
        {
            List<Keyword> kwl = new List<Keyword>();

            string query = "SELECT pcre_pattern, opening_tag, closing_tag FROM keywords_" + dict_id + " ORDER BY id ASC;";

            MySqlDataReader rdr = (new MySqlCommand(query, conn)).ExecuteReader();
            while (rdr.Read())
            {
                kwl.Add(new Keyword(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
            }
            rdr.Close();

            return kwl;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string DB_HOST = "localhost";
            string DB_NAME = "dictionary";
            string DB_USER = "test_user";
            string DB_PASS = "12345670";

            string connStr = string.Format("server={0};user={1};database={2};port=3306;password={3};charset=utf8;",
                DB_HOST, DB_USER, DB_NAME, DB_PASS);

            // Create a connection object.
            conn = new MySqlConnection(connStr);
            conn.Open();

            //LoadKeywords();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            //LoadKeywords();

            var books = new Dictionary<uint, List<uint>>();

            var title = new XElement("title");
            title.SetValue("Find the defininition of words");

            var meta = new XElement("meta");
            meta.SetAttributeValue("http-equiv", "Content-Type");
            meta.SetAttributeValue("content", "text/html;charset=utf-8");

            var style = new XElement("style", style_str);

            var head = new XElement("head", title, meta, style);
            var body = new XElement("body");

            var html = new XElement("html", head, body);

            string word = textBox_Word.Text;
            // TODO: word validation.

            string query = "SELECT dict_id, word_id FROM words WHERE word LIKE '" + word + "';";

            MySqlDataReader rdr = (new MySqlCommand(query, conn)).ExecuteReader();
            while (rdr.Read())
            {
                uint dict_id, word_id;
                if (UInt32.TryParse(rdr[0].ToString(), out dict_id) && UInt32.TryParse(rdr[1].ToString(), out word_id))
                {
                    if (!books.ContainsKey(dict_id)) {
                        books[dict_id] = new List<uint>();
                    }
                    books[dict_id].Add(word_id);
                }
            }
            rdr.Close();

            foreach(KeyValuePair<uint, List<uint>> entry in books)
            {
                var div = new XElement("div");
                div.SetAttributeValue("class", "book_name");
                div.SetAttributeValue("id", "book_" + entry.Key);
                div.SetValue(entry.Key);

                var dl = new XElement("dl");
                dl.SetAttributeValue("class", "word_dl");
                dl.SetAttributeValue("id", "word_dl_" + entry.Key);

                var kwl = LoadKeywords(entry.Key);

                foreach(uint word_id in entry.Value)
                {
                    query = "SELECT word, definition FROM book_" + entry.Key + " WHERE id='" + word_id + "';";
                    rdr = (new MySqlCommand(query, conn)).ExecuteReader();
                    while (rdr.Read())
                    {
                        string wd = rdr[0].ToString();
                        string dn = rdr[1].ToString();

                        var dt = new XElement("dt");
                        dt.SetAttributeValue("class", "word_dt");
                        dt.SetAttributeValue("id", "dt_" + entry.Key + "_" + word_id);
                        dt.SetValue(wd);
                        dl.Add(dt);

                        //foreach(string dis in getDefinitionItems(dn))
                        // break the text into definition items
                        foreach (string dis in Regex.Split(dn, @"(?<=\n)(?=[^\t])"))
                        {
                            var dd_text = new XText(dis);
                            var dd = new XElement("dd", dd_text);

                            string pattern = @"^\t[^\n]*$";
                            XElement label = null;
                            foreach (Match match in Regex.Matches(dis, pattern, RegexOptions.Multiline))
                            {
                                var bq = new XElement("blockquote", new XText(match.Value));

                                if(label == null)
                                {
                                    var input = new XElement("input");
                                    input.SetAttributeValue("class", "hidden");
                                    input.SetAttributeValue("type", "checkbox");
                                    var p_plus = new XElement("p");
                                    p_plus.SetAttributeValue("class", "plus unchecked");
                                    //p_plus.Add("&plusb;");
                                    var p_minus = new XElement("p");
                                    p_minus.SetAttributeValue("class", "minus checked");
                                    //p_minus.Add("&minusb;");

                                    label = new XElement("label", input, p_plus, p_minus);

                                    dd.Add(label);
                                    
                                }
                                label.Add(bq);

                                if(dd_text.Value.Length > match.Index)
                                {
                                    dd_text.Value = dd_text.Value.Substring(0, match.Index);
                                }
                            }

                            dl.Add(dd);

                            AddAbbreviation(dd, wd);

                            /*if (keywords.ContainsKey(entry.Key))*/
                            {
                                foreach(Keyword kw in kwl/*keywords[entry.Key]*/)
                                {
                                    //AddKeyword(dd, kw);
                                    XTextUpdater.ForEachXTextNode(dd, kw.XTextUpdate);
                                }
                            }

                        }
                        
                    }
                    rdr.Close();
                }

                body.Add(div);
                body.Add(dl);
            }

            XDocument doc = new XDocument(
                new XDocumentType("html", null, null, null)
                );
            doc.Add(html);

            webBrowser_Desc.DocumentText = doc.ToString();
        }

        public static void AddAbbreviation(XElement tree, string word)
        {
            for (XNode node = tree.FirstNode; node != null; node = node.NextNode)
            {
                if (node is XText)
                {
                    XText xtext = (XText)node;
                    int startIndex = 0;

                    string input = xtext.Value;
                    string pattern = @"([^\s~]*)~([^\s~]*)";
                    foreach (Match match in Regex.Matches(input, pattern))
                    {
                        string result = match.Groups[1].Value + word + match.Groups[2].Value;

                        xtext.Value = xtext.Value.Substring(0, match.Index - startIndex);
                        var mark = new XElement("b", new XText(result));
                        xtext.AddAfterSelf(mark);

                        startIndex = match.Index + match.Length;
                        xtext = new XText(input.Substring(startIndex));
                        mark.AddAfterSelf(xtext);

                        node = xtext;
                    }
                }
                else if (node is XElement)
                {
                    AddAbbreviation((XElement)node, word);
                }
            }
        }

        public static void AddKeyword(XElement tree, Keyword keyword)
        {
            for (XNode node = tree.FirstNode; node != null; node = node.NextNode)
            {
                if (node is XText)
                {
                    XText xtext = (XText)node;
                    int startIndex = 0;

                    string input = xtext.Value;
                    foreach (Match match in Regex.Matches(input, keyword.pattern))
                    {
                        string result = match.Value;

                        xtext.Value = xtext.Value.Substring(0, match.Index - startIndex);
                       
                        var tag = new XElement(keyword.tag); // Create a clone.
                        tag.Add(new XText(result));
                        xtext.AddAfterSelf(tag);

                        startIndex = match.Index + match.Length;
                        xtext = new XText(input.Substring(startIndex));
                        tag.AddAfterSelf(xtext);

                        node = xtext;
                    }
                }
                else if (node is XElement)
                {
                    AddKeyword((XElement)node, keyword);
                }
            }
        }

        // break the text into definition items
        public static IEnumerable<string> getDefinitionItems(string text)
        {
            int startIndex = 0;
            string pattern = @"\n[^\t]";
            foreach (Match match in Regex.Matches(text, pattern))
            {
                yield return text.Substring(startIndex, match.Index - startIndex);
                startIndex = match.Index + 1;
            }
            yield return text.Substring(startIndex);
        }

        public static IEnumerable<string> getExamples(string text)
        {
            string pattern = @"^\t[^\n]*$";
            foreach (Match match in Regex.Matches(text, pattern, RegexOptions.Multiline))
            {
                yield return match.Value;
            }
        }

        public static string style_str =
@"

label {
  border : 1px solid grey;
  border-radius: 6px; cursor: pointer;
  background-color: #f0f0f0; display: block;
  width: 60%;
  transition:
    box-shadow 1s ease-in-out,
    background-color 1s ease-in-out;
  margin-bottom: 4px;
  margin-left: 1em;
}

abbr {
  border-bottom: 1px dotted navy;
  color: navy;
  text-transform: lowercase;
  font-weight: bold;
  /*font-variant: small-caps;*/
}

label:hover {
  background-color: aliceblue;
  box-shadow:
    0 2px 4px 0 rgba(0, 0, 0, 0.2),
    0 3px 10px 0 rgba(0, 0, 0, 0.19);
}

input ~ p.unchecked {
  display:inline;
}

input:checked ~ p.unchecked {
  display:none;
}

input ~ .checked {
  display:none;
}

input:checked ~ p.checked {
  display:inline;
}

input:checked ~ blockquote.checked {
  display:block;
}

input.hidden {
  display:none;
}

p.checked, p.unchecked {
  margin-bottom:0;
}

blockquote {
  margin: 0 1em;
}

blockquote:last-child {
  margin-bottom:0.5em;
}

.parentheses {
  color: blue;
  font-weight: normal;
}

.square_brackets {
  color: blueviolet;
  font-weight: bold;
}

.abbreviation {
  color: darkblue;
}

"; 
    }

    public class Keyword
    {
        public string pattern;
        public XElement tag;

        public Keyword(string pattern, string opening_tag, string closing_tag)
        {
            this.pattern = pattern;
            this.tag = XElement.Parse(opening_tag + closing_tag);
        }

        public XNode XTextUpdate(XText node)
        {
            string input = node.Value;
            int startIndex = 0;

            foreach (Match match in Regex.Matches(input, pattern))
            {
                string result = match.Value;

                node.Value = node.Value.Substring(0, match.Index - startIndex);

                var tag = new XElement(this.tag); // Create a clone.
                tag.Add(new XText(result));
                node.AddAfterSelf(tag);

                if(node.Value.Trim().Length == 0)
                {
                    node.Remove();
                }

                startIndex = match.Index + match.Length;
                node = new XText(input.Substring(startIndex));
                tag.AddAfterSelf(node);
            }
            return node;
        }
    }

    public class XTextUpdater
    {
        public delegate XNode XTextUpdate(XText node);

        public static void ForEachXTextNode(XElement tree, XTextUpdate update)
        {
            for (XNode node = tree.FirstNode; node != null; node = node.NextNode)
            {
                if (node is XText)
                {
                    node = update((XText)node);
                }
                else if (node is XElement)
                {
                    ForEachXTextNode((XElement)node, update);
                }
            }
        }
    }
  
}
