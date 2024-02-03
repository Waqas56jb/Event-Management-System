using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class Participient_Management : Form
    {
        OracleConnection con;

        public Participient_Management()
        {
            InitializeComponent();
        }

        private void updateGrid()
        {
            try
            {
                con.Open();
                OracleCommand getpart = con.CreateCommand();
                getpart.CommandText = "SELECT * FROM PARTICIPANT_MANAGEMENT";
                getpart.CommandType = CommandType.Text;
                OracleDataReader empDR = getpart.ExecuteReader();
                DataTable empDT = new DataTable();
                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Participient_Management_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=localhost:1521/xe;User ID=abc;Password=abc";
            con = new OracleConnection(constr);
            updateGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand insertPart = con.CreateCommand();
                insertPart.CommandText = "INSERT INTO PARTICIPANT_MANAGEMENT " +
                    "(part_mang, sesion, payment, attendance, feedback) " +
                    "VALUES " +
                    "(:part_mang, :sesion, :payment, :attendance, :feedback)";

                insertPart.Parameters.Add(":part_mang", OracleDbType.Int32).Value = int.Parse(textBox6.Text);
                insertPart.Parameters.Add(":sesion", OracleDbType.Int32).Value = int.Parse(textBox1.Text);
                insertPart.Parameters.Add(":payment", OracleDbType.Int32).Value = int.Parse(textBox2.Text);
                insertPart.Parameters.Add(":attendance", OracleDbType.Int32).Value = int.Parse(textBox3.Text);
                insertPart.Parameters.Add(":feedback", OracleDbType.Varchar2).Value = textBox4.Text;

                int rows = insertPart.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Inserted Successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                updateGrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
       MANU M = new MANU();
            M.ShowDialog();
        }

        // Inside button2_Click for Delete button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection("Data Source=localhost:1521/xe;User ID=abc;Password=abc"))
                {
                    con.Open();
                    using (OracleCommand deleteEvent = con.CreateCommand())
                    {
                        deleteEvent.CommandText = "DELETE FROM PARTICIPANT_MANAGEMENT WHERE PART_MANG = :Partmang";
                        deleteEvent.Parameters.Add(":Partmang", OracleDbType.Int32).Value = int.Parse(textBox6.Text);

                        int rowsDeleted = deleteEvent.ExecuteNonQuery();

                        if (rowsDeleted > 0)
                        {
                            MessageBox.Show("Successfully Deleted!");
                            updateGrid();
                        }
                        else
                        {
                            MessageBox.Show("No rows found with that Part_Mang.");
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid input for {ex.TargetSite.Name}. Please enter a valid Event ID.");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error while deleting data: " + ex.Message);
            }
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int partMang;

            if (!int.TryParse(textBox6.Text, out partMang))
            {
                MessageBox.Show("Please enter a valid PART_MANG value.");
                return;
            }

            try
            {
                using (OracleConnection con = new OracleConnection("Data Source=localhost:1521/xe;User ID=abc;Password=abc"))
                {
                    using (OracleCommand updatePart = con.CreateCommand())
                    {
                        updatePart.CommandText = "UPDATE PARTICIPANT_MANAGEMENT " +
                                                "SET SESION = :sesion, " +
                                                "PAYMENT = :payment, " +
                                                "ATTENDANCE = :attendance, " +
                                                "FEEDBACK = :feedback " +
                                                "WHERE PART_MANG = :partMang";

                        updatePart.Parameters.Add(":sesion", OracleDbType.Int32).Value = int.Parse(textBox1.Text);
                        updatePart.Parameters.Add(":payment", OracleDbType.Int32).Value = int.Parse(textBox2.Text);
                        updatePart.Parameters.Add(":attendance", OracleDbType.Int32).Value = int.Parse(textBox3.Text);
                        updatePart.Parameters.Add(":feedback", OracleDbType.Varchar2, 50).Value = textBox4.Text;
                        updatePart.Parameters.Add(":partMang", OracleDbType.Int32).Value = partMang;

                        con.Open();
                        int rowsUpdated = updatePart.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Data Updated Successfully");
                            updateGrid(); // Update the grid after successful update
                        }
                        else
                        {
                            MessageBox.Show("No rows found with that PART_MANG.");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // Other event handlers...
    }
}
