using BotNetSales.Http.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsalesPro.Views.Components
{
    public partial class WaitExcel : UserControl
    {
        public WaitExcel()
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

        public List<ClienteNgestor> clientesExport = new List<ClienteNgestor>();
        public bool loading = false;
        public bool status = false;
        public bool btnExport = false;
        private void panel1_Resize(object sender, EventArgs e)
        {
            int x = (panel1.Size.Width - pictureBox1.Width) / 2;
            int y = (panel1.Size.Height - pictureBox1.Height) / 2;
            pictureBox1.Location = new Point(x, y);

            int xl = (panel1.Size.Width - lbl_status.Width) / 2;
            int yl = (panel1.Size.Height - lbl_status.Height) / 2;
            lbl_status.Location = new Point(xl, yl + 150);


            int xb = (panel1.Size.Width - btn_export.Width) / 2;
            int yb = (panel1.Size.Height - btn_export.Height) / 2;
            btn_export.Location = new Point(xb, yb);
        }

        private async Task<bool> exportExcel()
        {
            StringBuilder csv = new StringBuilder();
            //CSV HEADER
            csv.AppendLine("ABERTURA; " +
                "AGENDAMENTO; " +
                "CONTRATO; " +
                "OS; " +
                "CLIENTE; " +
                "STATUS_NETSALES; " +
                "PTV; " +
                "VIRTUA; " +
                "NET_FONE; " +
                "A_LAR_CARTE; " +
                "CELULAR; " +
                "PRODUTO; " +
                "F_PAGAMENTO; " +
                "RESPONSAVEL; " +
                "STATUS; " +
                "DT_ST; " +
                "OBS; " +
                "PERIODO; " +
                "CEP; " +
                "BAIRRO; " +
                "ENDERECO; " +
                "VENDEDOR; " +
                "GRUPO; " +
                "TELEFONE; " +
                "ESTADO; " +
                "CIDADE; " +
                "OBS_VENDA; " +
                "LOGIN; ");


            foreach (var cliente in clientesExport)
            {
                try
                {
                    csv.AppendLine($"{cliente.ABERTURA};" +
                   $"{cliente.AGENDAMENTO};" +
                   $"{cliente.CONTRATO};" +
                   $"{cliente.OS};" +
                   $"{cliente.CLIENTE};" +
                   $"{cliente.STATUS_NETSALES};" +
                   $"{cliente.PTV};" +
                   $"{cliente.VIRTUA};" +
                   $"{cliente.NET_FONE};" +
                   $"{cliente.A_LAR_CARTE};" +
                   $"{cliente.CELULAR};" +
                   $"{cliente.PRODUTO};" +
                   $"{cliente.F_PAGAMENTO};" +
                   $"{cliente.RESPONSAVEL};" +
                   $"{cliente.STATUS};" +
                   $"{cliente.DT_ST};" +
                   $"{cliente.OBS};" +
                   $"{cliente.PERIODO};" +
                   $"{cliente.CEP};" +
                   $"{cliente.BAIRRO};" +
                   $"{cliente.ENDERECO};" +
                   $"{cliente.VENDEDOR};" +
                   $"{cliente.GRUPO};" +
                   $"{cliente.TELEFONE};" +
                   $"{cliente.ESTADO};" +
                   $"{cliente.CIDADE};" +
                   $"{cliente.OBS_VENDA};" +
                   $"{cliente.LOGIN};");
                }
                catch (Exception)
                {
                    continue;
                }

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

        private async void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                var finishProcess = await exportExcel();
                btn_export.Enabled = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_export.Visible = btnExport;
            pictureBox1.Visible = loading;
            lbl_status.Visible = status;
        }
    }
}
