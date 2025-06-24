using habilitations2024.bddmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.dal
{
    /// <summary>
    /// classe d'accès à BddManager
    /// </summary>
    public class Access
    {
        private static readonly string connectionString = "server=localhost;user=habilitations;database=habilitations;port=3306;password=motdepasseuser;";
        private static Access Instance = null;
        public BddManager Manager { get; }

        /// <summary>
        /// Constructeur privé car implémentation Singleton
        /// </summary>
        private Access()
        {
            try
            {
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception e)
            {

                Console.Error.WriteLine("Erreur lors de l'initialisation de la connexion : " + e.Message);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// getter singleton
        /// </summary>
        /// <returns>Instance</returns>
        public static Access GetInstance()
        {
            if (Instance == null) { Instance = new Access(); }
            return Instance;
        }
    }
}
