using System;
using System.Collections.Generic;
using System.Text;

namespace LRDG2
{ 
    class Parcelle
    {
        private char lettre;
        private List<UniteTerre> listeUnite = new List<UniteTerre>();
        private List<(int, int)> listeFrontieresNord = new List<(int, int)>();
        private List<(int, int)> listeFrontieresSud = new List<(int, int)>();
        private List<(int, int)> listeFrontieresEst = new List<(int, int)>();
        private List<(int, int)> listeFrontieresOuest = new List<(int, int)>();
        private (int, int) coin1;
        private (int, int) coin2;
        private (int, int) dimensionsParcelle;
        private int frontieres;

        public Parcelle (List<UniteTerre> liste, char lettre)
        {
            foreach(UniteTerre unite in liste)
            {
                this.listeUnite.Add(unite);
            }

            this.lettre = lettre;

            this.coin1 = listeUnite[0].RetournerCoordonnes();

            this.coin2 = listeUnite[0].RetournerCoordonnes();

            this.dimensionsParcelle = (0, 0);

            this.frontieres = 0;

            this.DefinirLesCoins();

            this.DefinirLesDimensions();

            //this.DefinirLesFrontieres();
        }

        private void DefinirLesCoins()
        {
            foreach(UniteTerre unite in this.listeUnite)
            {
                if (unite.RetournerCoordonnes().Item1 < this.coin1.Item1 && unite.RetournerCoordonnes().Item2 < this.coin1.Item2)
                {
                    this.coin1 = unite.RetournerCoordonnes();
                }
                if (unite.RetournerCoordonnes().Item1 >= this.coin1.Item1 && unite.RetournerCoordonnes().Item2 > this.coin1.Item2)
                {
                    this.coin2 = unite.RetournerCoordonnes();
                }
            }
        }

        private void DefinirLesDimensions()
        {
            int i;
            for(i = coin1.Item1; i <= coin2.Item1; i++)
            {
                this.dimensionsParcelle.Item1++;
            }
            for (i = coin1.Item2; i <= coin2.Item2; i++)
            {
                this.dimensionsParcelle.Item2++;
            }
        }

        private void DefinirLesFrontieres()
        {
            int frontieresNord = this.dimensionsParcelle.Item1 * Convert.ToInt32(Math.Pow(2, 0));
            int frontieresSud = this.dimensionsParcelle.Item1 * Convert.ToInt32(Math.Pow(2, 2));
            int frontieresEst = this.dimensionsParcelle.Item2 * Convert.ToInt32(Math.Pow(2, 3));
            int frontieresOuest = this.dimensionsParcelle.Item1 * Convert.ToInt32(Math.Pow(2, 1));
            this.frontieres = frontieresNord + frontieresSud + frontieresEst + frontieresOuest;
            this.DefinirLesFrontieresUnites();
        }

        private void DefinirLesFrontieresUnites()
        {
            foreach(UniteTerre uniteTerre in listeUnite)
            {
                //Si oui alors frontière nord
                if(uniteTerre.RetournerCoordonnes().Item2 == coin1.Item2)
                {
                    uniteTerre.DefinirFrontieres(Convert.ToInt32(Math.Pow(2, 0)));
                }
                //Si oui alors frontière sud
                if(uniteTerre.RetournerCoordonnes().Item2 == coin2.Item2)
                {
                    uniteTerre.DefinirFrontieres(Convert.ToInt32(Math.Pow(2, 2)));
                }
                // Si oui alors frontière est
                if(uniteTerre.RetournerCoordonnes().Item1 == coin2.Item1)
                {
                    uniteTerre.DefinirFrontieres(Convert.ToInt32(Math.Pow(2, 3)));
                }
                // Si oui alors frontière ouest
                if(uniteTerre.RetournerCoordonnes().Item1 == coin1.Item1)
                {
                    uniteTerre.DefinirFrontieres(Convert.ToInt32(Math.Pow(2, 1)));
                }
            }
        }

        public void AfficherInformations()
        {
            Console.WriteLine("La parcelle {0} possede {1} unites", this.lettre, this.listeUnite.Count);
            Console.WriteLine("Elle est de dimension {0}", this.dimensionsParcelle);
            Console.WriteLine("Son point le plus petit est en : {0}", this.coin1);
            Console.WriteLine("Son point le plus grand est en : {0}", this.coin2);
            Console.WriteLine("Frontieres : {0}", this.frontieres);
            foreach (UniteTerre unite in this.listeUnite)
            {
                unite.afficherCaracteristiques();
            }
        }

        public char RetournerLaLettre()
        {
            return this.lettre;
        }

    }
}
