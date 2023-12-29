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

namespace WinFormsApp1
{
    public partial class Manufacturers : Form
    {
        public Manufacturers()
        {
            InitializeComponent();
        }

        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");

        private void Manufacturers_Load(object sender, EventArgs e)
        {

            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT \"manuResultID\", name, points from \"manuResult\"\r\n\tinner join manufacturers on manufacturers.\"manuID\" = \"manuResult\".\"manuID\"", con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["manuResultID"].ToString();
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["points"].ToString());
                listView1.Items.Add(item);
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
