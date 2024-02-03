using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class EVENT : Form
    {
        OracleConnection con;

        public EVENT()
        {
            InitializeComponent();
        }

        private void updateGrid()
        {
            try
            {
                con.Open();
                OracleCommand getEvents = con.CreateCommand();
                getEvents.CommandText = "SELECT * FROM EVANT";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string conStr = @"DATA SOURCE=localhost:1521/xe; User ID=abc; PASSWORD=abc";
                con = new OracleConnection(conStr);
                updateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MANU M = new MANU();
            M.ShowDialog();
        }

        // Inside button2_Click for Delete button
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
                        deleteEvent.CommandText = "DELETE FROM EVANT WHERE EVENT_ID = :eventId";
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                    using (OracleCommand updateEvent = con.CreateCommand())
                    {
                        updateEvent.CommandText = "UPDATE EVANT " +
                                                  "SET EVENT_NAME = :eventName, " +
                                                  "DESCRIPTION = :description, " +
                                                  "EVENT_DATE = :eventDate, " +
                                                  "LOCATION = :location, " +
                                                  "DURATION = :duration " +
                                                  "WHERE EVENT_ID = :eventId";

                        updateEvent.Parameters.Add(":eventName", OracleDbType.Varchar2, 50).Value = textBox2.Text;
                        updateEvent.Parameters.Add(":description", OracleDbType.Varchar2, 50).Value = textBox3.Text;
                        updateEvent.Parameters.Add(":eventDate", OracleDbType.Date).Value = DateTime.Parse(textBox4.Text);
                        updateEvent.Parameters.Add(":location", OracleDbType.Varchar2, 50).Value = textBox5.Text;
                        updateEvent.Parameters.Add(":duration", OracleDbType.Varchar2, 10).Value = textBox6.Text;
                        updateEvent.Parameters.Add(":eventId", OracleDbType.Int32).Value = eventId;

                        con.Open();
                        int rowsUpdated = updateEvent.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Data Updated Successfully");
                            updateGrid(); // Update the grid after successful update
                        }
                        else
                        {
                            MessageBox.Show("No rows found with that Event ID.");
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

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                OracleCommand insertEvent = con.CreateCommand();
                insertEvent.CommandText = "INSERT INTO EVANT " +
                                            "(EVENT_ID, EVENT_NAME, DESCRIPTION, EVENT_DATE, LOCATION, DURATION) " +
                                            "VALUES " +
                                            "(:eventId, :eventName, :description, :eventDate, :location, :duration)";

                insertEvent.Parameters.Add(":eventId", OracleDbType.Int32).Value = int.Parse(textBox1.Text);
                insertEvent.Parameters.Add(":eventName", OracleDbType.Varchar2, 50).Value = textBox2.Text;
                insertEvent.Parameters.Add(":description", OracleDbType.Varchar2, 50).Value = textBox3.Text;
                insertEvent.Parameters.Add(":eventDate", OracleDbType.Date).Value = DateTime.Parse(textBox4.Text);
                insertEvent.Parameters.Add(":location", OracleDbType.Varchar2, 50).Value = textBox5.Text;
                insertEvent.Parameters.Add(":duration", OracleDbType.Varchar2, 10).Value = textBox6.Text;

                int rows = insertEvent.ExecuteNonQuery();

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
                MessageBox.Show($"Invalid input for {ex.TargetSite.Name}. Please enter valid data.");
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
    }
}
