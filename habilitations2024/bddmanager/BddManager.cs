using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using System.Collections.Generic;
using static Mysqlx.Notice.SessionStateChanged.Types;

namespace habilitations2024.bddmanager
{
    /// <summary>
    /// Singleton : connexion à la base de données et exécution des requêtes
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static BddManager instance = null; // on peut aussi utiliser Lazy<T> pour un Singleton thread-safe
        /// <summary>
        /// objet de connexion à la BDD à partir d'une chaîne de connexion
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Constructeur pour créer la connexion à la BDD et l'ouvrir
        /// </summary>
        /// <param name="stringConnect">chaine de connexion</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// Création d'une seule instance de la classe
        /// </summary>
        /// <param name="stringConnect">chaine de connexion</param>
        /// <returns>instance unique de la classe</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }
        /// <summary>
        /// Exécute une requête SQL de type SELECT sur la base de données active,
        /// en utilisant éventuellement des paramètres, et retourne les résultats sous forme de liste de tableaux d'objets.
        /// Chaque tableau représente une ligne, contenant les valeurs des colonnes dans l'ordre.
        /// </summary>
        /// <param name="stringQuery">La requête SQL SELECT à exécuter.</param>
        /// <param name="parameters">
        /// Un dictionnaire contenant les paramètres de la requête (nom du paramètre → valeur),
        /// ou <c>null</c> s’il n’y a aucun paramètre à appliquer.
        /// </param>
        /// <returns>
        /// Une liste de tableaux d’objets, où chaque tableau contient les valeurs d’une ligne du résultat.
        /// </returns>
        public List<object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();
            List<object[]> records = new List<object[]>();
            while (reader.Read())
            {
                object[] ligne = new object[reader.FieldCount];
                reader.GetValues(ligne);
                records.Add(ligne);
            }
            reader.Close();
            return records;
        }

        /// <summary>
        /// Exécution d'une requête autre que "select"
        /// </summary>
        /// <param name="stringQuery">requête autre que select</param>
        /// <param name="parameters">dictionnire contenant les parametres</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

    }
}
