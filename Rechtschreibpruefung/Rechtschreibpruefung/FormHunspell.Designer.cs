namespace Rechtschreibpruefung
{
    partial class FormHunspell
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
            this.btnReplaceOne = new System.Windows.Forms.Button();
            this.rtbSentence = new System.Windows.Forms.RichTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMistake = new System.Windows.Forms.Label();
            this.labelNummer = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.labelFehleranzahl = new System.Windows.Forms.Label();
            this.lblMistakeCount = new System.Windows.Forms.Label();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnShowIgnore = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSuggest)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVSuggest
            // 
            this.dGVSuggest.AllowUserToDeleteRows = false;
            this.dGVSuggest.AllowUserToOrderColumns = true;
            this.dGVSuggest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSuggest.Location = new System.Drawing.Point(118, 288);
            this.dGVSuggest.MultiSelect = false;
            this.dGVSuggest.Name = "dGVSuggest";
            this.dGVSuggest.Size = new System.Drawing.Size(429, 315);
            this.dGVSuggest.TabIndex = 0;
            // 
            // btnReplaceOne
            // 
            this.btnReplaceOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceOne.Location = new System.Drawing.Point(553, 428);
            this.btnReplaceOne.Name = "btnReplaceOne";
            this.btnReplaceOne.Size = new System.Drawing.Size(123, 62);
            this.btnReplaceOne.TabIndex = 1;
            this.btnReplaceOne.Text = "Eins ersetzen";
            this.btnReplaceOne.UseVisualStyleBackColor = true;
            this.btnReplaceOne.Click += new System.EventHandler(this.btnReplaceOne_Click);
            // 
            // rtbSentence
            // 
            this.rtbSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSentence.Location = new System.Drawing.Point(51, 57);
            this.rtbSentence.Name = "rtbSentence";
            this.rtbSentence.ReadOnly = true;
            this.rtbSentence.Size = new System.Drawing.Size(625, 127);
            this.rtbSentence.TabIndex = 2;
            this.rtbSentence.Text = "";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(113, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(177, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name des Punktes";
            // 
            // lblMistake
            // 
            this.lblMistake.AutoSize = true;
            this.lblMistake.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMistake.Location = new System.Drawing.Point(112, 218);
            this.lblMistake.Name = "lblMistake";
            this.lblMistake.Size = new System.Drawing.Size(91, 31);
            this.lblMistake.TabIndex = 4;
            this.lblMistake.Text = "Fehler";
            // 
            // labelNummer
            // 
            this.labelNummer.AutoSize = true;
            this.labelNummer.Location = new System.Drawing.Point(580, 18);
            this.labelNummer.Name = "labelNummer";
            this.labelNummer.Size = new System.Drawing.Size(46, 13);
            this.labelNummer.TabIndex = 5;
            this.labelNummer.Text = "Nummer";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(634, 18);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(36, 13);
            this.lblNumber.TabIndex = 6;
            this.lblNumber.Text = "00/00";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(256, 609);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(137, 48);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Schließen";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(616, 218);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(93, 64);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Weiter";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 218);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(93, 64);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Zurück";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceAll.Location = new System.Drawing.Point(553, 360);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(123, 62);
            this.btnReplaceAll.TabIndex = 1;
            this.btnReplaceAll.Text = "Alle ersetzen";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // labelFehleranzahl
            // 
            this.labelFehleranzahl.AutoSize = true;
            this.labelFehleranzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFehleranzahl.Location = new System.Drawing.Point(549, 295);
            this.labelFehleranzahl.Name = "labelFehleranzahl";
            this.labelFehleranzahl.Size = new System.Drawing.Size(170, 20);
            this.labelFehleranzahl.TabIndex = 9;
            this.labelFehleranzahl.Text = "Fehlerwiederholungen:";
            // 
            // lblMistakeCount
            // 
            this.lblMistakeCount.AutoSize = true;
            this.lblMistakeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMistakeCount.Location = new System.Drawing.Point(553, 315);
            this.lblMistakeCount.Name = "lblMistakeCount";
            this.lblMistakeCount.Size = new System.Drawing.Size(18, 20);
            this.lblMistakeCount.TabIndex = 9;
            this.lblMistakeCount.Text = "0";
            // 
            // btnIgnore
            // 
            this.btnIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnore.Location = new System.Drawing.Point(553, 514);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(123, 36);
            this.btnIgnore.TabIndex = 1;
            this.btnIgnore.Text = "Ignorieren";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnShowIgnore
            // 
            this.btnShowIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowIgnore.Location = new System.Drawing.Point(553, 556);
            this.btnShowIgnore.Name = "btnShowIgnore";
            this.btnShowIgnore.Size = new System.Drawing.Size(123, 47);
            this.btnShowIgnore.TabIndex = 1;
            this.btnShowIgnore.Text = "Ignorierliste anzeigen";
            this.btnShowIgnore.UseVisualStyleBackColor = true;
            this.btnShowIgnore.Click += new System.EventHandler(this.btnShowIgnore_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(12, 295);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(53, 52);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FormHunspell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 674);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblMistakeCount);
            this.Controls.Add(this.labelFehleranzahl);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.labelNummer);
            this.Controls.Add(this.lblMistake);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.rtbSentence);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnShowIgnore);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnReplaceOne);
            this.Controls.Add(this.dGVSuggest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHunspell";
            this.Text = "FormHunspell";
            ((System.ComponentModel.ISupportInitialize)(this.dGVSuggest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVSuggest;
        private System.Windows.Forms.Button btnReplaceOne;
        private System.Windows.Forms.RichTextBox rtbSentence;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMistake;
        private System.Windows.Forms.Label labelNummer;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Label labelFehleranzahl;
        private System.Windows.Forms.Label lblMistakeCount;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnShowIgnore;
        private System.Windows.Forms.Button btnHelp;
    }
}