using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
 

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class Form1 : Form
    {
        OracleConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void updateGrid()
        {
            try
            {
                con.Open();
                OracleCommand getParticipants = con.CreateCommand();
                getParticipants.CommandText = "SELECT * FROM PARTICIPANT_REGISTRATION";
                getParticipants.CommandType = CommandType.Text;
                OracleDataReader participantReader = getParticipants.ExecuteReader();
                DataTable participantTable = new DataTable();
                participantTable.Load(participantReader);
                dataGridView1.DataSource = participantTable;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string conStr = @"DATA SOURCE=localhost:1521/xe;User ID=abc;PASSWORD=abc";
                con = new OracleConnection(conStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            updateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand insertParticipant = con.CreateCommand();
                insertParticipant.CommandText = "INSERT INTO PARTICIPANT_REGISTRATION " +
                                                "(PART_ID, PART_NAME, CNIC, EMAIL, CONTACT, LOCATION) " +
                                                "VALUES " +
                                                "(:partId, :partName, :cnic, :email, :contact, :location)";

                insertParticipant.Parameters.Add(":partId", OracleDbType.Int32).Value = int.Parse(textBox1.Text);
                insertParticipant.Parameters.Add(":partName", OracleDbType.Varchar2, 50).Value = textBox2.Text;
                insertParticipant.Parameters.Add(":cnic", OracleDbType.Int64).Value = long.Parse(textBox3.Text);
                insertParticipant.Parameters.Add(":email", OracleDbType.Varchar2, 50).Value = textBox4.Text;
                insertParticipant.Parameters.Add(":contact", OracleDbType.Varchar2, 20).Value = textBox5.Text;
                insertParticipant.Parameters.Add(":location", OracleDbType.Varchar2, 50).Value = textBox6.Text;

                insertParticipant.CommandType = CommandType.Text;
                int rows = insertParticipant.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Data Inserted Successfully");
                    updateGrid(); // Update the grid after successful insertion
                }
                else
                {
                    MessageBox.Show("No rows affected. Insertion might have failed.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid input for {ex.TargetSite.Name}. Please enter valid data for numeric fields.");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MANU M = new MANU();
            M.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int eventId;

            if (!int.TryParse(textBox1.Text, out eventId))
            {
                MessageBox.Show("Please enter a valid Event ID.");
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection("Data Source=localhost:1521/xe;User ID=abc;Password=abc"))
                {
                    using (OracleCommand deleteEvent = con.CreateCommand())
                    {
                        deleteEvent.CommandText = "DELETE FROM PARTICIPANT_REGISTRATION  WHERE part_id = :eventId";
                        deleteEvent.Parameters.Add(":eventId", OracleDbType.Int32).Value = eventId;

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

        private void button3_Click(object sender, EventArgs e)
        {
            int partId;

            if (!int.TryParse(textBox1.Text, out partId))
            {
                MessageBox.Show("Please enter a valid Participant ID.");
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection("Data Source=localhost:1521/xe;User ID=abc;Password=abc"))
                {
                    using (OracleCommand updateParticipant = con.CreateCommand())
                    {
                        updateParticipant.CommandText = "UPDATE PARTICIPANT_REGISTRATION " +
                                                        "SET PART_NAME = :partName, " +
                                                        "CNIC = :cnic, " +
                                                        "EMAIL = :email, " +
                                                        "CONTACT = :contact, " +
                                                        "LOCATION = :location " +
                                                        "WHERE PART_ID = :partId";

                        updateParticipant.Parameters.Add(":partName", OracleDbType.Varchar2, 50).Value = textBox2.Text;
                        updateParticipant.Parameters.Add(":cnic", OracleDbType.Int64).Value = long.Parse(textBox3.Text);
                        updateParticipant.Parameters.Add(":email", OracleDbType.Varchar2, 50).Value = textBox4.Text;
                        updateParticipant.Parameters.Add(":contact", OracleDbType.Varchar2, 20).Value = textBox5.Text;
                        updateParticipant.Parameters.Add(":location", OracleDbType.Varchar2, 50).Value = textBox6.Text;
                        updateParticipant.Parameters.Add(":partId", OracleDbType.Int32).Value = partId;

                        con.Open();
                        int rowsUpdated = updateParticipant.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Data Updated Successfully");
                            updateGrid(); // Update the grid after successful update
                        }
                        else
                        {
                            MessageBox.Show("No rows found with that Participant ID.");
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

        private void HEADING_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
