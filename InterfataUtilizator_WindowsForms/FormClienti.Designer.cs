namespace InterfataUtilizator_WindowsForms
{
    partial class FormClienti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtNume = new MetroFramework.Controls.MetroTextBox();
            this.txtPrenume = new MetroFramework.Controls.MetroTextBox();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.txtTelefon = new MetroFramework.Controls.MetroTextBox();
            this.btnAdauga = new MetroFramework.Controls.MetroButton();
            this.btnCautare = new MetroFramework.Controls.MetroButton();
            this.btnModificare = new MetroFramework.Controls.MetroButton();
            this.listClienti = new System.Windows.Forms.ListView();
            this.btnStergere = new MetroFramework.Controls.MetroButton();
            this.btnReturn = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.Location = new System.Drawing.Point(33, 101);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nume";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(33, 167);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 20);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Prenume";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(128, 96);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(42, 20);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Email";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(128, 166);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(54, 20);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Telefon";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(33, 137);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(75, 23);
            this.txtNume.TabIndex = 6;
            // 
            // txtPrenume
            // 
            this.txtPrenume.Location = new System.Drawing.Point(33, 203);
            this.txtPrenume.Name = "txtPrenume";
            this.txtPrenume.Size = new System.Drawing.Size(75, 23);
            this.txtPrenume.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(128, 133);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(75, 23);
            this.txtEmail.TabIndex = 8;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(128, 203);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(75, 23);
            this.txtTelefon.TabIndex = 9;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(225, 120);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(175, 50);
            this.btnAdauga.TabIndex = 12;
            this.btnAdauga.Text = "Adaugare client";
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnCautare
            // 
            this.btnCautare.Location = new System.Drawing.Point(406, 120);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(175, 50);
            this.btnCautare.TabIndex = 13;
            this.btnCautare.Text = "Cautare client";
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // btnModificare
            // 
            this.btnModificare.Location = new System.Drawing.Point(225, 176);
            this.btnModificare.Name = "btnModificare";
            this.btnModificare.Size = new System.Drawing.Size(175, 50);
            this.btnModificare.TabIndex = 15;
            this.btnModificare.Text = "Modificare client";
            this.btnModificare.Click += new System.EventHandler(this.btnModificare_Click);
            // 
            // listClienti
            // 
            this.listClienti.HideSelection = false;
            this.listClienti.Location = new System.Drawing.Point(33, 257);
            this.listClienti.Name = "listClienti";
            this.listClienti.Size = new System.Drawing.Size(614, 157);
            this.listClienti.TabIndex = 16;
            this.listClienti.UseCompatibleStateImageBehavior = false;
            // 
            // btnStergere
            // 
            this.btnStergere.Location = new System.Drawing.Point(406, 176);
            this.btnStergere.Name = "btnStergere";
            this.btnStergere.Size = new System.Drawing.Size(175, 50);
            this.btnStergere.TabIndex = 17;
            this.btnStergere.Text = "Stergere client";
            this.btnStergere.Click += new System.EventHandler(this.btnStergere_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(584, 176);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(175, 50);
            this.btnReturn.TabIndex = 35;
            this.btnReturn.Text = "Back to menu";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(584, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 50);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.listClienti);
            this.Controls.Add(this.btnModificare);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPrenume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormClienti";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "Optiuni Clienti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtNume;
        private MetroFramework.Controls.MetroTextBox txtPrenume;
        private MetroFramework.Controls.MetroTextBox txtEmail;
        private MetroFramework.Controls.MetroTextBox txtTelefon;
        private MetroFramework.Controls.MetroButton btnAdauga;
        private MetroFramework.Controls.MetroButton btnCautare;
        private MetroFramework.Controls.MetroButton btnModificare;
        private System.Windows.Forms.ListView listClienti;
        private MetroFramework.Controls.MetroButton btnStergere;
        private MetroFramework.Controls.MetroButton btnReturn;
        private MetroFramework.Controls.MetroButton btnClear;
    }
}