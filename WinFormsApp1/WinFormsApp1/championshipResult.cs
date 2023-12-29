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
    public partial class championshipResult : Form
    {
        public championshipResult()
        {
            InitializeComponent();
        }

        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");

        private void championshipResult_Load(object sender, EventArgs e)
        {
            con.Open();


            NpgsqlCommand cmd = new NpgsqlCommand("SELECT number, drivers.name, surname, \"teamName\", points from \"champResult\"\r\n\tinner join vehicle on vehicle.\"vehicleID\" = \"champResult\".\"vehicleID\"\r\n\tinner join drivers on drivers.\"vehicleID\" = \"champResult\".\"vehicleID\"\r\n\tinner join teams on teams.\"teamID\" = vehicle.\"teamID\"\r\n\t\r\n\torder by points DESC", con);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["number"].ToString();
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["surname"].ToString());
                item.SubItems.Add(reader["teamName"].ToString());
                item.SubItems.Add(reader["points"].ToString());
                listView1.Items.Add(item);
            }

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
