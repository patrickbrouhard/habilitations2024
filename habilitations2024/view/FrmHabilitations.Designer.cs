namespace habilitations2024.view
{
    partial class FrmHabilitations
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxLesDeveloppeurs = new System.Windows.Forms.GroupBox();
            this.dataGridViewDeveloppeurs = new System.Windows.Forms.DataGridView();
            this.groupBoxAjouteDev = new System.Windows.Forms.GroupBox();
            this.groupBoxChangePwd = new System.Windows.Forms.GroupBox();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.buttonChangerPwd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.comboBoxProfil = new System.Windows.Forms.ComboBox();
            this.buttonDevEnregistrer = new System.Windows.Forms.Button();
            this.buttonDevAnnuler = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.textBoxEncore = new System.Windows.Forms.TextBox();
            this.buttonPwdEnregistrer = new System.Windows.Forms.Button();
            this.buttonPwdAnnuler = new System.Windows.Forms.Button();
            this.groupBoxLesDeveloppeurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeveloppeurs)).BeginInit();
            this.groupBoxAjouteDev.SuspendLayout();
            this.groupBoxChangePwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLesDeveloppeurs
            // 
            this.groupBoxLesDeveloppeurs.Controls.Add(this.buttonChangerPwd);
            this.groupBoxLesDeveloppeurs.Controls.Add(this.buttonSupprimer);
            this.groupBoxLesDeveloppeurs.Controls.Add(this.buttonModifier);
            this.groupBoxLesDeveloppeurs.Controls.Add(this.dataGridViewDeveloppeurs);
            this.groupBoxLesDeveloppeurs.Location = new System.Drawing.Point(16, 15);
            this.groupBoxLesDeveloppeurs.Name = "groupBoxLesDeveloppeurs";
            this.groupBoxLesDeveloppeurs.Size = new System.Drawing.Size(908, 406);
            this.groupBoxLesDeveloppeurs.TabIndex = 0;
            this.groupBoxLesDeveloppeurs.TabStop = false;
            this.groupBoxLesDeveloppeurs.Text = "Les développeurs";
            // 
            // dataGridViewDeveloppeurs
            // 
            this.dataGridViewDeveloppeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeveloppeurs.Location = new System.Drawing.Point(9, 29);
            this.dataGridViewDeveloppeurs.MultiSelect = false;
            this.dataGridViewDeveloppeurs.Name = "dataGridViewDeveloppeurs";
            this.dataGridViewDeveloppeurs.ReadOnly = true;
            this.dataGridViewDeveloppeurs.RowHeadersVisible = false;
            this.dataGridViewDeveloppeurs.RowHeadersWidth = 62;
            this.dataGridViewDeveloppeurs.RowTemplate.Height = 28;
            this.dataGridViewDeveloppeurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDeveloppeurs.Size = new System.Drawing.Size(872, 317);
            this.dataGridViewDeveloppeurs.TabIndex = 0;
            // 
            // groupBoxAjouteDev
            // 
            this.groupBoxAjouteDev.Controls.Add(this.comboBoxProfil);
            this.groupBoxAjouteDev.Controls.Add(this.textBoxTel);
            this.groupBoxAjouteDev.Controls.Add(this.buttonDevAnnuler);
            this.groupBoxAjouteDev.Controls.Add(this.buttonDevEnregistrer);
            this.groupBoxAjouteDev.Controls.Add(this.textBoxEmail);
            this.groupBoxAjouteDev.Controls.Add(this.textBoxPrenom);
            this.groupBoxAjouteDev.Controls.Add(this.textBoxNom);
            this.groupBoxAjouteDev.Controls.Add(this.label5);
            this.groupBoxAjouteDev.Controls.Add(this.label4);
            this.groupBoxAjouteDev.Controls.Add(this.label3);
            this.groupBoxAjouteDev.Controls.Add(this.label2);
            this.groupBoxAjouteDev.Controls.Add(this.label1);
            this.groupBoxAjouteDev.Location = new System.Drawing.Point(16, 431);
            this.groupBoxAjouteDev.Name = "groupBoxAjouteDev";
            this.groupBoxAjouteDev.Size = new System.Drawing.Size(908, 198);
            this.groupBoxAjouteDev.TabIndex = 1;
            this.groupBoxAjouteDev.TabStop = false;
            this.groupBoxAjouteDev.Text = "Ajouter un développeur";
            // 
            // groupBoxChangePwd
            // 
            this.groupBoxChangePwd.Controls.Add(this.label7);
            this.groupBoxChangePwd.Controls.Add(this.label6);
            this.groupBoxChangePwd.Controls.Add(this.buttonPwdAnnuler);
            this.groupBoxChangePwd.Controls.Add(this.textBoxEncore);
            this.groupBoxChangePwd.Controls.Add(this.buttonPwdEnregistrer);
            this.groupBoxChangePwd.Controls.Add(this.textBoxPwd);
            this.groupBoxChangePwd.Location = new System.Drawing.Point(16, 638);
            this.groupBoxChangePwd.Name = "groupBoxChangePwd";
            this.groupBoxChangePwd.Size = new System.Drawing.Size(908, 118);
            this.groupBoxChangePwd.TabIndex = 2;
            this.groupBoxChangePwd.TabStop = false;
            this.groupBoxChangePwd.Text = "Changement de mot de passe";
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(9, 355);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(112, 35);
            this.buttonModifier.TabIndex = 1;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(127, 355);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(112, 35);
            this.buttonSupprimer.TabIndex = 1;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // buttonChangerPwd
            // 
            this.buttonChangerPwd.Location = new System.Drawing.Point(245, 355);
            this.buttonChangerPwd.Name = "buttonChangerPwd";
            this.buttonChangerPwd.Size = new System.Drawing.Size(112, 35);
            this.buttonChangerPwd.TabIndex = 1;
            this.buttonChangerPwd.Text = "Maj pwd";
            this.buttonChangerPwd.UseVisualStyleBackColor = true;
            this.buttonChangerPwd.Click += new System.EventHandler(this.buttonChangerPwd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(81, 29);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(366, 26);
            this.textBoxNom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prénom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Profil";
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(81, 68);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(366, 26);
            this.textBoxPrenom.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(531, 29);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(366, 26);
            this.textBoxEmail.TabIndex = 1;
            // 
            // textBoxTel
            // 
            this.textBoxTel.Location = new System.Drawing.Point(531, 69);
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(240, 26);
            this.textBoxTel.TabIndex = 1;
            // 
            // comboBoxProfil
            // 
            this.comboBoxProfil.FormattingEnabled = true;
            this.comboBoxProfil.Location = new System.Drawing.Point(531, 109);
            this.comboBoxProfil.Name = "comboBoxProfil";
            this.comboBoxProfil.Size = new System.Drawing.Size(240, 28);
            this.comboBoxProfil.TabIndex = 2;
            // 
            // buttonDevEnregistrer
            // 
            this.buttonDevEnregistrer.Location = new System.Drawing.Point(13, 114);
            this.buttonDevEnregistrer.Name = "buttonDevEnregistrer";
            this.buttonDevEnregistrer.Size = new System.Drawing.Size(112, 35);
            this.buttonDevEnregistrer.TabIndex = 1;
            this.buttonDevEnregistrer.Text = "Enregistrer";
            this.buttonDevEnregistrer.UseVisualStyleBackColor = true;
            this.buttonDevEnregistrer.Click += new System.EventHandler(this.buttonDevEnregistrer_Click);
            // 
            // buttonDevAnnuler
            // 
            this.buttonDevAnnuler.Location = new System.Drawing.Point(131, 114);
            this.buttonDevAnnuler.Name = "buttonDevAnnuler";
            this.buttonDevAnnuler.Size = new System.Drawing.Size(112, 35);
            this.buttonDevAnnuler.TabIndex = 1;
            this.buttonDevAnnuler.Text = "Annuler";
            this.buttonDevAnnuler.UseVisualStyleBackColor = true;
            this.buttonDevAnnuler.Click += new System.EventHandler(this.buttonDevAnnuler_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pwd";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(462, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Encore";
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(81, 31);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(366, 26);
            this.textBoxPwd.TabIndex = 1;
            this.textBoxPwd.UseSystemPasswordChar = true;
            // 
            // textBoxEncore
            // 
            this.textBoxEncore.Location = new System.Drawing.Point(531, 34);
            this.textBoxEncore.Name = "textBoxEncore";
            this.textBoxEncore.Size = new System.Drawing.Size(366, 26);
            this.textBoxEncore.TabIndex = 1;
            this.textBoxEncore.UseSystemPasswordChar = true;
            // 
            // buttonPwdEnregistrer
            // 
            this.buttonPwdEnregistrer.Location = new System.Drawing.Point(13, 77);
            this.buttonPwdEnregistrer.Name = "buttonPwdEnregistrer";
            this.buttonPwdEnregistrer.Size = new System.Drawing.Size(112, 35);
            this.buttonPwdEnregistrer.TabIndex = 1;
            this.buttonPwdEnregistrer.Text = "Enregistrer";
            this.buttonPwdEnregistrer.UseVisualStyleBackColor = true;
            this.buttonPwdEnregistrer.Click += new System.EventHandler(this.buttonPwdEnregistrer_Click);
            // 
            // buttonPwdAnnuler
            // 
            this.buttonPwdAnnuler.Location = new System.Drawing.Point(131, 77);
            this.buttonPwdAnnuler.Name = "buttonPwdAnnuler";
            this.buttonPwdAnnuler.Size = new System.Drawing.Size(112, 35);
            this.buttonPwdAnnuler.TabIndex = 1;
            this.buttonPwdAnnuler.Text = "Annuler";
            this.buttonPwdAnnuler.UseVisualStyleBackColor = true;
            this.buttonPwdAnnuler.Click += new System.EventHandler(this.buttonPwdAnnuler_Click);
            // 
            // FrmHabilitations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 772);
            this.Controls.Add(this.groupBoxChangePwd);
            this.Controls.Add(this.groupBoxAjouteDev);
            this.Controls.Add(this.groupBoxLesDeveloppeurs);
            this.Name = "FrmHabilitations";
            this.Text = "Form1";
            this.groupBoxLesDeveloppeurs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeveloppeurs)).EndInit();
            this.groupBoxAjouteDev.ResumeLayout(false);
            this.groupBoxAjouteDev.PerformLayout();
            this.groupBoxChangePwd.ResumeLayout(false);
            this.groupBoxChangePwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLesDeveloppeurs;
        private System.Windows.Forms.GroupBox groupBoxAjouteDev;
        private System.Windows.Forms.GroupBox groupBoxChangePwd;
        private System.Windows.Forms.DataGridView dataGridViewDeveloppeurs;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Button buttonChangerPwd;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.ComboBox comboBoxProfil;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.Button buttonDevEnregistrer;
        private System.Windows.Forms.Button buttonDevAnnuler;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEncore;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Button buttonPwdAnnuler;
        private System.Windows.Forms.Button buttonPwdEnregistrer;
    }
}

