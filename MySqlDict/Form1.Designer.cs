namespace MySqlDict
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
            this.textBox_Word = new System.Windows.Forms.TextBox();
            this.webBrowser_Desc = new System.Windows.Forms.WebBrowser();
            this.button_Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Word
            // 
            this.textBox_Word.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Word.Location = new System.Drawing.Point(13, 13);
            this.textBox_Word.Name = "textBox_Word";
            this.textBox_Word.Size = new System.Drawing.Size(678, 20);
            this.textBox_Word.TabIndex = 0;
            // 
            // webBrowser_Desc
            // 
            this.webBrowser_Desc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser_Desc.Location = new System.Drawing.Point(13, 40);
            this.webBrowser_Desc.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Desc.Name = "webBrowser_Desc";
            this.webBrowser_Desc.Size = new System.Drawing.Size(759, 390);
            this.webBrowser_Desc.TabIndex = 1;
            // 
            // button_Search
            // 
            this.button_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Search.Location = new System.Drawing.Point(697, 13);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = "&Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.webBrowser_Desc);
            this.Controls.Add(this.textBox_Word);
            this.Name = "Form_Main";
            this.Text = "MySql Dictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Word;
        private System.Windows.Forms.WebBrowser webBrowser_Desc;
        private System.Windows.Forms.Button button_Search;
    }
}

