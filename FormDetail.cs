using Npgsql;
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
    public partial class FormDetail : Form
    {
        tabel_laptop laptop;
        tabel_pelanggan pelanggan;

        void laptop_FormClosed(object sender, FormClosedEventArgs e)
        {
            laptop = null;
            pelanggan = null;
        }

            void bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        void tampilkan()
        {
            var str = "server=localhost; port=5432; user id=postgres; database=gulam; password=terangbenderang";
            NpgsqlConnection conn = new NpgsqlConnection(str);
            conn.Open();

            var sql = "select * from detail_transaksi";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            var dataReader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dataReader);

            conn.Close();

            dataGridView1.DataSource = dt;
        }
        public FormDetail()
        {
            InitializeComponent();
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {
            tampilkan();
            bersihkan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" ||
               textBox2.Text.Trim() == "" ||
               textBox3.Text.Trim() == "" ||
               textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Data belum diinput !");
            }
            else
            {
                try
                {
                    var str = "server=localhost; port=5432; user id=postgres; database=gulam; password=terangbenderang";
                    NpgsqlConnection conn = new NpgsqlConnection(str);
                    conn.Open();

                    var ins2 = "insert into detail_transaksi values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

                    NpgsqlCommand cmd = new NpgsqlCommand(ins2, conn);
                    var dataReader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dataReader);

                    MessageBox.Show("Insert Data Berhasil !");
                    tampilkan();
                    bersihkan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tolong Masukkan Nama Pelanggan atau Laptop yang Sesuai !");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var str = "server=localhost; port=5432; user id=postgres; database=gulam; password=terangbenderang";
                NpgsqlConnection conn = new NpgsqlConnection(str);
                conn.Open();

                var update = "update detail_transaksi set transaksi='" + textBox2.Text + "',laptop_dibeli='" + textBox3.Text + "',sisa_stok='" + textBox4.Text + "'where id_detail_transaksi='" + textBox1.Text + "'";

                NpgsqlCommand cmd = new NpgsqlCommand(update, conn);
                var dataReader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dataReader);

                MessageBox.Show("Data Berhasil diUpdate !");
                tampilkan();
                bersihkan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Data Harus Menyesuaikan Nama Pelanggan dan Laptop !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Yakin mau menghapus " + textBox2.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var str = "server=localhost; port=5432; user id=postgres; database=gulam; password=terangbenderang";
                    NpgsqlConnection conn = new NpgsqlConnection(str);
                    conn.Open();

                    var delete = "delete from detail_transaksi where id_detail_transaksi='" + textBox1.Text + "'";

                    NpgsqlCommand cmd = new NpgsqlCommand(delete, conn);
                    var dataReader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dataReader);

                    MessageBox.Show("Data Berhasil diHapus !");
                    tampilkan();
                    bersihkan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pelanggan == null)
            {
                pelanggan = new tabel_pelanggan();
                pelanggan.FormClosed += new FormClosedEventHandler(laptop_FormClosed);
                pelanggan.Show();
            }
            else
            {
                pelanggan.Activate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (laptop == null)
            {
                laptop = new tabel_laptop();
                laptop.FormClosed += new FormClosedEventHandler(laptop_FormClosed);
                laptop.Show();
            }
            else
            {
                laptop.Activate();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_detail_transaksi"].Value.ToString();
                textBox2.Text = row.Cells["transaksi"].Value.ToString();
                textBox3.Text = row.Cells["laptop_dibeli"].Value.ToString();
                textBox4.Text = row.Cells["sisa_stok"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
