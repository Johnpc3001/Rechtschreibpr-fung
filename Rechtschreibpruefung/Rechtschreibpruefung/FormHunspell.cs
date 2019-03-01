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
    //Bekommt den Namen des Textfeldes zur Zuordnung und dessen veränderten Text übergeben.
    public delegate void replaceText(string name, string txt);
    //Bekommt die komplette, überarbeitete Liste mit zu ignorierenden Wörtern übergeben.
    public delegate void replaceList(List<string> list);
    public partial class FormHunspell : Form
    {
        //Delegate Objekte
        public replaceText repText;
        public replaceList repList;
        //Eine lokale Kopie der übergebenen Liste mit Texten und Überschriften. 
        private List<HunspellTexte> lstTexte;
        private int MistakesCounter;
        private List<string> lstFehler = new List<string>();
        private List<string> lstIgnoreMistakes = new List<string>();
        private int nMistakeID;
        private List<int> lstCorrectedMistakes = new List<int>();
        static string sDirectory = Directory.GetCurrentDirectory();
        Hunspell hunspell = new Hunspell(sDirectory + @"\de_DE_frami.aff",
                                         sDirectory + @"\de_DE_frami.dic");

        //Erwartet eine Liste von Objekten der Klasse HunspellTexte, diese beinhalten Namen und Inhalt diverser Textfelder.
        //Optional kann eine personalisierte Liste mit zu ignorierenden Wörtern übergeben werden.
        public FormHunspell(List<HunspellTexte> texte, List<string> ignorMistakes = null)
        {
            InitializeComponent();
            clearForm();
            lstTexte = new List<HunspellTexte>(texte);
            if (ignorMistakes != null)
                lstIgnoreMistakes = new List<string>(ignorMistakes);
            findMistakes();
            if (MistakesCounter > 0)
            {
                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.Enabled = true;
                }
                loadMistake(0);
            }
            else
            {
                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.Enabled = false;
                }
                btnHelp.Enabled = true;
                btnOK.Enabled = true;
            }
        }
        private void findMistakes()
        {
            char[] splitter =
                { ' ', '.', '!', '?', ',', '-', '*', '/', '(', ')', '\n', ';', ':', '"', '#'
                ,'\'', '\t', '\\', '[', ']', '{', '}', '<', '>' };
            string[] separator =
                { "\r", "\n", " ", "", "-" };
            int nID = 0;

            foreach (HunspellTexte text in lstTexte)
            {
                char[] cAll = text.Text.ToCharArray();
                int count = cAll.Length;
                string word = "";
                int nOffset = 0;

                //Leeren der Liste für den Fall des Neuladens.
                text.Fehler.Clear();

                for (int i = 0; i < count; i++)
                {
                    if (splitter.Contains(cAll[i]) || i == count - 1)
                    {
                        if (i == count - 1)
                        {
                            if (!splitter.Contains(cAll[i]))
                            {
                                nOffset = 1;
                                word += cAll[i];
                            }
                        }
                        if (!hunspell.Spell(word) && !separator.Contains(word) && !lstIgnoreMistakes.Contains(word))
                        {
                            Mistakes mistakes = new Mistakes()
                            {
                                Start = i - word.Length + nOffset,
                                Ende = i - 1 + nOffset,
                                ID = nID
                            };
                            nID++;
                            text.Fehler.Add(mistakes);
                            lstFehler.Add(word);
                            MistakesCounter++;
                        }
                        word = "";
                    }
                    else
                    {
                        word += cAll[i];
                    }
                }
            }
        }
        private SentenceMistake findSentence(Mistakes mistake, string text)
        {
            SentenceMistake sentenceMistake = new SentenceMistake();
            char[] cAll = text.ToCharArray();
            char[] splitter = { '.', '!', '?' };
            int count = cAll.Length;
            bool gefunden = false;
            sentenceMistake.Satzbeginn = 0;

            for (int i = 0; i < count; i++)
            {
                if (i > mistake.Start)
                    gefunden = true;
                if (splitter.Contains(cAll[i]))
                {
                    if (gefunden)
                    {
                        sentenceMistake.Satz += cAll[i];
                        break;
                    }
                    else
                    {
                        sentenceMistake.Satz = "";
                        sentenceMistake.Satzbeginn = i + 1;
                    }
                }
                else
                {
                    sentenceMistake.Satz += cAll[i];
                }
            }
            return sentenceMistake;
        }
        private string findWord(Mistakes mistake, string text)
        {
            string result = "";
            char[] cAll = text.ToCharArray();
            for (int i = mistake.Start; i <= mistake.Ende; i++)
            {
                result += cAll[i];
            }
            return result;
        }
        private void fillDataGrid(string word)
        {
            dGVSuggest.Rows.Clear();
            dGVSuggest.Columns.Clear();

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
        private void loadMistake(int id)
        {
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            btnReplaceAll.Enabled = false;

            bool gefunden = false;
            string sMistake = "", sSentence = "", sHeadline = "";
            int nMistakeCount = 0, nMistakePlace = 0;
            SentenceMistake sentenceMistake = new SentenceMistake();

            foreach (HunspellTexte text in lstTexte)
            {
                foreach (Mistakes fehler in text.Fehler)
                {
                    if (fehler.ID == id)
                    {
                        sMistake = findWord(fehler, text.Text);
                        sentenceMistake = findSentence(fehler, text.Text);
                        sSentence = sentenceMistake.Satz;
                        nMistakePlace = fehler.Start - sentenceMistake.Satzbeginn;
                        sHeadline = text.Name;
                        gefunden = true;
                        break;
                    }
                }
                if (gefunden)
                    break;
            }

            var mCount = from fehler in lstFehler
                         where fehler == sMistake
                         select fehler;
            nMistakeCount = mCount.Count();

            fillDataGrid(sMistake);

            if (id > 0)
                btnBack.Enabled = true;
            if (id < MistakesCounter - 1)
                btnNext.Enabled = true;
            if (nMistakeCount > 1)
                btnReplaceAll.Enabled = true;

            lblName.Text = sHeadline;
            lblMistake.Text = sMistake;
            lblMistakeCount.Text = nMistakeCount.ToString();
            lblNumber.Text = Convert.ToString(id + 1) + "/" + MistakesCounter.ToString();

            rtbSentence.Text = "";
            string sSentenceStart = sSentence.Substring(0, nMistakePlace);
            string sSentenceEnd = sSentence.Substring(nMistakePlace + sMistake.Length, sSentence.Length - (nMistakePlace + sMistake.Length));
            Color specialColor = Color.Red;
            if (lstCorrectedMistakes.Contains(id))
                specialColor = Color.Green;
            appendText(rtbSentence, sSentenceStart, Color.Black);
            appendText(rtbSentence, sMistake, specialColor);
            appendText(rtbSentence, sSentenceEnd, Color.Black);
        }
        private void appendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            nMistakeID--;
            loadMistake(nMistakeID);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            nMistakeID++;
            loadMistake(nMistakeID);
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (dGVSuggest.SelectedCells.Count > 0 && dGVSuggest.CurrentCell.Value != null)
            {
                string sReplace = dGVSuggest.CurrentCell.Value.ToString();
                string currentFehler = lstFehler[nMistakeID];
                int fehlerCount = lstFehler.Count;
                for (int i = 0; i < fehlerCount; i++)
                {
                    if (lstFehler[i] == currentFehler)
                        lstFehler[i] = sReplace;
                }
                foreach (HunspellTexte text in lstTexte)
                {
                    int nDifferenz = 0;
                    foreach (Mistakes fehler in text.Fehler)
                    {
                        fehler.Start += nDifferenz;
                        fehler.Ende += nDifferenz;
                        if (findWord(fehler, text.Text) == currentFehler)
                        {
                            string sTextStart = text.Text.Substring(0, fehler.Start);
                            string sTextEnde = text.Text.Substring(fehler.Ende + 1, text.Text.Length - fehler.Ende - 1);
                            text.Text = sTextStart + sReplace + sTextEnde;
                            nDifferenz += sReplace.Length - (fehler.Ende - fehler.Start + 1);
                            fehler.Ende = fehler.Start + sReplace.Length - 1;
                            repText(text.Name, text.Text);
                            if (!lstCorrectedMistakes.Contains(fehler.ID))
                                lstCorrectedMistakes.Add(fehler.ID);
                        }
                    }
                }
                loadMistake(nMistakeID);
            }
        }

        private void btnReplaceOne_Click(object sender, EventArgs e)
        {
            if (dGVSuggest.SelectedCells.Count > 0 && dGVSuggest.CurrentCell.Value != null)
            {
                string sReplace = dGVSuggest.CurrentCell.Value.ToString();
                lstFehler[nMistakeID] = sReplace;
                bool gefunden = false;
                foreach (HunspellTexte text in lstTexte)
                {
                    int nDifferenz = 0;
                    foreach (Mistakes fehler in text.Fehler)
                    {
                        if (gefunden)//Dies betrifft nur die Fehler nach dem Korrigierten.
                        {
                            fehler.Start += nDifferenz;
                            fehler.Ende += nDifferenz;
                        }
                        if (fehler.ID == nMistakeID)
                        {
                            string sTextStart = text.Text.Substring(0, fehler.Start);
                            string sTextEnde = text.Text.Substring(fehler.Ende + 1, text.Text.Length - fehler.Ende - 1);
                            text.Text = sTextStart + sReplace + sTextEnde;
                            nDifferenz = sReplace.Length - (fehler.Ende - fehler.Start + 1);
                            fehler.Ende = fehler.Start + sReplace.Length - 1;
                            repText(text.Name, text.Text);
                            if (!lstCorrectedMistakes.Contains(fehler.ID))
                                lstCorrectedMistakes.Add(fehler.ID);
                            gefunden = true;
                        }
                    }
                    if (gefunden)
                        break;
                }
                loadMistake(nMistakeID);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            string currentFehler = lstFehler[nMistakeID];
            foreach (HunspellTexte text in lstTexte)
            {
                foreach (Mistakes fehler in text.Fehler)
                {
                    if (findWord(fehler, text.Text) == currentFehler)
                    {
                        if (!lstIgnoreMistakes.Contains(currentFehler))
                        {
                            lstIgnoreMistakes.Add(currentFehler);
                            repList(lstIgnoreMistakes);
                        }
                        if (!lstCorrectedMistakes.Contains(fehler.ID))
                            lstCorrectedMistakes.Add(fehler.ID);
                    }
                }
            }
            loadMistake(nMistakeID);
        }

        private void btnShowIgnore_Click(object sender, EventArgs e)
        {
            FormIgnoreList fIgnore = new FormIgnoreList(lstIgnoreMistakes);
            fIgnore.repIgnLst = new replaceIgnoreList(this.funnelIgnoreList);
            if (fIgnore.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void funnelIgnoreList(List<string> list)
        {
            lstIgnoreMistakes = list;
            repList(list);
            clearForm();
            findMistakes();
            if (MistakesCounter > 0)
            {
                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.Enabled = true;
                }
                loadMistake(0);
            }
            else
            {
                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.Enabled = false;
                }
                btnOK.Enabled = true;
                btnHelp.Enabled = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            FormHelp fHelp = new FormHelp();
            if (fHelp.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void clearForm()
        {
            MistakesCounter = 0;
            nMistakeID = 0;
            lstFehler.Clear();
            lstCorrectedMistakes.Clear();
            rtbSentence.Text = "";
            lblMistake.Text = "Kein Fehler gefunden.";
            lblName.Text = "";
            lblNumber.Text = "0/0";
            lblMistakeCount.Text = "";
            dGVSuggest.Rows.Clear();
        }
    }
}
