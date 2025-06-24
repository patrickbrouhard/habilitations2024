using habilitations2024.controller;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace habilitations2024.view
{

    /// <summary>
    /// Formulaire d'authentification des administrateurs
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// Contrôleur de la logique métier associée à l'authentification
        /// </summary>
        private FrmAuthentificationController controller;
        /// <summary>
        /// Initialise le formulaire et ses composants
        /// </summary>
        public FrmAuthentification()
        {
            InitializeComponent();
            this.AcceptButton = buttonConnexion;
            controller = new FrmAuthentificationController();
        }
        /// <summary>
        /// Tente de connecter l'utilisateur via les champs saisis
        /// </summary>
        /// <param name="sender">Bouton Connexion</param>
        /// <param name="e">Événement clic</param>
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            if (!champsAdminValides())
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return;
            }

            string nom = textBoxNom.Text;
            string prenom = textBoxPrenom.Text;
            string pwd = textBoxPwd.Text;
            Admin admin = new Admin(nom, prenom, pwd);

            if (controller.ControleAuthentification(admin))
            {
                this.Hide();
                FrmHabilitations frmHabilitations = new FrmHabilitations();
                frmHabilitations.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Authentification invalide", "Alerte");
                textBoxPwd.Text = "";
                textBoxPwd.Focus();
            }
        }
        /// <summary>
        /// Vérifie que tous les champs obligatoires sont remplis
        /// </summary>
        /// <returns>true si valides, false sinon</returns>
        private bool champsAdminValides()
        {
            return !string.IsNullOrWhiteSpace(textBoxNom.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxPrenom.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxPwd.Text);
        }
    }
}
