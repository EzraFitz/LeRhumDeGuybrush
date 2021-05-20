using System;
using System.Collections.Generic;
using System.Text;

namespace LRDG2
{
    class Decrypteur
    {
        private List<int> frontieresCarte = new List<int>();
        private List<char> carte = new List<char>();
        public void DecrypterLaTrame(List<string> trame)
        {
            this.TransformerLaTrame(trame);
            this.RecupererLeTypeDesUnites(this.frontieresCarte);
            Console.WriteLine(frontieresCarte.Count);
            foreach(char frontiere in this.carte)
            {
                Console.WriteLine(frontiere);
            }
        }

        private void TransformerLaTrame(List<string> trame)
        {
            foreach(string caractere in trame)
            {
                if(caractere == ":" || caractere == "|") 
                {
                }
                else
                {
                    this.frontieresCarte.Add(Convert.ToInt32(caractere));
                }
            }
        }

        private void RecupererLeTypeDesUnites(List<int> frontieres)
        {
            foreach(int frontiere in frontieres)
            {
                if( 0 <= frontiere && frontiere <= 15) { carte.Add('T'); }
                else if (32 <= frontiere && frontiere <= 47) { carte.Add('F'); }
                else if (64 <= frontiere && frontiere <= 79) { carte.Add('M'); }
            }
        }

    }
}
