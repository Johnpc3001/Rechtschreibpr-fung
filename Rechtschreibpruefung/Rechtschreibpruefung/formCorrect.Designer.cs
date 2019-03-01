namespace Rechtschreibpruefung
{
    partial class formCorrect
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
            this.lblMistake = new System.Windows.Forms.Label();
            this.dGVSuggest = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSuggest)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMistake
            // 
            this.lblMistake.AutoSize = true;
            this.lblMistake.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMistake.Location = new System.Drawing.Point(77, 42);
            this.lblMistake.Name = "lblMistake";
            this.lblMistake.Size = new System.Drawing.Size(230, 31);
            this.lblMistake.TabIndex = 0;
            this.lblMistake.Text = "Fehlerhaftes Wort";
            // 
            // dGVSuggest
            // 
            this.dGVSuggest.AllowUserToDeleteRows = false;
            this.dGVSuggest.AllowUserToOrderColumns = true;
            this.dGVSuggest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSuggest.Location = new System.Drawing.Point(12, 108);
            this.dGVSuggest.Name = "dGVSuggest";
            this.dGVSuggest.Size = new System.Drawing.Size(387, 330);
            this.dGVSuggest.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(406, 108);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(147, 41);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Nächstes Wort";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(405, 155);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(147, 41);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Zurück";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(405, 249);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(147, 41);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Ersetzen";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(405, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(405, 397);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(147, 41);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // formCorrect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 450);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dGVSuggest);
            this.Controls.Add(this.lblMistake);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formCorrect";
            this.Text = "formCorrect";
            ((System.ComponentModel.ISupportInitialize)(this.dGVSuggest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMistake;
        private System.Windows.Forms.DataGridView dGVSuggest;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}