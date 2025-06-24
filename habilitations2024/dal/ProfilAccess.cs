using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.dal
{
    /// <summary>
    /// gestion des demandes sur les profils
    /// </summary>
    public class ProfilAccess
    {
        /// <summary>
        /// singleton
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur
        /// </summary>
        public ProfilAccess()
        {
            this.access = Access.GetInstance();
        }

        public List<Profil> GetLesProfils()
        {
            var profils = new List<Profil>();

            if (access?.Manager == null) //cf "opérateur de navigation conditionnelle" pour "?"
                return profils;

            try
            {
                var resultat = access.Manager.ReqSelect("SELECT idprofil, nom FROM `profil`;");
                if (resultat == null) return profils;

                foreach (object[] result in resultat)
                {
                    profils.Add(new Profil((int)result[0], (string)result[1]));
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erreur dans GetLesProfils() : {e.Message}");
                Environment.Exit(0); //on me dit qu'il ne faut jamais l'arrêt dans une couche basse...
            }
            return profils;

        }
    }
}
