namespace Rechtschreibpruefung
{
    partial class FormHelp
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
            this.rtbHelp = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBoxHelp = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbHelp
            // 
            this.rtbHelp.Location = new System.Drawing.Point(12, 73);
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.ReadOnly = true;
            this.rtbHelp.Size = new System.Drawing.Size(573, 409);
            this.rtbHelp.TabIndex = 2;
            this.rtbHelp.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(232, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboBoxHelp
            // 
            this.comboBoxHelp.FormattingEnabled = true;
            this.comboBoxHelp.Location = new System.Drawing.Point(12, 25);
            this.comboBoxHelp.Name = "comboBoxHelp";
            this.comboBoxHelp.Size = new System.Drawing.Size(424, 21);
            this.comboBoxHelp.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(460, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 42);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 545);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboBoxHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHelp";
            this.Text = "Hilfe";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboBoxHelp;
        private System.Windows.Forms.Button btnSearch;
    }
}