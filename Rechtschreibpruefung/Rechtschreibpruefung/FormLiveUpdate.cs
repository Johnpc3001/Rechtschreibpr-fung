using NHunspell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rechtschreibpruefung
{
    public partial class FormLiveUpdate : Form
    {
        static string sDirectory = Directory.GetCurrentDirectory();
        Hunspell hunspell;
        public string sReplace = null;
        public bool bIgnore = false;
        public FormLiveUpdate(string word, Hunspell hunspell)
        {
            InitializeComponent();
            this.hunspell = hunspell;
            List<string> lstSuggest = hunspell.Suggest(word);

            DataGridViewTextBoxColumn txt1 = new DataGridViewTextBoxColumn();
            dGVSuggest.Columns.Add(txt1);
            txt1.Name = "Vorschläge";
            this.dGVSuggest.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (string sug in lstSuggest)
            {
                DataGridViewRow myDataRow = new DataGridViewRow();
                DataGridViewTextBoxCell txtCell1 = new DataGridViewTextBoxCell();
                txtCell1.Value = sug;
                myDataRow.Cells.Add(txtCell1);
                dGVSuggest.Rows.Add(myDataRow);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (dGVSuggest.SelectedCells.Count > 0 && dGVSuggest.CurrentCell.Value != null)
            {
                sReplace = dGVSuggest.CurrentCell.Value.ToString();
            }
            DialogResult = DialogResult.OK;
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            bIgnore = true;
            DialogResult = DialogResult.OK;
        }
    }
}
