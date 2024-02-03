namespace _21F_9111_DATABASE_FINAL_PROJECT
{
    partial class report_genrate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pARTMANGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sESIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAYMENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTTENDANCEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fEEDBACKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pARTICIPANTMANAGEMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new _21F_9111_DATABASE_FINAL_PROJECT.DataSet1();
            this.pARTICIPANT_MANAGEMENTTableAdapter = new _21F_9111_DATABASE_FINAL_PROJECT.DataSet1TableAdapters.PARTICIPANT_MANAGEMENTTableAdapter();
            this.HEADING = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pARTICIPANTMANAGEMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(526, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDF Export";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pARTMANGDataGridViewTextBoxColumn,
            this.sESIONDataGridViewTextBoxColumn,
            this.pAYMENTDataGridViewTextBoxColumn,
            this.aTTENDANCEDataGridViewTextBoxColumn,
            this.fEEDBACKDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pARTICIPANTMANAGEMENTBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(255, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(808, 299);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pARTMANGDataGridViewTextBoxColumn
            // 
            this.pARTMANGDataGridViewTextBoxColumn.DataPropertyName = "PART_MANG";
            this.pARTMANGDataGridViewTextBoxColumn.HeaderText = "PART_MANG";
            this.pARTMANGDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pARTMANGDataGridViewTextBoxColumn.Name = "pARTMANGDataGridViewTextBoxColumn";
            this.pARTMANGDataGridViewTextBoxColumn.Width = 150;
            // 
            // sESIONDataGridViewTextBoxColumn
            // 
            this.sESIONDataGridViewTextBoxColumn.DataPropertyName = "SESION";
            this.sESIONDataGridViewTextBoxColumn.HeaderText = "SESION";
            this.sESIONDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sESIONDataGridViewTextBoxColumn.Name = "sESIONDataGridViewTextBoxColumn";
            this.sESIONDataGridViewTextBoxColumn.Width = 150;
            // 
            // pAYMENTDataGridViewTextBoxColumn
            // 
            this.pAYMENTDataGridViewTextBoxColumn.DataPropertyName = "PAYMENT";
            this.pAYMENTDataGridViewTextBoxColumn.HeaderText = "PAYMENT";
            this.pAYMENTDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pAYMENTDataGridViewTextBoxColumn.Name = "pAYMENTDataGridViewTextBoxColumn";
            this.pAYMENTDataGridViewTextBoxColumn.Width = 150;
            // 
            // aTTENDANCEDataGridViewTextBoxColumn
            // 
            this.aTTENDANCEDataGridViewTextBoxColumn.DataPropertyName = "ATTENDANCE";
            this.aTTENDANCEDataGridViewTextBoxColumn.HeaderText = "ATTENDANCE";
            this.aTTENDANCEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aTTENDANCEDataGridViewTextBoxColumn.Name = "aTTENDANCEDataGridViewTextBoxColumn";
            this.aTTENDANCEDataGridViewTextBoxColumn.Width = 150;
            // 
            // fEEDBACKDataGridViewTextBoxColumn
            // 
            this.fEEDBACKDataGridViewTextBoxColumn.DataPropertyName = "FEEDBACK";
            this.fEEDBACKDataGridViewTextBoxColumn.HeaderText = "FEEDBACK";
            this.fEEDBACKDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fEEDBACKDataGridViewTextBoxColumn.Name = "fEEDBACKDataGridViewTextBoxColumn";
            this.fEEDBACKDataGridViewTextBoxColumn.Width = 150;
            // 
            // pARTICIPANTMANAGEMENTBindingSource
            // 
            this.pARTICIPANTMANAGEMENTBindingSource.DataMember = "PARTICIPANT_MANAGEMENT";
            this.pARTICIPANTMANAGEMENTBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pARTICIPANT_MANAGEMENTTableAdapter
            // 
            this.pARTICIPANT_MANAGEMENTTableAdapter.ClearBeforeFill = true;
            // 
            // HEADING
            // 
            this.HEADING.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.HEADING.BackColor = System.Drawing.Color.Silver;
            this.HEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HEADING.ForeColor = System.Drawing.SystemColors.Desktop;
            this.HEADING.Location = new System.Drawing.Point(255, 38);
            this.HEADING.Name = "HEADING";
            this.HEADING.Size = new System.Drawing.Size(804, 44);
            this.HEADING.TabIndex = 9;
            this.HEADING.Text = "GENRATE REPORT";
            this.HEADING.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(688, 412);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 48);
            this.button4.TabIndex = 30;
            this.button4.Text = "MANU";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // report_genrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1344, 744);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.HEADING);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "report_genrate";
            this.Text = "report_genrate";
            this.Load += new System.EventHandler(this.report_genrate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pARTICIPANTMANAGEMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource pARTICIPANTMANAGEMENTBindingSource;
        private DataSet1TableAdapters.PARTICIPANT_MANAGEMENTTableAdapter pARTICIPANT_MANAGEMENTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pARTMANGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sESIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAYMENTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTTENDANCEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fEEDBACKDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox HEADING;
        private System.Windows.Forms.Button button4;
    }
}