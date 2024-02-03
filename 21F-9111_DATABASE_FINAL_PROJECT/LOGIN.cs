using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class LOGIN : Form
    {
        OracleConnection con;

        public LOGIN()
        {
            InitializeComponent();
            string conStr = @"DATA SOURCE=localhost:1521/xe;User ID=abc;PASSWORD=abc";
            con = new OracleConnection(conStr);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Login(username, password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Login(username, password);
         
        }

        private void Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("Login successful");
                MANU M = new MANU();
                M.ShowDialog();

                // Hide the current login form after successfully logging in and showing the next form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void FillTables()
        {
            try
            {
                con.Open();

                // Insert initial data into SPEAKER_TABLE
                OracleCommand insertSpeaker = con.CreateCommand();
                insertSpeaker.CommandText = "INSERT INTO SPEAKER_TABLE (SPEAKER_ID, SPEAKER_NAME, EMAIL, PHONE_NUMBER, SPECIALIZATION, AVAILABILITY) VALUES " +
                                            "(1, 'Speaker1', 'speaker1@example.com', '1234567890', 'Specialization1', 'Available'), " +
                                            "(2, 'Speaker2', 'speaker2@example.com', '0987654321', 'Specialization2', 'Unavailable')";
                insertSpeaker.ExecuteNonQuery();

                // Insert initial data into PARTICIPANT_REGISTRATION
                OracleCommand insertParticipant = con.CreateCommand();
                insertParticipant.CommandText = "INSERT INTO PARTICIPANT_REGISTRATION (PART_ID, PART_NAME, CNIC, EMAIL, CONTACT, LOCATION) VALUES " +
                                                "(1, 'Participant1', 123456789012345, 'participant1@example.com', '1234567890', 'Location1'), " +
                                                "(2, 'Participant2', 987654321098765, 'participant2@example.com', '0987654321', 'Location2')";
                insertParticipant.ExecuteNonQuery();

                // Insert initial data into EVANT
                OracleCommand insertEvent = con.CreateCommand();
                insertEvent.CommandText = "INSERT INTO EVANT (EVENT_ID, EVENT_NAME, DESCRIPTION, EVENT_DATE, LOCATION, DURATION) VALUES " +
                                          "(1, 'Event1', 'Description1', TO_DATE('20230101', 'YYYYMMDD'), 'Location1', 'Duration1'), " +
                                          "(2, 'Event2', 'Description2', TO_DATE('20230202', 'YYYYMMDD'), 'Location2', 'Duration2'), " +
                                          "(3, 'Event3', 'Description3', TO_DATE('20230303', 'YYYYMMDD'), 'Location3', 'Duration3'), " +
                                          "(4, 'Event4', 'Description4', TO_DATE('20230404', 'YYYYMMDD'), 'Location4', 'Duration4')";
                insertEvent.ExecuteNonQuery();

                MessageBox.Show("Tables populated with initial data");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error populating tables: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        // Other methods or event handlers can be added here

    }
}
