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
using NHunspell;

namespace Rechtschreibpruefung
{
    public partial class formCorrect : Form
    {
        public List<string> list;
        int nNumber;
        public formCorrect(List<string> lstMistakes)
        {
            InitializeComponent();
            list = new List<string>(lstMistakes);
            nNumber = 0;
            if(list.Count > 0)
            {
                loadWord(nNumber);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            nNumber++;
            loadWord(nNumber);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            nNumber--;
            loadWord(nNumber);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (dGVSuggest.CurrentCell.Value != null)
                list[nNumber] = dGVSuggest.CurrentCell.Value.ToString();
            loadWord(nNumber);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void loadWord(int number)
        {
            btnReplace.Enabled = false;
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            if (number == 0)
                btnBack.Enabled = false;
            if (number == list.Count - 1)
                btnNext.Enabled = false;

            lblMistake.Text = list[number];
            fillDataGrid(list[number]);
        }

        private void fillDataGrid(string word)
        {
            dGVSuggest.Rows.Clear();
            dGVSuggest.Columns.Clear();
            string sDirectory = Directory.GetCurrentDirectory();
            using (Hunspell hunspell = new Hunspell(sDirectory + @"\de_DE_frami.aff",
                                             sDirectory + @"\de_DE_frami.dic"))
            {
                List<string> lstSuggest = hunspell.Suggest(word);
                if (lstSuggest.Count > 0)
                    btnReplace.Enabled = true;

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
        }
    }
}
