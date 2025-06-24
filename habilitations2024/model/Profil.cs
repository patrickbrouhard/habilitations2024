using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    /// <summary>
    /// Classe métier Profil
    /// </summary>
    public class Profil
    {
        public int Idprofil {  get; }
        public string Nom {  get; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idprofil"></param>
        /// <param name="name"></param>
        public Profil(int idprofil, string name)
        {
            this.Idprofil = idprofil;
            this.Nom = name;
        }
        /// <summary>
        /// overrride ToString
        /// </summary>
        /// <returns>Nom du profil</returns>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
