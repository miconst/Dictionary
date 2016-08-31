namespace MakeGetRequest
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
            this.listBox_Words = new System.Windows.Forms.ListBox();
            this.textBox_Output = new System.Windows.Forms.TextBox();
            this.listBox_Urls = new System.Windows.Forms.ListBox();
            this.button_Play = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.textBox_Word = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox_Words
            // 
            this.listBox_Words.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_Words.FormattingEnabled = true;
            this.listBox_Words.Location = new System.Drawing.Point(12, 38);
            this.listBox_Words.Name = "listBox_Words";
            this.listBox_Words.Size = new System.Drawing.Size(172, 329);
            this.listBox_Words.Sorted = true;
            this.listBox_Words.TabIndex = 0;
            this.listBox_Words.SelectedIndexChanged += new System.EventHandler(this.listBox_Words_SelectedIndexChanged);
            // 
            // textBox_Output
            // 
            this.textBox_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Output.Location = new System.Drawing.Point(191, 12);
            this.textBox_Output.Multiline = true;
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.Size = new System.Drawing.Size(781, 178);
            this.textBox_Output.TabIndex = 1;
            // 
            // listBox_Urls
            // 
            this.listBox_Urls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Urls.FormattingEnabled = true;
            this.listBox_Urls.Location = new System.Drawing.Point(191, 195);
            this.listBox_Urls.Name = "listBox_Urls";
            this.listBox_Urls.Size = new System.Drawing.Size(781, 147);
            this.listBox_Urls.Sorted = true;
            this.listBox_Urls.TabIndex = 2;
            // 
            // button_Play
            // 
            this.button_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Play.Location = new System.Drawing.Point(191, 343);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(75, 23);
            this.button_Play.TabIndex = 3;
            this.button_Play.Text = "&Play";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Save.Location = new System.Drawing.Point(272, 343);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "&Save As";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // textBox_Word
            // 
            this.textBox_Word.Location = new System.Drawing.Point(12, 12);
            this.textBox_Word.Name = "textBox_Word";
            this.textBox_Word.Size = new System.Drawing.Size(172, 20);
            this.textBox_Word.TabIndex = 5;
            this.textBox_Word.TextChanged += new System.EventHandler(this.textBox_Word_TextChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 380);
            this.Controls.Add(this.textBox_Word);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Play);
            this.Controls.Add(this.listBox_Urls);
            this.Controls.Add(this.textBox_Output);
            this.Controls.Add(this.listBox_Words);
            this.Name = "Form_Main";
            this.Text = "Make A Get Request";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Words;
        private System.Windows.Forms.TextBox textBox_Output;
        private System.Windows.Forms.ListBox listBox_Urls;
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox textBox_Word;
    }
}

