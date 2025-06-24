using habilitations2024.dal;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.controller
{
    /// <summary>
    /// Contrôleur de FrmAuthentification
    /// </summary>
    public class FrmAuthentificationController
    {
        /// <summary>
        /// objet d'accès aux opérations possibles sur Developpeur
        /// </summary>
        private readonly DeveloppeurAccess developpeurAccess;

        /// <summary>Add commentMore actions
        /// Récupère l'acces aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            developpeurAccess = new DeveloppeurAccess();
        }
        /// <summary>
        /// Vérifie l'authentification
        /// </summary>
        /// <param name="admin">Objet contenant les informations de connexion de l'utilisateur (nom, prénom, mot de passe).</param>
        /// <returns>True si l'utilisateur est authentifié avec un profil "admin", sinon false.</returns>
        public Boolean ControleAuthentification(Admin admin)
        {
            return developpeurAccess.ControleAuthentification(admin);
        }
    }
}
