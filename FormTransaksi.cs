using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belajar_koneksi
{
    public partial class FormTransaksi : Form
    {
        FormLaptop laptop;
        FormPelanggan pelanggan;
        FormDetail detail;

        void laptop_FormClosed(object sender, FormClosedEventArgs e)
        {
            laptop = null;
            pelanggan = null;
            detail = null; 
        }
        public FormTransaksi()
        {
            InitializeComponent();
        }

        private void laptopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(laptop == null)
            {
                laptop = new FormLaptop();
                laptop.FormClosed += new FormClosedEventHandler(laptop_FormClosed);
                laptop.Show();
            }
            else
            {
                laptop.Activate();
            }
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pelanggan == null)
            {
                pelanggan = new FormPelanggan();
                pelanggan.FormClosed += new FormClosedEventHandler(laptop_FormClosed);
                pelanggan.Show();
            }
            else
            {
                pelanggan.Activate();
            }
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detail == null)
            {
                detail = new FormDetail();
                detail.FormClosed += new FormClosedEventHandler(laptop_FormClosed);
                detail.Show();
            }
            else
            {
                detail.Activate();
            }
        }
    }
}
