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
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            comboBoxHelp.DisplayMember = "Name";
            comboBoxHelp.ValueMember = "Text";
            ComboItem c1 = new ComboItem()
            {
                Name = "Der richtige Vorschlag wird nicht angezeigt.",
                Text = "Wenn der richtige Vorschlag fehlt, kann er selbst eingetragen werden.\r\n" +
                "Dazu muss nur das letzte und leere Feld in der Liste per Doppelklick ausgewählt werden.\r\n" +
                "Dann kann dort frei geschrieben werden und dann der entsprechende Knopf zum ersetzen gewählt werden."
            };
            comboBoxHelp.Items.Add(c1);
            ComboItem c2 = new ComboItem()
            {
                Name = "Warum sehe ich mein korrigiertes Wort noch?",
                Text = "Falls bei der Korrektur ein Fehler unterlaufen ist, kann das im Nachhinein noch geändert werden."
            };
            comboBoxHelp.Items.Add(c2);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(comboBoxHelp.SelectedItem != null)
            {
                rtbHelp.Text = ((ComboItem)comboBoxHelp.SelectedItem).Text;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
    public class ComboItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
