using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rechtschreibpruefung
{
    public delegate void replaceIgnoreList(List<string> list);
    public partial class FormIgnoreList : Form
    {
        public replaceIgnoreList repIgnLst;
        private List<string> lstIgnore = new List<string>();
        public FormIgnoreList(List<string> lst)
        {
            lstIgnore = new List<string>(lst);
            InitializeComponent();
            fillGrid();
        }

        private void fillGrid()
        {
            dgvIgnore.Rows.Clear();
            dgvIgnore.Columns.Clear();

            DataGridViewTextBoxColumn txt1 = new DataGridViewTextBoxColumn();
            dgvIgnore.Columns.Add(txt1);
            txt1.Name = "Ignorierte Wörter";
            this.dgvIgnore.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (string word in lstIgnore)
            {
                DataGridViewRow myDataRow = new DataGridViewRow();
                DataGridViewTextBoxCell txtCell1 = new DataGridViewTextBoxCell();
                txtCell1.Value = word;
                myDataRow.Cells.Add(txtCell1);
                dgvIgnore.Rows.Add(myDataRow);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                lstIgnore.Add(textBox1.Text);
                repIgnLst(lstIgnore);
                fillGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvIgnore.SelectedCells.Count > 0)
            {
                lstIgnore.RemoveAt(dgvIgnore.CurrentCell.RowIndex);
                repIgnLst(lstIgnore);
                fillGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
