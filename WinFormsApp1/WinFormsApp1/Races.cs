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
    public partial class Races : Form
    {
        public Races()
        {
            InitializeComponent();
        }

        private void btn_sebring_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(1);
            raceWeekend.Show();
            this.Hide();
        }

        private void btn_portimao_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(2);
            raceWeekend.Show();
            this.Hide();
        }

        private void btn_spa_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(3);
            raceWeekend.Show();
            this.Hide();
        }

        private void btn_lemans_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(4);
            raceWeekend.Show();
            this.Hide();
        }

        private void btn_monza_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(5);
            raceWeekend.Show();
            this.Hide();
        }

        private void btn_fuji_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(6);
            raceWeekend.Show();
            this.Hide();
        }

        private void btn_bahrain_Click(object sender, EventArgs e)
        {
            raceWeekend raceWeekend = new raceWeekend(7);
            raceWeekend.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Winners winners = new Winners();
            winners.Show();
            this.Hide();
        }
    }
}
