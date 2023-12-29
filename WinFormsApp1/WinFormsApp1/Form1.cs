namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Drivers drivers = new Drivers();
            drivers.Show();
            this.Hide();
        }

        private void btn_teams_Click(object sender, EventArgs e)
        {
            Teams teams = new Teams();
            teams.Show();
            this.Hide();
        }

        private void btn_races_Click(object sender, EventArgs e)
        {
            Races races = new Races();
            races.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pastChampions pastChampions = new pastChampions();
            pastChampions.Show();
            this.Hide();
        }

        private void btn_champ_Click(object sender, EventArgs e)
        {
            championshipResult championshipResult = new championshipResult();
            championshipResult.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeMansWinners leMansWinners = new LeMansWinners();
            leMansWinners.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manufacturers manufacturers = new Manufacturers();
            manufacturers.Show();
            this.Hide();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            Winners winners = new Winners();
            winners.Show();
            this.Hide();
        }
    }
}