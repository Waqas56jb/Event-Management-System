using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    public partial class MANU : Form
    {
        public MANU()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EVENT M = new EVENT();
            M.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           Form1 M = new Form1();
            M.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Speaker M = new Speaker();
            
            M.ShowDialog();
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Participient_Management M = new Participient_Management();

            M.ShowDialog();
        }

        private void MANU_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report M = new Report();
            M.ShowDialog(this);

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            report_genrate M = new report_genrate();
            M.ShowDialog();
        }
    }
}
