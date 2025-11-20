using habilitations2024.bddmanager;
using Serilog;
using System;
using System.Configuration;

namespace habilitations2024.dal
{
    /// <summary>
    /// classe d'accès à BddManager
    /// </summary>
    public class Access
    {
        /// <summary>
        /// nom de connexion à la bdd
        /// </summary>
        private static readonly string connectionName = 
            "habilitations2024.Properties.Settings.habilitationsConnectionString";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access Instance = null;
        /// <summary>
        /// Getter sur l'objet d'accès aux données
        /// </summary>
        public BddManager Manager { get; }

        /// <summary>
        /// Constructeur privé car implémentation Singleton
        /// </summary>
        private Access()
        {
            String connectionString = null;
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log.txt")
                    .CreateLogger();
                connectionString = GetConnectionStringByName(connectionName);
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception e)
            {
                Log.Fatal("Acces.Access catch - connectionString={0} - erreur={1}", connectionString, e.Message);
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

        /// <summary>
        /// Récupération de la chaîne de connexion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string GetConnectionStringByName(string name)
        {
            string val = null;
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];
            if (settings != null) {
                val = settings.ConnectionString;
            }
            return val;
        }
    }
}
