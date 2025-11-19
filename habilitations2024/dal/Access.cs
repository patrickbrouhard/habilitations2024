using habilitations2024.bddmanager;
using Serilog;
using Serilog.Configuration;
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
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log.txt")
                    .CreateLogger();
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
    }
}
