using System;
using System.IO;
using System.Collections.Generic;

namespace LRDG2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int i = 0, id = 1, x, y;
            string str;
            char[] tab = new char[10];
            List<char> carte = new List<char>();
            List<int> carteCrypt = new List<int>();
            List<char> caractereDejaUtilise = new List<char>();
            List<UniteTerre> nmUniteTerre = new List<UniteTerre>();
            StreamReader sr = new StreamReader("C:/Users/sdf07/source/repos/TESTLRDG/scabb.clair");
            while ((str = sr.ReadLine()) != null)
            {
                tab = str.ToCharArray();
                for (i = 0; i < 10; i++)
                {
                    carte.Add(tab[i]);
                }
            }
            Console.WriteLine(carte.Count);
            foreach (char unite in carte)
            {
                if (unite == 'M')
                {
                    carteCrypt.Add(64);
                }
                else if (unite == 'F')
                {
                    carteCrypt.Add(32);
                }
                else
                {
                    carteCrypt.Add(0);
                    x = id % 10 - 1;
                    y = (id - id % 10) / 10;
                    UniteTerre uniteT = new UniteTerre(x, y, unite);
                    nmUniteTerre.Add(uniteT);
                    
                    if (!caractereDejaUtilise.Contains(unite))
                    {
                        caractereDejaUtilise.Add(unite);
                    }
                }
                id++;
            }
            foreach (int crypt in carteCrypt)
            {
                Console.WriteLine(crypt);
            }
            foreach (char carac in caractereDejaUtilise)
            {
                Console.WriteLine(carac);
            }
            Console.WriteLine(nmUniteTerre.Count);
            foreach (UniteTerre unite in nmUniteTerre)
            {
                unite.afficherCarac();
            }
            */
            Carte carte = new Carte("C:/Users/sdf07/source/repos/TESTLRDG/scabb.clair");
            carte.AfficherLaCarte();
            carte.AfficherLaCarteCrypte();
            carte.AfficherLesStats();
            carte.InfoParcelle('i');
            Decrypteur decrypteur = new Decrypteur();
            Console.WriteLine(carte.RetournerLaTrame());
            decrypteur.DecrypterLaTrame(carte.RetournerLaTrame());
        }
    }
}
