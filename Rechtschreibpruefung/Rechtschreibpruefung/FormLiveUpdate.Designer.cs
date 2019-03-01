namespace Rechtschreibpruefung
{
    partial class FormLiveUpdate
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
            this.dGVSuggest = new System.Windows.Forms.DataGridView();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSuggest)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVSuggest
            // 
            this.dGVSuggest.AllowUserToAddRows = false;
            this.dGVSuggest.AllowUserToDeleteRows = false;
            this.dGVSuggest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSuggest.Location = new System.Drawing.Point(1, 1);
            this.dGVSuggest.Name = "dGVSuggest";
            this.dGVSuggest.ReadOnly = true;
            this.dGVSuggest.Size = new System.Drawing.Size(266, 260);
            this.dGVSuggest.TabIndex = 0;
            this.dGVSuggest.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnReplace_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(1, 267);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(85, 35);
            this.btnReplace.TabIndex = 1;
            this.btnReplace.Text = "Ersetzen";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(182, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Abbrechen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(92, 267);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(85, 35);
            this.btnIgnore.TabIndex = 2;
            this.btnIgnore.Text = "Ignorieren";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // FormLiveUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 308);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.dGVSuggest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLiveUpdate";
            this.Text = "FormLiveUpdate";
            ((System.ComponentModel.ISupportInitialize)(this.dGVSuggest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVSuggest;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIgnore;
    }
}