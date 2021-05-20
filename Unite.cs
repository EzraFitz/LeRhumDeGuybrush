using System;
using System.Collections.Generic;
using System.Text;

namespace LRDG2
{
    /// <summary>
    /// Classe abstraite qui représente chaque unité
    /// </summary>
    abstract public class Unite
    {
        #region Attributs
        /// <summary>
        /// coordonnée X de l'unité
        /// </summary>
        protected int coordonneesX;
        /// <summary>
        /// coordonnée Y de l'unité
        /// </summary>
        protected int coordonneesY;

        /// <summary>
        /// nombres de frontière de l'unité
        /// </summary>
        protected int frontieres;

        protected char lettre;

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut de la classe
        /// </summary>
        public Unite()
        {
            this.coordonneesX = 0;

            this.coordonneesY = 0;

            this.frontieres = 0;

        }

        /// <summary>
        /// Constructur 2 de la classe permet de préciser les coordonnées 
        /// </summary>
        /// <param name="x">Coordonnée en X</param>
        /// <param name="y">Coordonnée en Y</param>
        /// <param name="front">Valeur de la frontière</param>
        public Unite(int x, int y)
        {
            this.coordonneesX = x;

            this.coordonneesY = y;

        }

        public (int, int) RetournerCoordonnes()
        {
            return (coordonneesX, coordonneesY);
        }

        public void DefinirFrontieres(int nombreFrontiere)
        {
            this.frontieres += nombreFrontiere;
        }

        virtual public void afficherCaracteristiques()
        {
            Console.WriteLine("Unite de coos x : {0} - y : {1}", coordonneesX, coordonneesY);
            Console.WriteLine("Lettre : {0}", this.lettre);
            Console.WriteLine("Frontieres : {0}", this.frontieres);
        }

        public char RetournerLaLettre()
        {
            return this.lettre;
        }
        
        public int RetournerValeurFrontiers()
        {
            return this.frontieres;
        }

        #endregion
    }
}