using System.Drawing;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    partial class MainForm
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
            this.metroClienti = new MetroFramework.Controls.MetroButton();
            this.metroMasini = new MetroFramework.Controls.MetroButton();
            this.metroGestiune = new MetroFramework.Controls.MetroButton();
            this.metroExit = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroClienti
            // 
            this.metroClienti.Location = new System.Drawing.Point(24, 95);
            this.metroClienti.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroClienti.Name = "metroClienti";
            this.metroClienti.Size = new System.Drawing.Size(196, 54);
            this.metroClienti.TabIndex = 0;
            this.metroClienti.Text = "Optiuni Clienti";
            this.metroClienti.Click += new System.EventHandler(this.metroClienti_Click);
            // 
            // metroMasini
            // 
            this.metroMasini.Location = new System.Drawing.Point(24, 171);
            this.metroMasini.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroMasini.Name = "metroMasini";
            this.metroMasini.Size = new System.Drawing.Size(196, 54);
            this.metroMasini.TabIndex = 1;
            this.metroMasini.Text = "Optiuni Masini";
            this.metroMasini.Click += new System.EventHandler(this.metroMasini_Click);
            // 
            // metroGestiune
            // 
            this.metroGestiune.Location = new System.Drawing.Point(24, 244);
            this.metroGestiune.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroGestiune.Name = "metroGestiune";
            this.metroGestiune.Size = new System.Drawing.Size(196, 54);
            this.metroGestiune.TabIndex = 2;
            this.metroGestiune.Text = "Gestiune inchirieri";
            this.metroGestiune.Click += new System.EventHandler(this.metroGestiune_Click);
            // 
            // metroExit
            // 
            this.metroExit.Location = new System.Drawing.Point(24, 315);
            this.metroExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroExit.Name = "metroExit";
            this.metroExit.Size = new System.Drawing.Size(196, 54);
            this.metroExit.TabIndex = 3;
            this.metroExit.Text = "Exit";
            this.metroExit.Click += new System.EventHandler(this.metroExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroExit);
            this.Controls.Add(this.metroGestiune);
            this.Controls.Add(this.metroMasini);
            this.Controls.Add(this.metroClienti);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "Meniu Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroClienti;
        private MetroFramework.Controls.MetroButton metroMasini;
        private MetroFramework.Controls.MetroButton metroGestiune;
        private MetroFramework.Controls.MetroButton metroExit;
    }
}