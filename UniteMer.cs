using System;
using System.Collections.Generic;
using System.Text;

namespace LRDG2
{
    class UniteMer : Unite
    {
        public UniteMer(int x, int y) : base(x, y)
        {
            this.lettre = 'M';
            this.frontieres += 64;
        }

        public void AjouterFrontieres(List<UniteMer> liste)
        {
            //Nord Sud   Est   Ouest
            (bool, bool, bool, bool) voisins = this.VerifierVoisinsMer(liste);
            if (!voisins.Item1) { this.DefinirFrontieres(1); }
            if (!voisins.Item2) { this.DefinirFrontieres(4); }
            if (!voisins.Item3) { this.DefinirFrontieres(8); }
            if (!voisins.Item4) { this.DefinirFrontieres(2); }
        }

        private (bool, bool, bool, bool) VerifierVoisinsMer(List<UniteMer> liste)
        {
            //Nord Sud   Est   Ouest
            (bool, bool, bool, bool) voisins = (false, false, false, false);
            (int, int) coordonnees = this.RetournerCoordonnes();
            foreach (UniteMer unite in liste)
            {
                (int, int) coordonnees2 = unite.RetournerCoordonnes();
                //Frontière nord
                if (coordonnees.Item1 == coordonnees2.Item1 && (coordonnees.Item2 - 1) == coordonnees2.Item2) { voisins.Item1 = true; }
                //Frontière sud
                if (coordonnees.Item1 == coordonnees2.Item1 && (coordonnees.Item2 + 1) == coordonnees2.Item2) { voisins.Item2 = true; }
                //Frontière est
                if ((coordonnees.Item1 + 1) == coordonnees2.Item1 && coordonnees.Item2 == coordonnees2.Item2) { voisins.Item3 = true; }
                //Frontière ouest
                if ((coordonnees.Item1 - 1) == coordonnees2.Item1 && coordonnees.Item2 == coordonnees2.Item2) { voisins.Item4 = true; }
            }
            return voisins;
        }
    }
}
