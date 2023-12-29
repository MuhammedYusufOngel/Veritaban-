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
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");

        private void Drivers_Load(object sender, EventArgs e)
        {
            showsData();
        }

        void showsData()
        {
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("Select name,surname,birthday,country,number from drivers " +
                "INNER JOIN country ON country.\"countryID\" = drivers.\"countryID\"" +
                "INNER JOIN vehicle ON vehicle.\"vehicleID\" = drivers.\"vehicleID\"", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["name"].ToString();
                item.SubItems.Add(reader["surname"].ToString());
                item.SubItems.Add(reader["birthday"].ToString());
                item.SubItems.Add(reader["country"].ToString());
                item.SubItems.Add(reader["number"].ToString());
                listViewDriver.Items.Add(item);
            }
            
            connection.Close();
        }

        private void listViewDriver_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
