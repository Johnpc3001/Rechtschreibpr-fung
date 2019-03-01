using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechtschreibpruefung
{
    public class HunspellTexte
    {
        private string _sName, _sText;
        private List<Mistakes> _mistakes = new List<Mistakes>();
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        public string Text
        {
            get { return _sText; }
            set { _sText = value; }
        }
        public List<Mistakes> Fehler
        {
            get { return _mistakes; }
            set { _mistakes = value; }
        }

        public HunspellTexte()
        {

        }
        public HunspellTexte(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}
