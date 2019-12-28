using System;
using System.Windows.Forms;

namespace Scumari
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private bool SectorCorrecto()
        {
            string[] sectores = new string[] { "LECM", "LECB", "LECS", "GCCC" };

            for (int i = 0; i < 4; i++)
            {
                if (SECTORbox.Text == sectores[i]) { return true; }
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(VIDbox.TextLength == 6) || !(int.TryParse(VIDbox.Text, out int a))) { MessageBox.Show("Revisa tu VID, éste no contiene 6 números.", "VID Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!(SectorCorrecto())) { MessageBox.Show("Revisa el sector, éste no está presente en la lista antes mencionada.", "Sector Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            Form1 form1 = new Form1(VIDbox.Text, SECTORbox.Text);
            this.Hide();
            form1.ShowDialog();
        }
    }
}