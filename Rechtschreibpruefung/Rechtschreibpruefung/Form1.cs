using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHunspell;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;

namespace Rechtschreibpruefung
{
    public partial class Form1 : Form
    {
        string sWordOriginal = "";
        List<string> lstMistakes = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            rtxtCheck.Text = "";
            sWordOriginal = "";
            lstMistakes.Clear();

            List<string> lsInputTexts = new List<string>();
            string sWord = string.Empty;
            string[] replace = {".",",",":",";"};

            sWord = txtInput.Text;
            sWordOriginal = sWord;
            sWord = sWord.Replace('-', ' ');
            foreach(string rep in replace)
            {
                sWord = sWord.Replace(rep, "");
            }
            lsInputTexts = sWord.Split(' ').ToList<string>();

            string sDirectory = Directory.GetCurrentDirectory();
            using (Hunspell hunspell = new Hunspell(sDirectory + @"\de_DE_frami.aff",
                                                    sDirectory + @"\de_DE_frami.dic"))
            {
                foreach (string word in lsInputTexts)
                {
                    Color txtColor = Color.Black;
                    if (!hunspell.Spell(word))
                    {
                        txtColor = Color.Red;
                        lstMistakes.Add(word);
                    }
                    appendText(rtxtCheck, word, txtColor);
                }
            }
        }

