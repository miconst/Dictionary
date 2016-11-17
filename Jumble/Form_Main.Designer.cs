namespace Jumble
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
            this.button_NextWord = new System.Windows.Forms.Button();
            this.panel_Puzzle = new System.Windows.Forms.Panel();
            this.label_Guess = new System.Windows.Forms.Label();
            this.textBox_Answer = new System.Windows.Forms.TextBox();
            this.Help = new System.Windows.Forms.Button();
            this.button_OpenWordFile = new System.Windows.Forms.Button();
            this.openWordFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_NextWord
            // 
            this.button_NextWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_NextWord.Location = new System.Drawing.Point(493, 449);
            this.button_NextWord.Name = "button_NextWord";
            this.button_NextWord.Size = new System.Drawing.Size(75, 23);
            this.button_NextWord.TabIndex = 0;
            this.button_NextWord.Text = "&Next";
            this.button_NextWord.UseVisualStyleBackColor = true;
            this.button_NextWord.Click += new System.EventHandler(this.button_NextWord_Click);
            // 
            // panel_Puzzle
            // 
            this.panel_Puzzle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Puzzle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Puzzle.Location = new System.Drawing.Point(13, 13);
            this.panel_Puzzle.Name = "panel_Puzzle";
            this.panel_Puzzle.Size = new System.Drawing.Size(555, 208);
            this.panel_Puzzle.TabIndex = 1;
            this.panel_Puzzle.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Puzzle_Paint);
            this.panel_Puzzle.DoubleClick += new System.EventHandler(this.panel_Puzzle_DoubleClick);
            this.panel_Puzzle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Puzzle_MouseDown);
            this.panel_Puzzle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Puzzle_MouseMove);
            this.panel_Puzzle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Puzzle_MouseUp);
            // 
            // label_Guess
            // 
            this.label_Guess.AutoSize = true;
            this.label_Guess.Location = new System.Drawing.Point(12, 224);
            this.label_Guess.Name = "label_Guess";
            this.label_Guess.Size = new System.Drawing.Size(63, 13);
            this.label_Guess.TabIndex = 2;
            this.label_Guess.Text = "GuessLabel";
            this.label_Guess.TextChanged += new System.EventHandler(this.label_Guess_TextChanged);
            // 
            // textBox_Answer
            // 
            this.textBox_Answer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Answer.Location = new System.Drawing.Point(13, 240);
            this.textBox_Answer.Multiline = true;
            this.textBox_Answer.Name = "textBox_Answer";
            this.textBox_Answer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Answer.Size = new System.Drawing.Size(555, 203);
            this.textBox_Answer.TabIndex = 0;
            // 
            // Help
            // 
            this.Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Help.Location = new System.Drawing.Point(412, 449);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(75, 23);
            this.Help.TabIndex = 3;
            this.Help.Text = "&Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // button_OpenWordFile
            // 
            this.button_OpenWordFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_OpenWordFile.Location = new System.Drawing.Point(12, 449);
            this.button_OpenWordFile.Name = "button_OpenWordFile";
            this.button_OpenWordFile.Size = new System.Drawing.Size(75, 23);
            this.button_OpenWordFile.TabIndex = 4;
            this.button_OpenWordFile.Text = "&Open...";
            this.button_OpenWordFile.UseVisualStyleBackColor = true;
            this.button_OpenWordFile.Click += new System.EventHandler(this.button_OpenWordFile_Click);
            // 
            // openWordFileDialog
            // 
            this.openWordFileDialog.DefaultExt = "txt";
            this.openWordFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 484);
            this.Controls.Add(this.button_OpenWordFile);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.textBox_Answer);
            this.Controls.Add(this.label_Guess);
            this.Controls.Add(this.panel_Puzzle);
            this.Controls.Add(this.button_NextWord);
            this.Name = "Form_Main";
            this.Text = "Word Jumble";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_NextWord;
        private System.Windows.Forms.Panel panel_Puzzle;
        private System.Windows.Forms.Label label_Guess;
        private System.Windows.Forms.TextBox textBox_Answer;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button button_OpenWordFile;
        private System.Windows.Forms.OpenFileDialog openWordFileDialog;
    }
}

