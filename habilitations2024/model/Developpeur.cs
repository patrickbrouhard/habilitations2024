using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    /// <summary>
    /// Classe métier Developpeur
    /// </summary>
    public class Developpeur
    {
        public int Iddeveloppeur {  get; }
        public string Nom { get; set; }
        public string Prenom {  get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public Profil Profil { get; set; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="iddeveloppeur"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="profil"></param>
        public Developpeur(int iddeveloppeur, string nom, string prenom, string tel, string email, Profil profil)
        {
            this.Iddeveloppeur = iddeveloppeur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Email = email;
            this.Pwd = Pwd;
            this.Profil = profil;
        }
    }
}
