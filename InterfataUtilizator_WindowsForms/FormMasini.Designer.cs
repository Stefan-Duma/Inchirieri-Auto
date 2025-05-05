namespace InterfataUtilizator_WindowsForms
{
    partial class FormMasini
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtModel = new MetroFramework.Controls.MetroTextBox();
            this.txtAnAparitie = new MetroFramework.Controls.MetroTextBox();
            this.txtTaxa = new MetroFramework.Controls.MetroTextBox();
            this.txtStoc = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(437, 104);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(175, 50);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Adaugare Masina";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(437, 202);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(175, 50);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "Cautare Masina";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(72, 104);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 20);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Model";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(72, 171);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(75, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "An aparitie";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(85, 247);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(35, 20);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Taxa";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(85, 315);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(35, 20);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Stoc";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(72, 131);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(75, 23);
            this.txtModel.TabIndex = 6;
            // 
            // txtAnAparitie
            // 
            this.txtAnAparitie.Location = new System.Drawing.Point(72, 202);
            this.txtAnAparitie.Name = "txtAnAparitie";
            this.txtAnAparitie.Size = new System.Drawing.Size(75, 23);
            this.txtAnAparitie.TabIndex = 7;
            // 
            // txtTaxa
            // 
            this.txtTaxa.Location = new System.Drawing.Point(72, 270);
            this.txtTaxa.Name = "txtTaxa";
            this.txtTaxa.Size = new System.Drawing.Size(75, 23);
            this.txtTaxa.TabIndex = 8;
            // 
            // txtStoc
            // 
            this.txtStoc.Location = new System.Drawing.Point(72, 338);
            this.txtStoc.Name = "txtStoc";
            this.txtStoc.Size = new System.Drawing.Size(75, 23);
            this.txtStoc.TabIndex = 9;
            // 
            // FormMasini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtStoc);
            this.Controls.Add(this.txtTaxa);
            this.Controls.Add(this.txtAnAparitie);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMasini";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "Optiuni Masini";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtModel;
        private MetroFramework.Controls.MetroTextBox txtAnAparitie;
        private MetroFramework.Controls.MetroTextBox txtTaxa;
        private MetroFramework.Controls.MetroTextBox txtStoc;
    }
}