        private void appendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text + " ");
            box.SelectionColor = box.ForeColor;
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            formCorrect dialog = new formCorrect(lstMistakes);
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                int count = lstMistakes.Count;
                for(int i = 0; i<count; i++)
                {
                    sWordOriginal = sWordOriginal.Replace(lstMistakes[i], dialog.list[i]);
                }
                rtxtCheck.AppendText("\r\n" + sWordOriginal);
            }
        }
        #region FormHunspell
        static string sDirectory = Directory.GetCurrentDirectory();

        List<string> lstIgnoreMistakes = File.ReadAllLines(sDirectory + "\\ignore.txt").ToList<string>();
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            List<HunspellTexte> texte = new List<HunspellTexte>();
            HunspellTexte txt1 = new HunspellTexte("TextBox 1", textBox1.Text);
            texte.Add(txt1);
            HunspellTexte txt2 = new HunspellTexte("TextBox 2", textBox2.Text);
            texte.Add(txt2);
            HunspellTexte txt3 = new HunspellTexte("TextBox 3", textBox3.Text);
            texte.Add(txt3);
            HunspellTexte txt4 = new HunspellTexte("TextBox 4", textBox4.Text);
            texte.Add(txt4);
            HunspellTexte txt5 = new HunspellTexte("TextBox 5", textBox5.Text);
            texte.Add(txt5);
            FormHunspell fHunspell = new FormHunspell(texte, lstIgnoreMistakes);
            fHunspell.repText = new replaceText(this.replaceTextFn);
            fHunspell.repList = new replaceList(this.replaceIgnoreFn);
            if (fHunspell.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
        public void replaceIgnoreFn(List<string> lst)
        {
            lstIgnoreMistakes = lst;
            File.WriteAllLines(sDirectory + "\\ignore.txt", lstIgnoreMistakes.ToArray<string>());
        }
        public void replaceTextFn(string name, string text)
        {
            switch (name)
            {
                case "TextBox 1":
                    textBox1.Text = text;
                    break;
                case "TextBox 2":
                    textBox2.Text = text;
                    break;
                case "TextBox 3":
                    textBox3.Text = text;
                    break;
                case "TextBox 4":
                    textBox4.Text = text;
                    break;
                case "TextBox 5":
                    textBox5.Text = text;
                    break;
            }
        }
        #endregion
        Hunspell globHunspell = new Hunspell(sDirectory + @"\de_DE_frami.aff",
                                             sDirectory + @"\de_DE_frami.dic");
        char[] splitter =
                { ' ', '.', '!', '?', ',', '-', '*', '/', '(', ')', '\n', ';', ':', '"', '#'
                ,'\'', '\t', '\\', '[', ']', '{', '}', '<', '>' };

        private void colorRTB(RichTextBox box, int start, int lenght, Color color)
        {
            box.SelectionStart = start;
            box.SelectionLength = lenght;
            box.SelectionColor = color;
        }
        private void fontRTB(RichTextBox box, int start, int lenght, FontStyle font)
        {
            box.SelectionStart = start;
            box.SelectionLength = lenght;
            box.SelectionFont = new Font(box.SelectionFont, font);
        }
        private void rtbLiveUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Point mousePoint = new Point(Cursor.Position.X, Cursor.Position.Y);
                int count = 0;
                string[] sAll = ((RichTextBox)sender).Text.Split(splitter);
                int pos = ((RichTextBox)sender).GetCharIndexFromPosition(new Point(e.X, e.Y));
                foreach (string word in sAll)
                {
                    if (!globHunspell.Spell(word) && !lstIgnoreMistakes.Contains(word) 
                        && pos >= count && pos <= count + word.Length)
                    {
                        FormLiveUpdate fLiveUpdate = new FormLiveUpdate(word, globHunspell);
                        fLiveUpdate.StartPosition = FormStartPosition.Manual;
                        fLiveUpdate.Location = mousePoint;
                        if (fLiveUpdate.ShowDialog() == DialogResult.OK)
                        {
                            if(fLiveUpdate.sReplace != null)
                            {
                                ((RichTextBox)sender).SelectionStart = count;
                                ((RichTextBox)sender).SelectionLength = word.Length;
                                ((RichTextBox)sender).SelectedText = fLiveUpdate.sReplace;
                                ((RichTextBox)sender).SelectionStart = count + fLiveUpdate.sReplace.Length;
                                ((RichTextBox)sender).SelectionLength = 0;
                                checkrtbLive();
                            }
                            else if (fLiveUpdate.bIgnore)
                            {
                                if (!lstIgnoreMistakes.Contains(word))
                                {
                                    lstIgnoreMistakes.Add(word);
                                    replaceIgnoreFn(lstIgnoreMistakes);
                                    checkrtbLive();
                                }
                            }
                        }
                        fLiveUpdate.Close();
                        break;
                    }
                    count += 1 + word.Length;
                }
            }
        }

        private void rtbLiveUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (splitter.Contains(e.KeyChar))
            {
                checkrtbLive();
            }
        }
        char[] cSelector = { '.', '!', '?', ',', ';'};
        private void checkrtbLive()
        {
            char[] cAll = rtbLiveUpdate.Text.ToCharArray();
            int cCount = 0;
            bool bMistake = false;
            int sCount = 0;
            string[] sAll = rtbLiveUpdate.Text.Split(splitter);
            int pos = rtbLiveUpdate.SelectionStart;
            colorRTB(rtbLiveUpdate, 0, rtbLiveUpdate.TextLength, Color.Black);
            fontRTB(rtbLiveUpdate, 0, rtbLiveUpdate.TextLength, FontStyle.Regular);
            foreach (char c in cAll)
            {
                if (c != ' ' && bMistake)
                {
                    fontRTB(rtbLiveUpdate, cCount - 1, 2, FontStyle.Underline);
                    bMistake = false;
                }
                else if (cSelector.Contains(c))
                {
                    bMistake = true;
                }
                else
                {
                    bMistake = false;
                }
                cCount++;
            }
            foreach (string word in sAll)
            {
                if (!globHunspell.Spell(word) && !lstIgnoreMistakes.Contains(word))
                {
                    colorRTB(rtbLiveUpdate, sCount, word.Length, Color.Red);
                }
                sCount += 1 + word.Length;
            }
            colorRTB(rtbLiveUpdate, pos, 0, Color.Black);
            fontRTB(rtbLiveUpdate, pos, 0, FontStyle.Regular);
        }
    }
}
