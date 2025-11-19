using habilitations2024.model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.dal
{
    public class DeveloppeurAccess
    {
        // Instance unique de l'accès aux données
        private readonly Access access = null;
        // Constructeur pour créer l'accès aux données
        public DeveloppeurAccess()
        {
            this.access = Access.GetInstance();
        }
        /// <summary>
        /// récupère et retourne les développeurs
        /// </summary>
        /// <returns></returns>
        public List<Developpeur> GetLesDeveloppeurs()
        {
            var developpeurs = new List<Developpeur>();
            // Utilise l'opérateur ?. pour éviter une exception si 'access' est null
            // si access ou Manager est null, on quitte la méthode.
            if (access?.Manager == null)
                return developpeurs;

            //@"" = verbatim string literal = permet entre autres d'écrire sur plrs lignes
            var req = @"
                        SELECT iddeveloppeur, d.nom, prenom, tel, mail, p.idprofil, p.nom 
                        FROM developpeur d 
                        JOIN profil p USING(idprofil) 
                        ORDER BY d.nom, prenom;";

            try
            {
                var records = access.Manager.ReqSelect(req);
                if (records == null) 
                    return developpeurs;
                Log.Debug("DeveloppeurAccess.GetLesDeveloppeurs nb records = {0}", records.Count);

                foreach (object[] r in records)
                {
                    Log.Debug("DeveloppeurAccess.GetLesDeveloppeurs Profil : id={0} nom={1}", r[5], r[6]);
                    Log.Debug("DeveloppeurAccess.GetLesDeveloppeurs Developpeur : id={0} nom={1} prenom={2} tel={3} mail={4} ", r[0], r[1], r[2], r[3], r[4]);
                    var dProfil = new Profil((int)r[5], (string)r[6]);
                    developpeurs.Add(new Developpeur(
                        (int)r[0],           // iddeveloppeur
                        (string)r[1],        // nom
                        (string)r[2],        // prenom
                        (string)r[3],        // tel
                        (string)r[4],        // mail
                        dProfil
                    ));
                }
            }
            catch (Exception e)
            {
                req = req.Replace(Environment.NewLine, " ");
                Log.Error("DeveloppeurAccess.GetLesDeveloppeurs catch - req={0} - erreur={1}", req, e.Message);
                Console.Error.WriteLine($"Erreur dans GetLesDeveloppeurs() : {e.Message}");
                Environment.Exit(0);
            }
            return developpeurs;
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void DelDeveloppeur(Developpeur developpeur)
        {
            if (access?.Manager == null) return;

            var req = "DELETE FROM developpeur WHERE iddeveloppeur = @id";
            var parameters = new Dictionary<string, object>
            {
                {"@id",  developpeur.Iddeveloppeur},
            };
            try
            {
                access.Manager.ReqUpdate(req, parameters);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erreur dans DelDeveloppeur() : {e.Message}");
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Demande d'ajout un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void AddDeveloppeur(Developpeur developpeur)
        {
            if (access?.Manager == null) return;
            var req = @"
                        INSERT INTO developpeur (nom,prenom,tel,mail,pwd,idprofil) 
                        VALUES (@nom,@prenom,@tel,@mail,SHA2(@pwd, 256),@idprofil);";
            var parametres = new Dictionary<string, object>
            {
                {"@nom", developpeur.Nom},
                {"@prenom", developpeur.Prenom},
                {"@tel", developpeur.Tel},
                {"@mail", developpeur.Email},
                {"@pwd", developpeur.Nom},
                {"@idprofil", developpeur.Profil.Idprofil}
            };
            try
            {
                access.Manager.ReqUpdate(req, parametres);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erreur dans AddDeveloppeur() : {e.Message}");
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            if (access?.Manager == null) return;

            var req = @"
                        UPDATE developpeur 
                        SET nom=@nom,prenom=@prenom,tel=@tel,mail=@mail,
                            idprofil=@idprofil WHERE iddeveloppeur=@id";
            var parametres = new Dictionary<string, object>
            {
                {"@id", developpeur.Iddeveloppeur},
                {"@nom", developpeur.Nom},
                {"@prenom", developpeur.Prenom},
                {"@tel", developpeur.Tel},
                {"@mail", developpeur.Email},
                {"@idprofil", developpeur.Profil.Idprofil}
            };
            try
            {
                access.Manager.ReqUpdate(req, parametres);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erreur dans UpdateDeveloppeur() : {e.Message}");
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Demande de modification du pwd
        /// </summary>
        /// <param name="developpeur"></param>
        public void UpdatePwd(Developpeur developpeur)
        {
            if (access?.Manager == null) return;

            var req = @"
                        UPDATE developpeur 
                        SET pwd=SHA2(@pwd, 256) 
                        WHERE iddeveloppeur=@id";
            var parametres = new Dictionary<string, object>
            {
                {"@id", developpeur.Iddeveloppeur},
                {"@pwd", developpeur.Pwd}
            };
            try
            {
                access.Manager.ReqUpdate(req, parametres);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erreur dans UpdatePwd() : {e.Message}");
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Vérifie si l'utilisateur possède un profil administrateur et peut se connecter.
        /// </summary>
        /// <param name="admin">Objet contenant les informations de connexion de l'utilisateur (nom, prénom, mot de passe).</param>
        /// <returns>True si l'utilisateur est authentifié avec un profil "admin", sinon false.</returns>
        public Boolean ControleAuthentification(Admin admin)
        {
            if (access?.Manager == null) return false;

            var req = @"
                        SELECT * FROM developpeur d JOIN profil p USING(idprofil)
                        WHERE d.nom = @nom 
                          AND d.prenom = @prenom 
                          AND d.pwd = SHA2(@pwd, 256)
                          AND p.nom = 'admin';";
            var parametres = new Dictionary<string, object>
            {
                {"@nom", admin.Nom},
                {"@prenom", admin.Prenom},
                {"@pwd", admin.Pwd},
            };
            try
            {
                var resultat = access.Manager.ReqSelect(req, parametres);
                return resultat?.Count > 0; //opérateur de null conditionnel ?.
            }
            catch (Exception e)
            {
                Log.Error("DeveloppeurAccess.ControleAuthentification catch - req={0} - erreur={1}", req, e.Message);
                Console.Error.WriteLine($"Erreur dans ControleAuthentification() : {e.Message}");
                Environment.Exit(0);
            }
            return false;
        }
    }
}
