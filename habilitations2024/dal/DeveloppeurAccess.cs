using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //récupère et retourne les développeurs
        public List<Developpeur> GetLesDeveloppeurs()
        {
            var developpeurs = new List<Developpeur>();

            if (access?.Manager == null)
                return developpeurs;

            try
            {
                //@"" = verbatim string literal = permet entre autres d'écrire sur plrs lignes
                var req = @"SELECT iddeveloppeur, d.nom, prenom, tel, mail, p.idprofil, p.nom 
                            FROM developpeur d 
                            JOIN profil p USING(idprofil) 
                            ORDER BY d.nom, prenom;";
                var resultat = access.Manager.ReqSelect(req);
                if (resultat == null) return developpeurs;

                foreach (object[] r in resultat)
                {
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
            // Utilise l'opérateur ?. pour éviter une exception si 'access' est null
            // si access ou Manager est null, on quitte la méthode.
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
            var req = @"INSERT INTO developpeur (nom,prenom,tel,mail,pwd,idprofil) VALUES
                            (@nom,@prenom,@tel,@mail,SHA2(@pwd, 256),@idprofil);";
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

            var req = @"UPDATE developpeur SET nom=@nom,prenom=@prenom,tel=@tel,mail=@mail
                       ,idprofil=@idprofil WHERE iddeveloppeur=@id";
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

            var req = "UPDATE developpeur SET pwd=SHA2(@pwd, 256) WHERE iddeveloppeur=@id";
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
    }
}
