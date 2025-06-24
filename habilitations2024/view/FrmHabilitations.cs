using habilitations2024.controller;
using habilitations2024.dal;
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
    public partial class FrmHabilitations : Form
    {
        /// <summary>
        /// Contrôleur de la fenêtre FrmHabilitations.
        /// </summary>
        FrmHabilitationsController controller;
        /// <summary>
        /// Source de données liée aux développeurs.
        /// </summary>
        BindingSource bdgDeveloppeurs = new BindingSource();
        /// <summary>
        /// Source de données liée aux profils.
        /// </summary>
        BindingSource bdgProfils = new BindingSource();
        /// <summary>
        /// Indique si la fenêtre est en mode édition développeur.
        /// </summary>
        Boolean devEditModeState = false;

        public FrmHabilitations()
        {
            InitializeComponent();
            init();
        }
        /// <summary>
        /// Initialise les composants et remplit les données.
        /// </summary>
        private void init()
        {
            controller = new FrmHabilitationsController();
            RemplirListeDeveloppeurs();
            RemplirComboProfils();
            BasculerModeEditionDev(false);
            BasculerModeChangementPwd(false);
        }
        /// <summary>
        /// Remplit la liste des développeurs dans le DataGridView.
        /// </summary>
        private void RemplirListeDeveloppeurs()
        {
            bdgDeveloppeurs.DataSource = controller.GetLesDeveloppeurs();
            dataGridViewDeveloppeurs.DataSource = bdgDeveloppeurs;
            dataGridViewDeveloppeurs.Columns["pwd"].Visible = false;
            dataGridViewDeveloppeurs.Columns["iddeveloppeur"].Visible = false;
            dataGridViewDeveloppeurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        /// <summary>
        /// Remplit le ComboBox des profils disponibles.
        /// </summary>
        private void RemplirComboProfils()
        {
            bdgProfils.DataSource = controller.GetLesProfils();
            comboBoxProfil.DataSource = bdgProfils;
            comboBoxProfil.SelectedIndex = 0;
        }
        /// <summary>
        /// Active ou désactive le mode édition développeur.
        /// </summary>
        /// <param name="devEditModeState">true pour activer, false pour désactiver</param>
        private void BasculerModeEditionDev(bool devEditModeState)
        {
            this.devEditModeState = devEditModeState;
            groupBoxLesDeveloppeurs.Enabled = !devEditModeState;
            if (devEditModeState)
            {
                groupBoxAjouteDev.Text = "Modifier un développeur";
            }
            else
            {
                groupBoxAjouteDev.Text = "Ajouter un développeur";
                textBoxNom.Text = "";
                textBoxPrenom.Text = "";
                textBoxEmail.Text = "";
                textBoxTel.Text = "";
                comboBoxProfil.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Active ou désactive le mode changement de mot de passe.
        /// </summary>
        /// <param name="pwdEditModeState">true pour activer, false pour désactiver</param>
        private void BasculerModeChangementPwd(bool pwdEditModeState)
        {
            groupBoxChangePwd.Enabled = pwdEditModeState;
            groupBoxLesDeveloppeurs.Enabled = !pwdEditModeState;
            groupBoxAjouteDev.Enabled = !pwdEditModeState;
            textBoxPwd.Text = "";
            textBoxEncore.Text = "";
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Modifier.
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count == 1)
            {
                BasculerModeEditionDev(true);
                //Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                Developpeur devSelectionne = (Developpeur)bdgDeveloppeurs.Current;
                textBoxNom.Text = devSelectionne.Nom;
                textBoxPrenom.Text = devSelectionne.Prenom;
                textBoxEmail.Text = devSelectionne.Email;
                textBoxTel.Text = devSelectionne.Tel;
                comboBoxProfil.SelectedIndex = comboBoxProfil.FindStringExact(devSelectionne.Profil.Nom);
            }
            else
            {
                // Aucune ligne sélectionnée
                MessageBox.Show("Veuillez sélectionner une ligne.");
            }
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Annuler (édition développeur).
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonDevAnnuler_Click(object sender, EventArgs e)
        {
            if (AfficherMessageConfirmation("annuler"))
            {
                BasculerModeEditionDev(false);
            }
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Supprimer.
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count == 1)
            {
                Developpeur devSelectionne = (Developpeur)bdgDeveloppeurs.Current;
                if (AfficherMessageConfirmation("supprimer", devSelectionne))
                {
                    controller.DelDeveloppeur(devSelectionne);
                    RemplirListeDeveloppeurs();
                }
            }
            else 
            { 
                MessageBox.Show("Veuillez sélectionner une ligne."); 
            }
        }
        /// <summary>
        /// Demande confirmation à l'utilisateur pour une commande donnée.
        /// </summary>
        /// <param name="commande">Commande à confirmer (ex. : "supprimer")</param>
        /// <param name="dev">Développeur concerné, optionnel</param>
        /// <returns>true si l’utilisateur confirme, false sinon</returns>
        private bool AfficherMessageConfirmation(string commande, Developpeur dev = null)
        {
            string nomComplet = dev != null ? $"{dev.Prenom} {dev.Nom}" : "";
            var message = $"Voulez-vous vraiment {commande} {nomComplet} ?";
            DialogResult resultat = MessageBox.Show(
                message,
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );
            return (resultat == DialogResult.Yes);
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Changer mot de passe.
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonChangerPwd_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count == 1)
            {
                BasculerModeChangementPwd(true);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne.");
            }
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Annuler (mot de passe).
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonPwdAnnuler_Click(object sender, EventArgs e)
        {
            BasculerModeChangementPwd(false);
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Enregistrer (développeur).
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonDevEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ChampsDevValides())
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return;
            }
            Profil profil = (Profil)bdgProfils.Current; //récupère le profil selectionné dans le combo
            if (devEditModeState)
            {
                Developpeur devSelectionne = (Developpeur)bdgDeveloppeurs.Current;
                devSelectionne.Nom = textBoxNom.Text;
                devSelectionne.Prenom = textBoxPrenom.Text;
                devSelectionne.Email = textBoxEmail.Text;
                devSelectionne.Tel = textBoxTel.Text;
                //comboBoxProfil.SelectedIndex = comboBoxProfil.FindStringExact(devSelectionne.Profil.Nom);
                devSelectionne.Profil = profil;
                controller.UpdateDeveloppeur(devSelectionne);
            }
            else
            {
                Developpeur dev = new Developpeur(0, textBoxNom.Text, textBoxPrenom.Text, textBoxTel.Text, textBoxEmail.Text, profil);
                controller.AddDeveloppeur(dev);
            }
            RemplirListeDeveloppeurs();
            BasculerModeEditionDev(false);
        }
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton Enregistrer (mot de passe).
        /// </summary>
        /// <param name="sender">Source de l’événement</param>
        /// <param name="e">Arguments de l’événement</param>
        private void buttonPwdEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ChampsPwdValides())
            {
                MessageBox.Show("Les mots de passe doivent être remplis et identiques.");
                return;
            }
            if (textBoxPwd.Text != textBoxEncore.Text)
            {
                MessageBox.Show("Les mots de passe doivent être identiques.");
                return;
            }
            Developpeur devSelectionne = (Developpeur)bdgDeveloppeurs.Current;
            devSelectionne.Pwd = textBoxPwd.Text;
            controller.UpdatePwd(devSelectionne);
            BasculerModeChangementPwd(false);
            MessageBox.Show("Mot de passe enregistré.");
        }
        /// <summary>
        /// Vérifie si les champs développeur sont remplis.
        /// </summary>
        /// <returns>true si valides, false sinon</returns>
        private bool ChampsDevValides()
        {
            return !string.IsNullOrWhiteSpace(textBoxNom.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxPrenom.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxEmail.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxTel.Text) &&
                   comboBoxProfil.SelectedIndex != -1;
        }
        /// <summary>
        /// Vérifie si les champs mot de passe sont valides et identiques.
        /// </summary>
        /// <returns>true si valides, false sinon</returns>
        private bool ChampsPwdValides()
        {
            if (string.IsNullOrWhiteSpace(textBoxPwd.Text) || string.IsNullOrWhiteSpace(textBoxEncore.Text))
                return false;
            return textBoxPwd.Text == textBoxEncore.Text;
        }
    }
}
