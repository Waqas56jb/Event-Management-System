using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Oracle.ManagedDataAccess.Client; // Import the Oracle Managed Data Access namespace

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class report_genrate : Form
    {
        OracleConnection con;

        public report_genrate()
        {
            InitializeComponent();
            string conStr = @"DATA SOURCE=localhost:1521/xe; User ID=abc; PASSWORD=abc";
            con = new OracleConnection(conStr);
        }

        private void report_genrate_Load(object sender, EventArgs e)
        {
            // Load your data into a DataTable here
            DataTable dataTable = GetDataTableFromDatabase();
            dataGridView1.DataSource = dataTable; // Displaying the data in a DataGridView for testing purposes
        }

        private DataTable GetDataTableFromDatabase()
        {
            DataTable dataTable = new DataTable();

            try
            {
                con.Open();
                string query = "SELECT PART_MANG, SESION, PAYMENT, ATTENDANCE, FEEDBACK FROM PARTICIPANT_MANAGEMENT";
                OracleDataAdapter adapter = new OracleDataAdapter(query, con);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = GetDataTableFromDatabase();

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "ParticipantManagementReport.pdf");

                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
                foreach (DataColumn column in dataTable.Columns)
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(column.ColumnName)));
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        pdfTable.AddCell(new PdfPCell(new Phrase(item.ToString())));
                    }
                }

                doc.Add(pdfTable);
                doc.Close();

                MessageBox.Show("PDF generated successfully! Saved to desktop.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MANU M = new MANU();
            M.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
