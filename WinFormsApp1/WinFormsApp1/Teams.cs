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
    public partial class Teams : Form
    {
        public Teams()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");

        private void Teams_Load(object sender, EventArgs e)
        {
            showsData();
        }

        void showsData()
        {
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("Select \"teamName\",name from teams " +
                "INNER JOIN manufacturers ON manufacturers.\"manuID\" = teams.\"manuID\"", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["teamName"].ToString();
                item.SubItems.Add(reader["name"].ToString());
                listViewDriver.Items.Add(item);
            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
