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
            this.comboBox_DictionaryWords = new System.Windows.Forms.ComboBox();
            this.comboBox_DictionaryEncoding = new System.Windows.Forms.ComboBox();
            this.label_DictionaryEncoding = new System.Windows.Forms.Label();
            this.groupBox_Dictionary.SuspendLayout();
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
            this.textBox_DictionaryPath.Location = new System.Drawing.Point(44, 18);
            this.textBox_DictionaryPath.Name = "textBox_DictionaryPath";
            this.textBox_DictionaryPath.Size = new System.Drawing.Size(207, 20);
            this.textBox_DictionaryPath.TabIndex = 1;
            this.textBox_DictionaryPath.TextChanged += new System.EventHandler(this.textBox_DictionaryPath_TextChanged);
            // 
            // button_OpenDictionary
            // 
            this.button_OpenDictionary.Location = new System.Drawing.Point(257, 17);
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
            this.button_LoadDictionary.Location = new System.Drawing.Point(257, 47);
            this.button_LoadDictionary.Name = "button_LoadDictionary";
            this.button_LoadDictionary.Size = new System.Drawing.Size(75, 23);
            this.button_LoadDictionary.TabIndex = 3;
            this.button_LoadDictionary.Text = "&Load";
            this.button_LoadDictionary.UseVisualStyleBackColor = true;
            this.button_LoadDictionary.Click += new System.EventHandler(this.button_LoadDictionary_Click);
            // 
            // groupBox_Dictionary
            // 
            this.groupBox_Dictionary.Controls.Add(this.textBox_DictionaryEntry);
            this.groupBox_Dictionary.Controls.Add(this.comboBox_DictionaryWords);
            this.groupBox_Dictionary.Controls.Add(this.button_LoadDictionary);
            this.groupBox_Dictionary.Controls.Add(this.comboBox_DictionaryEncoding);
            this.groupBox_Dictionary.Controls.Add(this.label_DictionaryEncoding);
            this.groupBox_Dictionary.Controls.Add(this.label_DictionaryPath);
            this.groupBox_Dictionary.Controls.Add(this.button_OpenDictionary);
            this.groupBox_Dictionary.Controls.Add(this.textBox_DictionaryPath);
            this.groupBox_Dictionary.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Dictionary.Name = "groupBox_Dictionary";
            this.groupBox_Dictionary.Size = new System.Drawing.Size(476, 282);
            this.groupBox_Dictionary.TabIndex = 4;
            this.groupBox_Dictionary.TabStop = false;
            this.groupBox_Dictionary.Text = "Dictionary";
            // 
            // textBox_DictionaryEntry
            // 
            this.textBox_DictionaryEntry.Location = new System.Drawing.Point(9, 108);
            this.textBox_DictionaryEntry.Multiline = true;
            this.textBox_DictionaryEntry.Name = "textBox_DictionaryEntry";
            this.textBox_DictionaryEntry.Size = new System.Drawing.Size(461, 168);
            this.textBox_DictionaryEntry.TabIndex = 6;
            // 
            // comboBox_DictionaryWords
            // 
            this.comboBox_DictionaryWords.FormattingEnabled = true;
            this.comboBox_DictionaryWords.Location = new System.Drawing.Point(44, 81);
            this.comboBox_DictionaryWords.Name = "comboBox_DictionaryWords";
            this.comboBox_DictionaryWords.Size = new System.Drawing.Size(207, 21);
            this.comboBox_DictionaryWords.TabIndex = 5;
            this.comboBox_DictionaryWords.SelectedIndexChanged += new System.EventHandler(this.comboBox_DictionaryWords_SelectedIndexChanged);
            // 
            // comboBox_DictionaryEncoding
            // 
            this.comboBox_DictionaryEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DictionaryEncoding.FormattingEnabled = true;
            this.comboBox_DictionaryEncoding.Location = new System.Drawing.Point(71, 48);
            this.comboBox_DictionaryEncoding.Name = "comboBox_DictionaryEncoding";
            this.comboBox_DictionaryEncoding.Size = new System.Drawing.Size(180, 21);
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
            this.ClientSize = new System.Drawing.Size(500, 316);
            this.Controls.Add(this.groupBox_Dictionary);
            this.Name = "Form_Main";
            this.Text = "Add dictionary to database";
            this.groupBox_Dictionary.ResumeLayout(false);
            this.groupBox_Dictionary.PerformLayout();
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
    }
}

