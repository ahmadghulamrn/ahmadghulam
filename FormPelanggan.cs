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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Belajar_koneksi
{
    public partial class FormPelanggan : Form
    {
        void bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        void tampilkan()
        {
            var str = "server=localhost; port=5432; user id=postgres; database=gulam; password=terangbenderang";
            NpgsqlConnection conn = new NpgsqlConnection(str);
            conn.Open();

            var sql = "select * from transaksi";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            var dataReader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dataReader);

            conn.Close();

            dataGridView1.DataSource = dt;
        }
        public FormPelanggan()
        {
            InitializeComponent();
        }

        private void FormJual_Load(object sender, EventArgs e)
        {
            bersihkan();
            tampilkan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" ||
              textBox2.Text.Trim() == "")
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

                    var ins = "insert into transaksi values('" + textBox1.Text + "','" + textBox2.Text + "')";

                    NpgsqlCommand cmd = new NpgsqlCommand(ins, conn);
                    var dataReader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dataReader);

                    MessageBox.Show("Insert Data Berhasil !");
                    tampilkan();
                    bersihkan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Yakin mau menghapus " + textBox2.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var str = "server=localhost; port=5432; user id=postgres; database=gulam; password=terangbenderang";
                    NpgsqlConnection conn = new NpgsqlConnection(str);
                    conn.Open();

                    var delete = "delete from transaksi where id_transaksi='" + textBox1.Text + "'";

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_transaksi"].Value.ToString();
                textBox2.Text = row.Cells["identitas_transaksi"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
