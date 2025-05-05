using InchirieriAuto_WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace InterfataUtilizator_WindowsForms
{
    public partial class MainForm: MetroForm
    {
        private PictureBox backgroundPictureBox;
        public MainForm()
        {
            InitializeComponent();
            //Image bgImage = Image.FromFile("C:\\Users\\Stefan\\source\\repos\\InchirieriAuto\\BackgroundImages\\MainForm.jpg");
            
            //backgroundPictureBox = new PictureBox();
            //backgroundPictureBox.Dock = DockStyle.Fill;
            //backgroundPictureBox.Image = bgImage;
            //backgroundPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //this.Controls.Add(backgroundPictureBox);
            
            //backgroundPictureBox.SendToBack();
            //this.DoubleBuffered = true;


        }

        private void metroClienti_Click(object sender, EventArgs e)
        {
            FormClienti OptiuniClienti = new FormClienti();
            OptiuniClienti.Show();

        }
        private void metroMasini_Click(object sender, EventArgs e)
        {
            FormMasini OptiuniMasini = new FormMasini();
            OptiuniMasini.Show();
        }
        private void metroExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
