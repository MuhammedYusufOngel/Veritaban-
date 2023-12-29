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

namespace WinFormsApp1
{
    public partial class pastChampions : Form
    {
        public pastChampions()
        {
            InitializeComponent();
        }

        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");


        private void pastChampions_Load(object sender, EventArgs e)
        {
            con.Open();


            NpgsqlCommand cmd = new NpgsqlCommand("SELECT year, team, name, surname from \"pastSeasonChampions\" order by year DESC", con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["year"].ToString();
                item.SubItems.Add(reader["team"].ToString());
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["surname"].ToString());
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
