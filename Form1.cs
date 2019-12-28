using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scumari
{
    public partial class Form1 : Form   
    {

        // Importamos la función SetWindowPos de user32.dll
        private const UInt32 TOPMOST_FLAGS = 0x0001 | 0x0002;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // end

        public Form1(string VID, string SECTOR)
        {
            InitializeComponent();
            navegador.Navigate(string.Format("https://www.scumari.nl/squawk/{0}-sq.php?id={1}&size=2", SECTOR.ToLower(), VID));
            SetWindowPos(this.Handle, new IntPtr(-1), 0, 0, 0, 0, TOPMOST_FLAGS);
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}