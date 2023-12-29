using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WinFormsApp1
{
    public partial class raceWeekend : Form
    {
        int raceID = 0;
        public raceWeekend(int raceID)
        {
            InitializeComponent();

            this.raceID = raceID;
        }

        NpgsqlConnection con = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;password=password123;Database=WorldEndChamp");

        void decreaseParticipantsTrig()
        {
            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("create or replace function decreasenumberofparticipant() " +
                "returns trigger " +
                "as " +
                "$$ " +
                "BEGIN " +
                "update track set participants=participants-1 where \"trackID\" =" + raceID + ";" +
                "RETURN NEW;" +
                "END;" +
                "$$" +
                "language plpgsql", con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        void increaseParticipantsTrig()
        {
            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("create or replace function numberofparticipant() " +
                "returns trigger " +
                "as " +
                "$$ " +
                "BEGIN " +
                "update track set participants=participants+1 where \"trackID\" =" + raceID + ";" +
                "RETURN NEW;" +
                "END;" +
                "$$" +
                "language plpgsql", con);

            cmd.ExecuteNonQuery();

            con.Close();
        }


        void decreasePointsTrig()
        {
            int pastPoints = getPastPoints();
            int totalTime = getTotalTime();
            int realID = numbertoVehicleID();

            con.Open();

            NpgsqlCommand command = new NpgsqlCommand("create or replace function decreasepoints() " +
                "returns trigger " +
                "as " +
                "$$ " +
                "begin " +
                "update \"champResult\" set points=" + pastPoints + " - " +
                                            "(" +
                                            "Select points from races " +
                                            "INNER JOIN sessions on sessions.\"sessionID\" = races.\"sessionID\" " +
                                            "INNER JOIN position on position.\"positionID\" = races.\"positionID\" " +
                                            "INNER JOIN track on track.\"trackID\" = sessions.\"trackID\" " +
                                            "INNER JOIN \"totalTime\" on \"totalTime\".\"totalTimeID\" = track.\"totalTimeID\" " +
                                            "where sessions.\"vehicleID\" = " + realID + " " +
                                            "AND sessions.\"trackID\" = " + raceID + " " +
                                            "AND \"totalTime\".\"totalTimeID\" = " + totalTime + 
                                            ") " +
                                            "where \"champResult\".\"vehicleID\" = " + realID + "; " +

                "return new; " +
                "end; " +
                "$$ " +
                "language plpgsql;", con);

            command.ExecuteNonQuery();

            con.Close();
        }

        void increasePointsTrig()
        {
            int pastPoints = getPastPoints();
            int totalTime = getTotalTime();
            int realID = numbertoVehicleID();

            con.Open();

            NpgsqlCommand command = new NpgsqlCommand("create or replace function increasepoints() " +
                "returns trigger " +
                "as " +
                "$$ " +
                "begin " +
                "update \"champResult\" set points=" + pastPoints + " + " +
                                            "(" +
                                            "Select points from races " +
                                            "INNER JOIN sessions on sessions.\"sessionID\" = races.\"sessionID\" " +
                                            "INNER JOIN position on position.\"positionID\" = races.\"positionID\" " +
                                            "INNER JOIN track on track.\"trackID\" = sessions.\"trackID\" " +
                                            "INNER JOIN \"totalTime\" on \"totalTime\".\"totalTimeID\" = track.\"totalTimeID\" " +
                                            "where sessions.\"vehicleID\" = " + realID + " AND sessions.\"trackID\" = " + raceID + " AND position = " + txt_position.Text + " AND \"totalTime\".\"totalTimeID\" = " + totalTime + ") where \"champResult\".\"vehicleID\" = " + realID + "; " +
                "return new; " +
                "end; " +
                "$$ " +
                "language plpgsql;", con);

            command.ExecuteNonQuery();

            con.Close();
        }


        void raceResult()
        {
            con.Open();

            NpgsqlCommand npgDrop = new NpgsqlCommand("DROP TABLE \"raceResult\"", con);

            npgDrop.ExecuteNonQuery();

            con.Close();

            con.Open();

            NpgsqlCommand npgAdd = new NpgsqlCommand("CREATE TABLE \"raceResult\" as SELECT  track.\"trackID\" as \"trackID\", teams.\"teamName\" as \"teamName\", position.position, drivers.name, surname, number, points FROM races\r\n\tinner join sessions on races.\"sessionID\" = sessions.\"sessionID\"\r\n\tinner join vehicle on vehicle.\"vehicleID\" = sessions.\"vehicleID\"\r\n\tinner join drivers on drivers.\"vehicleID\" = vehicle.\"vehicleID\"\r\n\tinner join position on position.\"positionID\" = races.\"positionID\"\r\n\tinner join track on track.\"trackID\" = sessions.\"trackID\"\r\n\tinner join teams on teams.\"teamID\" = vehicle.\"teamID\"", con);

            npgAdd.ExecuteNonQuery();

            con.Close();
        }

        void addSomething()
        {
            int pastPoints = getPastPoints();
            int totalTime = getTotalTime();
            int realID = numbertoVehicleID();

            con.Open();

            NpgsqlCommand command = new NpgsqlCommand("create or replace function addSomething() " +
                "returns trigger " +
                "as " +
                "$$ " +
                "begin " +
                "insert into sessions (\"trackID\", \"vehicleID\", \"totalTimeID\") VALUES (" + raceID + ", " + realID + ", " + totalTime + " );" + 
                "return new; " +
                "end; " +
                "$$ " +
                "language plpgsql;", con);

            command.ExecuteNonQuery();

            con.Close();
        }

        int getSessionID()
        {
            con.Close();

            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("Select \"sessionID\" from sessions order by \"sessionID\" DESC", con);

            NpgsqlDataReader read = cmd.ExecuteReader();

            read.Read();
            int sessionID = read.GetInt32(0);

            con.Close();
        
            return sessionID;
        }

        int getTotalTime()
        {
            con.Open();

            NpgsqlCommand totalTimeCom = new NpgsqlCommand("SELECT \"totalTime\".\"totalTimeID\" from \"totalTime\" " +
                "INNER JOIN track on track.\"totalTimeID\" = \"totalTime\".\"totalTimeID\" where \"trackID\" = " + raceID + "", con);

            NpgsqlDataReader readtime = totalTimeCom.ExecuteReader();

            readtime.Read();
            int totalTime = Convert.ToInt32(readtime["totalTimeID"].ToString());

            con.Close();
            
            return totalTime;
        }

        int getPastPoints()
        {
            int realID = numbertoVehicleID();
            con.Open();

            NpgsqlCommand commandPastPoints = new NpgsqlCommand("SELECT points from \"champResult\" where \"vehicleID\" = " + realID + "", con);

            NpgsqlDataReader readPoints = commandPastPoints.ExecuteReader();

            readPoints.Read();
            int pastPoints = Convert.ToInt32(readPoints["points"].ToString());

            con.Close();

            return pastPoints;
        }

        int numbertoVehicleID()
        {
            con.Open();

            NpgsqlCommand comvehicleID = new NpgsqlCommand("select *from vehicle where number = " + txt_vehicleID.Text, con);

            NpgsqlDataReader read = comvehicleID.ExecuteReader();

            read.Read();

            int realID = read.GetInt32(0);

            con.Close();

            return realID;
        }

        void showRaceWeekendInfo()
        {
            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT *from track where \"trackID\" = " + raceID, con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lbl_trackName.Text = reader["name"].ToString();
                lbl_turns.Text = reader["turns"].ToString();
            }

            con.Close();

            con.Open();

            NpgsqlCommand cmdmil = new NpgsqlCommand("SELECT *from miltokm()", con);
            NpgsqlDataReader readermil = cmdmil.ExecuteReader();

            while(readermil.Read())
            {
                lbl_length.Text = readermil["uzunluk"].ToString();
            }

            con.Close();
        }

        void showSession(int sessionID)
        {
            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT position, number, name, surname, \"teamName\" from sessions " +
                "INNER JOIN vehicle on vehicle.\"vehicleID\" = sessions.\"vehicleID\"" +
                "INNER JOIN drivers on drivers.\"vehicleID\" = sessions.\"vehicleID\" " +
                "INNER JOIN teams on vehicle.\"teamID\" = teams.\"teamID\" where \"trackID\" = " + raceID +" AND \"sessionTypeID\" = " + sessionID, con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["position"].ToString();
                item.SubItems.Add(reader["number"].ToString());
                item.SubItems.Add(reader["name"].ToString() + " " + reader["surname"].ToString());
                item.SubItems.Add(reader["teamName"].ToString());
                list_p1.Items.Add(item);
            }

            con.Close();
        }

        void showRace()
        {
            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT position, number, name, surname, \"teamName\", points, \"trackID\" from races " 
                + "INNER JOIN sessions on sessions.\"sessionID\" = races.\"sessionID\" " +
                " INNER JOIN vehicle on vehicle.\"vehicleID\" = sessions.\"vehicleID\" "+ 
                " INNER JOIN drivers on drivers.\"vehicleID\" = sessions.\"vehicleID\" " +
                " INNER JOIN position on position.\"positionID\" = races.\"positionID\" "+ 
                "INNER JOIN teams on vehicle.\"teamID\" = teams.\"teamID\" where \"trackID\" = " + raceID, con);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["position"].ToString();
                item.SubItems.Add(reader["number"].ToString());
                item.SubItems.Add(reader["name"].ToString() + " " + reader["surname"].ToString());
                item.SubItems.Add(reader["teamName"].ToString());
                item.SubItems.Add(reader["points"].ToString());
                list_race.Items.Add(item);
            }

            con.Close();
        }

        private void raceWeekend_Load(object sender, EventArgs e)
        {
            showRaceWeekendInfo();
            /*showSession(1);
            showSession(2);
            showSession(3);
            showSession(4);*/
            showRace();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            increaseParticipantsTrig();
            increasePointsTrig();
            addSomething();
            int sessionID = getSessionID();
            sessionID++;
            int totalTime = getTotalTime();
            int realID = numbertoVehicleID();

            con.Open();

            NpgsqlCommand positionCom = new NpgsqlCommand("SELECT \"position\".\"positionID\" from \"position\" " +
                "INNER JOIN \"totalTime\" on \"totalTime\".\"totalTimeID\" = \"position\".\"totalTimeID\" where \"totalTime\".\"totalTimeID\" = " + totalTime + " AND position = " + txt_position.Text, con);

            NpgsqlDataReader readID = positionCom.ExecuteReader();

            readID.Read();
            int readPositionID = Convert.ToInt32(readID["positionID"].ToString());

            con.Close();


            //ekle yarışlar
            con.Open();

            NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into races (\"positionID\", \"sessionID\") values (" + readPositionID +", " + sessionID + ")", con);

            npgsqlCommand.ExecuteNonQuery();

            con.Close();

            raceResult();

            txt_position.Clear();
            txt_vehicleID.Clear();
            list_race.Items.Clear();
            showRace();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Races races = new Races();
            races.Show();
            this.Hide();
        }

        private void list_race_DoubleClick(object sender, EventArgs e)
        {
            txt_vehicleID.Text = list_race.SelectedItems[0].SubItems[1].Text;
            textBox1.Text = list_race.SelectedItems[0].SubItems[2].Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            decreaseParticipantsTrig();
            decreasePointsTrig();
            int realID = numbertoVehicleID();

            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("delete from races where \"sessionID\" = (Select \"sessionID\" from sessions where sessions.\"vehicleID\"= " + realID +" AND sessions.\"trackID\" = " + raceID +");", con);
            cmd.Parameters.AddWithValue("@\"vehicleID\"", realID);
            cmd.ExecuteNonQuery();
            
            con.Close();

            txt_vehicleID.Clear();
            list_race.Items.Clear();
            showRace();
        }

        private void list_p1_DoubleClick(object sender, EventArgs e)
        {
            txt_vehicleID.Text = list_p1.SelectedItems[0].SubItems[1].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("update \"raceResult\" set name='" + textBox1.Text + "' where number = " + txt_vehicleID.Text, con);
            com.ExecuteNonQuery();

            con.Close();

            list_race.Items.Clear();


            con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT position, number, name, surname, \"teamName\", points from \"raceResult\" where \"trackID\" = " + raceID + " order by position", con);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["position"].ToString();
                item.SubItems.Add(reader["number"].ToString());
                item.SubItems.Add(reader["name"].ToString() + " " + reader["surname"].ToString());
                item.SubItems.Add(reader["teamName"].ToString());
                item.SubItems.Add(reader["points"].ToString());
                list_race.Items.Add(item);
            }

            con.Close();
        }
    }
}
