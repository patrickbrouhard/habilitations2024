using habilitations2024.model;
using Serilog;
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

            string req = "SELECT * FROM profil ORDER BY nom;";

            try
            {
                var records = access.Manager.ReqSelect(req);
                if (records == null) return profils;
                Log.Debug("ProfilAccess.GesLesProfils nb records = {0}", records.Count);

                foreach (object[] record in records)
                {
                    Log.Debug("ProfilAccess.GestLesProfils id={0} nom={1}", record[0], record[1]);
                    Profil profil = new Profil((int)record[0], (string)record[1]);
                    profils.Add(profil);
                }
            }
            catch (Exception e)
            {
                Log.Error("ProfilAccess.GetLesProfils() catch - req={0} - erreur={1}", req, e.Message);
                Console.Error.WriteLine($"Erreur dans GetLesProfils() : {e.Message}");
                Environment.Exit(0); //on me dit qu'il ne faut jamais l'arrêt dans une couche basse...
            }
            return profils;

        }
    }
}
