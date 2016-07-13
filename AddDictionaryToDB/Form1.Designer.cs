namespace AddDictionaryToDB
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog_Dictionary = new System.Windows.Forms.OpenFileDialog();
            this.label_DictionaryPath = new System.Windows.Forms.Label();
            this.textBox_DictionaryPath = new System.Windows.Forms.TextBox();
            this.button_OpenDictionary = new System.Windows.Forms.Button();
            this.button_LoadDictionary = new System.Windows.Forms.Button();
            this.groupBox_Dictionary = new System.Windows.Forms.GroupBox();
            this.textBox_DictionaryEntry = new System.Windows.Forms.TextBox();
            this.groupBox_Database = new System.Windows.Forms.GroupBox();
            this.comboBox_DB_Dictionaries = new System.Windows.Forms.ComboBox();
            this.button_DB_Replace = new System.Windows.Forms.Button();
            this.groupBox_DB_Collation = new System.Windows.Forms.GroupBox();
            this.comboBox_DB_Collation_Desc = new System.Windows.Forms.ComboBox();
            this.comboBox_DB_Collation_Word = new System.Windows.Forms.ComboBox();
            this.label__DB_Collation_Desc = new System.Windows.Forms.Label();
            this.label__DB_Collation_Word = new System.Windows.Forms.Label();
            this.textBox_DB_DictionaryInfo = new System.Windows.Forms.TextBox();
            this.label_DB_DictionaryInfo = new System.Windows.Forms.Label();
            this.textBox_DatabaseLog = new System.Windows.Forms.TextBox();
            this.textBox_DB_DictionaryName = new System.Windows.Forms.TextBox();
            this.button_DB_Add = new System.Windows.Forms.Button();
            this.label_DB_DictionaryName = new System.Windows.Forms.Label();
            this.button_ConnectToDB = new System.Windows.Forms.Button();
            this.comboBox_DictionaryWords = new System.Windows.Forms.ComboBox();
            this.comboBox_DictionaryEncoding = new System.Windows.Forms.ComboBox();
            this.label_DictionaryEncoding = new System.Windows.Forms.Label();
            this.groupBox_Dictionary.SuspendLayout();
            this.groupBox_Database.SuspendLayout();
            this.groupBox_DB_Collation.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog_Dictionary
            // 
            this.openFileDialog_Dictionary.Filter = "Text files|*.txt|All files|*.*";
            // 
            // label_DictionaryPath
            // 
            this.label_DictionaryPath.AutoSize = true;
            this.label_DictionaryPath.Location = new System.Drawing.Point(6, 22);
            this.label_DictionaryPath.Name = "label_DictionaryPath";
            this.label_DictionaryPath.Size = new System.Drawing.Size(32, 13);
            this.label_DictionaryPath.TabIndex = 0;
            this.label_DictionaryPath.Text = "&Path:";
            // 
            // textBox_DictionaryPath
            // 
            this.textBox_DictionaryPath.Location = new System.Drawing.Point(44, 15);
            this.textBox_DictionaryPath.Name = "textBox_DictionaryPath";
            this.textBox_DictionaryPath.Size = new System.Drawing.Size(335, 20);
            this.textBox_DictionaryPath.TabIndex = 1;
            this.textBox_DictionaryPath.TextChanged += new System.EventHandler(this.textBox_DictionaryPath_TextChanged);
            // 
            // button_OpenDictionary
            // 
            this.button_OpenDictionary.Location = new System.Drawing.Point(385, 12);
            this.button_OpenDictionary.Name = "button_OpenDictionary";
            this.button_OpenDictionary.Size = new System.Drawing.Size(75, 23);
            this.button_OpenDictionary.TabIndex = 2;
            this.button_OpenDictionary.Text = "&Open...";
            this.button_OpenDictionary.UseVisualStyleBackColor = true;
            this.button_OpenDictionary.Click += new System.EventHandler(this.button_OpenDictionary_Click);
            // 
            // button_LoadDictionary
            // 
            this.button_LoadDictionary.Enabled = false;
            this.button_LoadDictionary.Location = new System.Drawing.Point(385, 42);
            this.button_LoadDictionary.Name = "button_LoadDictionary";
            this.button_LoadDictionary.Size = new System.Drawing.Size(75, 23);
            this.button_LoadDictionary.TabIndex = 3;
            this.button_LoadDictionary.Text = "Pre&view";
            this.button_LoadDictionary.UseVisualStyleBackColor = true;
            this.button_LoadDictionary.Click += new System.EventHandler(this.button_LoadDictionary_Click);
            // 
            // groupBox_Dictionary
            // 
            this.groupBox_Dictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Dictionary.Controls.Add(this.textBox_DictionaryEntry);
            this.groupBox_Dictionary.Controls.Add(this.groupBox_Database);
            this.groupBox_Dictionary.Controls.Add(this.comboBox_DictionaryWords);
            this.groupBox_Dictionary.Controls.Add(this.button_LoadDictionary);
            this.groupBox_Dictionary.Controls.Add(this.comboBox_DictionaryEncoding);
            this.groupBox_Dictionary.Controls.Add(this.label_DictionaryEncoding);
            this.groupBox_Dictionary.Controls.Add(this.label_DictionaryPath);
            this.groupBox_Dictionary.Controls.Add(this.button_OpenDictionary);
            this.groupBox_Dictionary.Controls.Add(this.textBox_DictionaryPath);
            this.groupBox_Dictionary.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Dictionary.Name = "groupBox_Dictionary";
            this.groupBox_Dictionary.Size = new System.Drawing.Size(1044, 282);
            this.groupBox_Dictionary.TabIndex = 4;
            this.groupBox_Dictionary.TabStop = false;
            this.groupBox_Dictionary.Text = "Dictionary";
            // 
            // textBox_DictionaryEntry
            // 
            this.textBox_DictionaryEntry.Location = new System.Drawing.Point(6, 108);
            this.textBox_DictionaryEntry.Multiline = true;
            this.textBox_DictionaryEntry.Name = "textBox_DictionaryEntry";
            this.textBox_DictionaryEntry.Size = new System.Drawing.Size(454, 168);
            this.textBox_DictionaryEntry.TabIndex = 6;
            // 
            // groupBox_Database
            // 
            this.groupBox_Database.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Database.Controls.Add(this.comboBox_DB_Dictionaries);
            this.groupBox_Database.Controls.Add(this.button_DB_Replace);
            this.groupBox_Database.Controls.Add(this.groupBox_DB_Collation);
            this.groupBox_Database.Controls.Add(this.textBox_DB_DictionaryInfo);
            this.groupBox_Database.Controls.Add(this.label_DB_DictionaryInfo);
            this.groupBox_Database.Controls.Add(this.textBox_DatabaseLog);
            this.groupBox_Database.Controls.Add(this.textBox_DB_DictionaryName);
            this.groupBox_Database.Controls.Add(this.button_DB_Add);
            this.groupBox_Database.Controls.Add(this.label_DB_DictionaryName);
            this.groupBox_Database.Controls.Add(this.button_ConnectToDB);
            this.groupBox_Database.Location = new System.Drawing.Point(466, 0);
            this.groupBox_Database.Name = "groupBox_Database";
            this.groupBox_Database.Size = new System.Drawing.Size(572, 276);
            this.groupBox_Database.TabIndex = 6;
            this.groupBox_Database.TabStop = false;
            this.groupBox_Database.Text = "Database";
            // 
            // comboBox_DB_Dictionaries
            // 
            this.comboBox_DB_Dictionaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DB_Dictionaries.FormattingEnabled = true;
            this.comboBox_DB_Dictionaries.Location = new System.Drawing.Point(9, 40);
            this.comboBox_DB_Dictionaries.Name = "comboBox_DB_Dictionaries";
            this.comboBox_DB_Dictionaries.Size = new System.Drawing.Size(169, 21);
            this.comboBox_DB_Dictionaries.TabIndex = 8;
            this.comboBox_DB_Dictionaries.SelectedIndexChanged += new System.EventHandler(this.comboBox_DB_Dictionaries_SelectedIndexChanged);
            // 
            // button_DB_Replace
            // 
            this.button_DB_Replace.Location = new System.Drawing.Point(494, 42);
            this.button_DB_Replace.Name = "button_DB_Replace";
            this.button_DB_Replace.Size = new System.Drawing.Size(75, 23);
            this.button_DB_Replace.TabIndex = 7;
            this.button_DB_Replace.Text = "&Replace";
            this.button_DB_Replace.UseVisualStyleBackColor = true;
            this.button_DB_Replace.Click += new System.EventHandler(this.button_DB_Replace_Click);
            // 
            // groupBox_DB_Collation
            // 
            this.groupBox_DB_Collation.Controls.Add(this.comboBox_DB_Collation_Desc);
            this.groupBox_DB_Collation.Controls.Add(this.comboBox_DB_Collation_Word);
            this.groupBox_DB_Collation.Controls.Add(this.label__DB_Collation_Desc);
            this.groupBox_DB_Collation.Controls.Add(this.label__DB_Collation_Word);
            this.groupBox_DB_Collation.Location = new System.Drawing.Point(0, 64);
            this.groupBox_DB_Collation.Name = "groupBox_DB_Collation";
            this.groupBox_DB_Collation.Size = new System.Drawing.Size(237, 105);
            this.groupBox_DB_Collation.TabIndex = 6;
            this.groupBox_DB_Collation.TabStop = false;
            this.groupBox_DB_Collation.Text = "Collation";
            // 
            // comboBox_DB_Collation_Desc
            // 
            this.comboBox_DB_Collation_Desc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DB_Collation_Desc.FormattingEnabled = true;
            this.comboBox_DB_Collation_Desc.Location = new System.Drawing.Point(75, 46);
            this.comboBox_DB_Collation_Desc.Name = "comboBox_DB_Collation_Desc";
            this.comboBox_DB_Collation_Desc.Size = new System.Drawing.Size(156, 21);
            this.comboBox_DB_Collation_Desc.TabIndex = 3;
            // 
            // comboBox_DB_Collation_Word
            // 
            this.comboBox_DB_Collation_Word.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DB_Collation_Word.FormattingEnabled = true;
            this.comboBox_DB_Collation_Word.Location = new System.Drawing.Point(75, 19);
            this.comboBox_DB_Collation_Word.Name = "comboBox_DB_Collation_Word";
            this.comboBox_DB_Collation_Word.Size = new System.Drawing.Size(156, 21);
            this.comboBox_DB_Collation_Word.TabIndex = 2;
            // 
            // label__DB_Collation_Desc
            // 
            this.label__DB_Collation_Desc.AutoSize = true;
            this.label__DB_Collation_Desc.Location = new System.Drawing.Point(6, 49);
            this.label__DB_Collation_Desc.Name = "label__DB_Collation_Desc";
            this.label__DB_Collation_Desc.Size = new System.Drawing.Size(63, 13);
            this.label__DB_Collation_Desc.TabIndex = 1;
            this.label__DB_Collation_Desc.Text = "Description:";
            // 
            // label__DB_Collation_Word
            // 
            this.label__DB_Collation_Word.AutoSize = true;
            this.label__DB_Collation_Word.Location = new System.Drawing.Point(6, 27);
            this.label__DB_Collation_Word.Name = "label__DB_Collation_Word";
            this.label__DB_Collation_Word.Size = new System.Drawing.Size(36, 13);
            this.label__DB_Collation_Word.TabIndex = 0;
            this.label__DB_Collation_Word.Text = "Word:";
            // 
            // textBox_DB_DictionaryInfo
            // 
            this.textBox_DB_DictionaryInfo.Location = new System.Drawing.Point(243, 40);
            this.textBox_DB_DictionaryInfo.Multiline = true;
            this.textBox_DB_DictionaryInfo.Name = "textBox_DB_DictionaryInfo";
            this.textBox_DB_DictionaryInfo.Size = new System.Drawing.Size(244, 129);
            this.textBox_DB_DictionaryInfo.TabIndex = 5;
            // 
            // label_DB_DictionaryInfo
            // 
            this.label_DB_DictionaryInfo.AutoSize = true;
            this.label_DB_DictionaryInfo.Location = new System.Drawing.Point(184, 47);
            this.label_DB_DictionaryInfo.Name = "label_DB_DictionaryInfo";
            this.label_DB_DictionaryInfo.Size = new System.Drawing.Size(62, 13);
            this.label_DB_DictionaryInfo.TabIndex = 3;
            this.label_DB_DictionaryInfo.Text = "Information:";
            // 
            // textBox_DatabaseLog
            // 
            this.textBox_DatabaseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_DatabaseLog.Location = new System.Drawing.Point(6, 175);
            this.textBox_DatabaseLog.Multiline = true;
            this.textBox_DatabaseLog.Name = "textBox_DatabaseLog";
            this.textBox_DatabaseLog.ReadOnly = true;
            this.textBox_DatabaseLog.Size = new System.Drawing.Size(560, 95);
            this.textBox_DatabaseLog.TabIndex = 1;
            // 
            // textBox_DB_DictionaryName
            // 
            this.textBox_DB_DictionaryName.Location = new System.Drawing.Point(243, 14);
            this.textBox_DB_DictionaryName.Name = "textBox_DB_DictionaryName";
            this.textBox_DB_DictionaryName.Size = new System.Drawing.Size(244, 20);
            this.textBox_DB_DictionaryName.TabIndex = 4;
            this.textBox_DB_DictionaryName.TextChanged += new System.EventHandler(this.textBox_DB_DictionaryName_TextChanged);
            // 
            // button_DB_Add
            // 
            this.button_DB_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DB_Add.Enabled = false;
            this.button_DB_Add.Location = new System.Drawing.Point(493, 11);
            this.button_DB_Add.Name = "button_DB_Add";
            this.button_DB_Add.Size = new System.Drawing.Size(75, 23);
            this.button_DB_Add.TabIndex = 5;
            this.button_DB_Add.Text = "&Add";
            this.button_DB_Add.UseVisualStyleBackColor = true;
            this.button_DB_Add.Click += new System.EventHandler(this.button_AddToDB_Click);
            // 
            // label_DB_DictionaryName
            // 
            this.label_DB_DictionaryName.AutoSize = true;
            this.label_DB_DictionaryName.Location = new System.Drawing.Point(184, 21);
            this.label_DB_DictionaryName.Name = "label_DB_DictionaryName";
            this.label_DB_DictionaryName.Size = new System.Drawing.Size(38, 13);
            this.label_DB_DictionaryName.TabIndex = 2;
            this.label_DB_DictionaryName.Text = "&Name:";
            // 
            // button_ConnectToDB
            // 
            this.button_ConnectToDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ConnectToDB.Location = new System.Drawing.Point(6, 12);
            this.button_ConnectToDB.Name = "button_ConnectToDB";
            this.button_ConnectToDB.Size = new System.Drawing.Size(75, 23);
            this.button_ConnectToDB.TabIndex = 0;
            this.button_ConnectToDB.Text = "&Connect";
            this.button_ConnectToDB.UseVisualStyleBackColor = true;
            this.button_ConnectToDB.Click += new System.EventHandler(this.button_ConnectToDB_Click);
            // 
            // comboBox_DictionaryWords
            // 
            this.comboBox_DictionaryWords.FormattingEnabled = true;
            this.comboBox_DictionaryWords.Location = new System.Drawing.Point(6, 81);
            this.comboBox_DictionaryWords.Name = "comboBox_DictionaryWords";
            this.comboBox_DictionaryWords.Size = new System.Drawing.Size(454, 21);
            this.comboBox_DictionaryWords.TabIndex = 5;
            this.comboBox_DictionaryWords.SelectedIndexChanged += new System.EventHandler(this.comboBox_DictionaryWords_SelectedIndexChanged);
            // 
            // comboBox_DictionaryEncoding
            // 
            this.comboBox_DictionaryEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DictionaryEncoding.FormattingEnabled = true;
            this.comboBox_DictionaryEncoding.Location = new System.Drawing.Point(71, 44);
            this.comboBox_DictionaryEncoding.Name = "comboBox_DictionaryEncoding";
            this.comboBox_DictionaryEncoding.Size = new System.Drawing.Size(308, 21);
            this.comboBox_DictionaryEncoding.Sorted = true;
            this.comboBox_DictionaryEncoding.TabIndex = 4;
            // 
            // label_DictionaryEncoding
            // 
            this.label_DictionaryEncoding.AutoSize = true;
            this.label_DictionaryEncoding.Location = new System.Drawing.Point(6, 52);
            this.label_DictionaryEncoding.Name = "label_DictionaryEncoding";
            this.label_DictionaryEncoding.Size = new System.Drawing.Size(55, 13);
            this.label_DictionaryEncoding.TabIndex = 3;
            this.label_DictionaryEncoding.Text = "&Encoding:";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 301);
            this.Controls.Add(this.groupBox_Dictionary);
            this.Name = "Form_Main";
            this.Text = "Add dictionary to database";
            this.groupBox_Dictionary.ResumeLayout(false);
            this.groupBox_Dictionary.PerformLayout();
            this.groupBox_Database.ResumeLayout(false);
            this.groupBox_Database.PerformLayout();
            this.groupBox_DB_Collation.ResumeLayout(false);
            this.groupBox_DB_Collation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_Dictionary;
        private System.Windows.Forms.Label label_DictionaryPath;
        private System.Windows.Forms.TextBox textBox_DictionaryPath;
        private System.Windows.Forms.Button button_OpenDictionary;
        private System.Windows.Forms.Button button_LoadDictionary;
        private System.Windows.Forms.GroupBox groupBox_Dictionary;
        private System.Windows.Forms.ComboBox comboBox_DictionaryEncoding;
        private System.Windows.Forms.Label label_DictionaryEncoding;
        private System.Windows.Forms.ComboBox comboBox_DictionaryWords;
        private System.Windows.Forms.TextBox textBox_DictionaryEntry;
        private System.Windows.Forms.Button button_DB_Add;
        private System.Windows.Forms.GroupBox groupBox_Database;
        private System.Windows.Forms.TextBox textBox_DatabaseLog;
        private System.Windows.Forms.Button button_ConnectToDB;
        private System.Windows.Forms.GroupBox groupBox_DB_Collation;
        private System.Windows.Forms.TextBox textBox_DB_DictionaryInfo;
        private System.Windows.Forms.Label label_DB_DictionaryInfo;
        private System.Windows.Forms.TextBox textBox_DB_DictionaryName;
        private System.Windows.Forms.Label label_DB_DictionaryName;
        private System.Windows.Forms.ComboBox comboBox_DB_Collation_Desc;
        private System.Windows.Forms.ComboBox comboBox_DB_Collation_Word;
        private System.Windows.Forms.Label label__DB_Collation_Desc;
        private System.Windows.Forms.Label label__DB_Collation_Word;
        private System.Windows.Forms.Button button_DB_Replace;
        private System.Windows.Forms.ComboBox comboBox_DB_Dictionaries;
    }
}

