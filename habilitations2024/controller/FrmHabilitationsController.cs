using habilitations2024.dal;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace habilitations2024.controller
{
    /// <summary>
    /// Contrôleur de FrmHabilitations
    /// </summary>
    public class FrmHabilitationsController
    {
        /// <summary>
        /// objet d'accès aux opérations possibles sur Developpeur
        /// </summary>
        private readonly DeveloppeurAccess developpeurAccess;
        /// <summary>
        /// objet d'accès aux opérations possible sur Profil
        /// </summary>
        private readonly ProfilAccess profilAccess;

        /// <summary>
        /// Récupère les acces aux données
        /// </summary>
        public FrmHabilitationsController()
        {
            this.developpeurAccess = new DeveloppeurAccess();
            this.profilAccess = new ProfilAccess();
        }

        /// <summary>
        /// Récupère et retourne la liste des développeurs
        /// </summary>
        /// <returns></returns>
        public List<Developpeur> GetLesDeveloppeurs()
        {
            return developpeurAccess.GetLesDeveloppeurs();
        }
        /// <summary>
        /// Récupère et retourne la liste des profils
        /// </summary>
        /// <returns></returns>
        public List<Profil> GetLesProfils()
        {
            return profilAccess.GetLesProfils();
        }
        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void DelDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.DelDeveloppeur(developpeur);
        }
        /// <summary>
        /// Demande d'ajout d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void AddDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.AddDeveloppeur(developpeur);
        }
        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.UpdateDeveloppeur(developpeur);
        }
        /// <summary>
        /// Demande de changement de pwd
        /// </summary>
        /// <param name="developpeur"></param>
        public void UpdatePwd(Developpeur developpeur)
        {
            developpeurAccess.UpdatePwd(developpeur);
        }
        /// <summary>
        /// Vérifie si le mot de passe respecte les critères de sécurité.
        /// </summary>
        /// <param name="pwd">Mot de passe à tester.</param>
        /// <returns>true si valide ; false sinon.</returns>
        public bool PwdFort(string pwd)
        {
            // Longueur : entre 8 et 30 caractères
            if (pwd.Length < 8 || pwd.Length > 30)
                return false;

            // Minuscule Unicode
            if (!Regex.Match(pwd, @"\p{Ll}").Success)
                return false;

            // Majuscule Unicode
            if (!Regex.Match(pwd, @"\p{Lu}").Success)
                return false;

            // Chiffre
            if (!Regex.Match(pwd, @"[0-9]").Success)
                return false;

            // Caractère spécial (liste définie)
            if (!Regex.Match(pwd, @"[!@#$%^&*()_\-+=\[\]{}|;:,.<>/?]").Success)
                return false;

            // Aucun espace ou caractère blanc
            if (Regex.Match(pwd, @"\s").Success)
                return false;

            return true;
        }
    }
}
