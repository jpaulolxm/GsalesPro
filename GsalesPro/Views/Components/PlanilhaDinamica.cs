using BotNetSales.Repository;
using ExcelDataReader;
using GsalesPro.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GsalesPro.Views.Components
{
    public partial class PlanilhaDinamica : UserControl
    {
        public PlanilhaDinamica()
        {
            InitializeComponent();
        }
        private string pathFile = Path.GetTempPath();
        private string fileNameExcel = "\\" +
           DateTime.Now.ToString()
          .Replace("-", "")
          .Replace(":", "")
          .Replace("/", "")
          .Replace(" ", "") + ".csv";

        DataGridViewTextBoxColumn statusNetsales = new DataGridViewTextBoxColumn();
        private void button1_Click(object sender, EventArgs e)
        {
           
            statusNetsales.HeaderText = "HEADER";
            statusNetsales.Name = "STATUS_NETSALES";
            statusNetsales.Width = 150;
           
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Excel (*.xls)|*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            try
                            {
                                dataView.Columns.RemoveAt(0);
                                dataView.Rows.Clear();
                            }
                            catch { }
                           
                            dataView.Columns.Add(statusNetsales);
                            var data = reader.AsDataSet().Tables[0];
                         
                           // data.Rows.RemoveAt(0);
                            dataView.DataSource = data;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                NetSalesManager netSalesManager = new NetSalesManager();
                int indexColumn = dataView.Columns.Count;
                if (await netSalesManager.connect(Settings.Default["user"].ToString(), Settings.Default["password"].ToString()))
                {
                    int index = int.Parse(colun_index.Value.ToString());
                    for (int i = 0; i < dataView.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            dataView[0, i].Value = "STATUS_NETSALES";
                            continue;
                        }
                        string contrato = dataView.Rows[i].Cells[index + 1].Value.ToString();
                        string status = await netSalesManager.consultaContrato(contrato);
                        dataView[0, i].Value = status;
                    }
                    btnExport.Visible = true;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no login, Por favor tente novamente!", "GSales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }       
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
   
        }

        private void export()
        {
            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < dataView.Columns.Count; k++)
            {
                //add separator
                sb.Append(dataView.Columns[k].HeaderText + ";");
            }

            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < dataView.Rows.Count; i++)
            {
                for (int k = 0; k < dataView.Columns.Count; k++)
                {
                    sb.Append(dataView.Rows[i].Cells[k].Value.ToString().Replace("\r"," ").Replace("\n"," ") + ";");
                }
                sb.AppendLine();
            }
            File.WriteAllText(pathFile + fileNameExcel, sb.ToString());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                 export();
                 Process process = new Process();
                 process.StartInfo.FileName = pathFile + fileNameExcel;
                 process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
