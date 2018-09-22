using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.databaseDataSet.Table);

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("D:/5semproject/" + textbox.Text+".pdf", FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
            }
            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int k =0; k < dataGridView1.Columns.Count; k++) {

                    if (dataGridView1[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1[k,i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }
    }
}
