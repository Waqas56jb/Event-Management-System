using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class Report : Form
    {
        OracleConnection con;

        public Report()
        {
            InitializeComponent();
            string conStr = @"DATA SOURCE=localhost:1521/xe;User ID=ABC;PASSWORD=abc";
            con = new OracleConnection(conStr);
        }

        private void updateGrid()
        {
            try
            {
                con.Open();
                OracleCommand getEvents = con.CreateCommand();
                getEvents.CommandText = "SELECT * FROM EVANT"; // Fetching data specifically from the EVENT table
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
            updateGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MANU M = new MANU();
            M.ShowDialog();
        }

        private void HEADING_TextChanged(object sender, EventArgs e)
        {
            // Add any required functionality when the text changes in HEADING textbox
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event in the DataGridView if needed
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}
