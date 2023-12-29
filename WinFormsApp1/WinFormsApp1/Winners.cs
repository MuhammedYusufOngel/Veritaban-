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
    public partial class Winners : Form
    {
        public Winners()
        {
            InitializeComponent();
        }

        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");

        private void Winners_Load(object sender, EventArgs e)
        {
            con.Open();


            NpgsqlCommand cmd = new NpgsqlCommand("SELECT *from winnerdriver()", con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["ad"].ToString();
                item.SubItems.Add(reader["soyad"].ToString());
                item.SubItems.Add(reader["aracno"].ToString());
                item.SubItems.Add(reader["pistad"].ToString());
                listView1.Items.Add(item);
            }

            con.Close();


            con.Open();


            NpgsqlCommand cmdTeam = new NpgsqlCommand("SELECT *from winnerteam()", con);
            NpgsqlDataReader readerTeam = cmdTeam.ExecuteReader();

            while (readerTeam.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = readerTeam["pistad"].ToString();
                item.SubItems.Add(readerTeam["aracno"].ToString());
                item.SubItems.Add(readerTeam["takimad"].ToString());
                listView2.Items.Add(item);
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Races races = new Races();
            races.Show();
            this.Hide();
        }
    }
}
