using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class Speaker : Form
    {
        OracleConnection con;

        public Speaker()
        {
            InitializeComponent();
            string conStr = @"DATA SOURCE=localhost:1521/xe;User ID=abc;PASSWORD=abc";
            con = new OracleConnection(conStr);
            updateGrid();
        }
        private void updateGrid()
        {
            try
            {
                con.Open();
                OracleCommand getEvents = con.CreateCommand();
                getEvents.CommandText = "SELECT * FROM SPEAKER_TABLE";
                getEvents.CommandType = CommandType.Text;
                OracleDataReader eventReader = getEvents.ExecuteReader();
                DataTable eventTable = new DataTable();
                eventTable.Load(eventReader);
                dataGridView1.DataSource = eventTable;
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error while fetching data: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand insertSpeaker = con.CreateCommand();
                insertSpeaker.CommandText = "INSERT INTO SPEAKER_TABLE " +
                                            "(SPEAKER_ID, SPEAKER_NAME, EMAIL, PHONE_NUMBER, SPECIALIZATION, AVAILABILITY) " +
                                            "VALUES " +
                                            "(:speakerId, :speakerName, :email, :phoneNumber, :specialization, :availability)";

                insertSpeaker.Parameters.Add(":speakerId", OracleDbType.Int32).Value = int.Parse(textBox1.Text);
                insertSpeaker.Parameters.Add(":speakerName", OracleDbType.Varchar2, 100).Value = textBox2.Text;
                insertSpeaker.Parameters.Add(":email", OracleDbType.Varchar2, 100).Value = textBox3.Text;
                insertSpeaker.Parameters.Add(":phoneNumber", OracleDbType.Varchar2, 20).Value = textBox4.Text;
                insertSpeaker.Parameters.Add(":specialization", OracleDbType.Varchar2, 100).Value = textBox5.Text;
                insertSpeaker.Parameters.Add(":availability", OracleDbType.Varchar2, 100).Value = textBox6.Text;

                insertSpeaker.CommandType = CommandType.Text;
                int rows = insertSpeaker.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("No rows affected. Insertion might have failed.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input. Please enter valid data for numeric fields.");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error while inserting data: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MANU M = new MANU();
            M.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int eventId;

            if (!int.TryParse(textBox1.Text, out eventId))
            {
                MessageBox.Show("Please enter a Speaker ID.");
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection("Data Source=localhost:1521/xe;User ID=abc;Password=abc"))
                {
                    using (OracleCommand deleteEvent = con.CreateCommand())
                    {
                        deleteEvent.CommandText = "DELETE FROM Speaker_Table WHERE speaker_id = :eventid";
                        deleteEvent.Parameters.Add(":eventid", OracleDbType.Int32).Value = eventId;

                        con.Open();
                        int rowsDeleted = deleteEvent.ExecuteNonQuery();

                        if (rowsDeleted > 0)
                        {
                            MessageBox.Show("Successfully Deleted!");
                            updateGrid();
                        }
                        else
                        {
                            MessageBox.Show("No rows found with that Event ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting data: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int speakerId;

            if (!int.TryParse(textBox1.Text, out speakerId))
            {
                MessageBox.Show("Please enter a valid Speaker ID.");
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection("Data Source=localhost:1521/xe;User ID=abc;Password=abc"))
                {
                    using (OracleCommand updateSpeaker = con.CreateCommand())
                    {
                        updateSpeaker.CommandText = "UPDATE SPEAKER_TABLE " +
                                                    "SET SPEAKER_NAME = :speakerName, " +
                                                    "EMAIL = :email, " +
                                                    "PHONE_NUMBER = :phoneNumber, " +
                                                    "SPECIALIZATION = :specialization, " +
                                                    "AVAILABILITY = :availability " +
                                                    "WHERE SPEAKER_ID = :speakerId";

                        updateSpeaker.Parameters.Add(":speakerName", OracleDbType.Varchar2, 100).Value = textBox2.Text;
                        updateSpeaker.Parameters.Add(":email", OracleDbType.Varchar2, 100).Value = textBox3.Text;
                        updateSpeaker.Parameters.Add(":phoneNumber", OracleDbType.Varchar2, 20).Value = textBox4.Text;
                        updateSpeaker.Parameters.Add(":specialization", OracleDbType.Varchar2, 100).Value = textBox5.Text;
                        updateSpeaker.Parameters.Add(":availability", OracleDbType.Varchar2, 100).Value = textBox6.Text;
                        updateSpeaker.Parameters.Add(":speakerId", OracleDbType.Int32).Value = speakerId;

                        con.Open();
                        int rowsUpdated = updateSpeaker.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Data Updated Successfully");
                            updateGrid(); // Update the grid after successful update
                        }
                        else
                        {
                            MessageBox.Show("No rows found with that Speaker ID.");
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid input for {ex.TargetSite.Name}. Please enter valid data.");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error while updating data: " + ex.Message);
            }
        }

        private void Speaker_Load(object sender, EventArgs e)
        {

        }
    }
}
