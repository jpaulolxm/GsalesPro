using BotNetSales.Http.Query;
using BotNetSales.Repository;
using BotNetSales.App;
using GsalesPro.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GsalesPro
{
    public partial class PesquisarStatus : MetroFramework.Forms.MetroForm
    {     
        public PesquisarStatus()
        {
            InitializeComponent();
        }

        private void PesquisarStatus_Load(object sender, EventArgs e)
        {
            txt_estado.Text = $"ESTADO: {Config.ESTADO_OPERADORA}";
            txt_cidade.Text = $"CIDADE: {Config.CIDADE_OPERADORA}";
        }

        private List<ClienteForaField> clienteForaFields = new List<ClienteForaField>();
        public List<string> ContratosNaoEncontrados = new List<string>();
        private string pathFile = Path.GetTempPath();
        private string fileNameExcel = "\\" +
           DateTime.Now.ToString()
          .Replace("-", "")
          .Replace(":", "")
          .Replace("/", "")
          .Replace(" ", "") + ".csv";
        private List<string> contratos()
        {
            List<string> contratos = new List<string>();

            foreach (var contrato in textBox1.Lines)
            {
                if (!string.IsNullOrWhiteSpace(contrato))
                {
                    contratos.Add(contrato);
                }
            }
           
            return contratos;
        }
        
        private async void btn_verificar_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                lbl_status.Visible = true;
                btn_export.Visible = false;

                btn_verificar.Enabled = false;
                var listContratos = contratos();
                NetSalesManager netSalesManager = new NetSalesManager();
                if (await netSalesManager.connect(Settings.Default["user"].ToString(), Settings.Default["password"].ToString()))
                {
                    clienteForaFields = await netSalesManager.foraField(listContratos);
                    ContratosNaoEncontrados = netSalesManager.ContratosNaoEncontrados;

                    if (ContratosNaoEncontrados.Count > 0)
                    {
                        button1.Visible = true;
                    }

                    btn_verificar.Enabled = true;

                    pictureBox1.Visible = false;
                    lbl_status.Visible = false;
                    btn_export.Visible = true;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no login, Por favor tente novamente!", "GSales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_verificar.Enabled = true;
                    pictureBox1.Visible = false;
                    lbl_status.Visible = false;
                    btn_export.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private async Task<bool> exportExcel()
        {
            try
            {
                StringBuilder csv = new StringBuilder();
                //CSV HEADER
                csv.AppendLine(
                    "NUM_CONTRATO; " +
                    "NOME_TITULAR; " +
                    "STATUS; ");

                foreach (var cliente in clienteForaFields)
                {
                    csv.AppendLine(
                        $"{cliente.NUM_CONTRATO};" +
                        $"{cliente.NOME_TITULAR};" +
                        $"{cliente.STATUS};");
                }
                try
                {
                    File.WriteAllText(pathFile + fileNameExcel, csv.ToString());
                    return true;
                }
                catch
                {
                    MessageBox.Show("O arquivo " + fileNameExcel + " já esta sendo executado.", "GSales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                btn_export.Enabled = false;
                var finishProcess = await exportExcel();
                if (finishProcess)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = pathFile + fileNameExcel;
                    process.Start();
                    btn_export.Enabled = true;
                }
                else
                {
                    MessageBox.Show("O arquivo " + fileNameExcel + " não pode ser aberto", "GSales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_export.Enabled = true;
                }
               
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            foreach (var contrato in ContratosNaoEncontrados)
            {
                textBox1.AppendText(contrato + "\r\n");
            }
        }
    }
}
