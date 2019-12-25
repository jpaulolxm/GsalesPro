using BotNetSales.Repository;
using GsalesPro.Properties;
using GsalesPro.Repository;
using GsalesPro.Views.Components;
using System;
using System.Windows.Forms;

namespace GsalesPro
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracao configuracao = new Configuracao();
            configuracao.ShowDialog();
        }

        private void alterarRegiãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstanciaLocal configuracao = new InstanciaLocal();
            configuracao.ShowDialog();
        }

        private async void importarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                WaitExcel waitExcel = new WaitExcel();

                if (!string.IsNullOrWhiteSpace(Settings.Default["user"].ToString()) && !string.IsNullOrWhiteSpace(Settings.Default["password"].ToString()))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "Excel (*.xls)|*.xls";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
 
                        Importar importar = new Importar();
                        var clientes = await importar.readExcel(openFileDialog.FileName);
                        if (clientes != null)
                        {
                            
                            painel_central.Controls.Clear();
                            waitExcel.loading = true;
                            waitExcel.status = true;
                            waitExcel.Dock = DockStyle.Fill;
                            painel_central.Controls.Add(waitExcel);

                            NetSalesManager netSalesManager = new NetSalesManager();

                            if (await netSalesManager.connect(Settings.Default["user"].ToString(), Settings.Default["password"].ToString()))
                            {
                                waitExcel.clientesExport = await netSalesManager.foraFieldNgestor(clientes);
                                waitExcel.loading = false;
                                waitExcel.status = false;
                                waitExcel.btnExport = true;
                            }
                            else
                            {
                                MessageBox.Show("Ocorreu um erro no login, Por favor tente novamente!", "GSales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                waitExcel.loading   = false;
                                waitExcel.status    = false;
                                waitExcel.btnExport = false;
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("É necessário cadastrar um usuário e senha.", "Gsales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    waitExcel.loading   = false;
                    waitExcel.status    = false;
                    waitExcel.btnExport = false;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void nomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PesquisaClienteNome pesquisaClienteNome = new PesquisaClienteNome();
            if (pesquisaClienteNome.ShowDialog() == DialogResult.OK)
            {
                HtmlView htmlView = new HtmlView(pesquisaClienteNome.result);
                htmlView.Dock = DockStyle.Fill;
                painel_central.Controls.Clear();
                painel_central.Controls.Add(htmlView);
            }
        }

        private void cPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PesquisaClienteCpf pesquisaClienteCpf = new PesquisaClienteCpf();
            if (pesquisaClienteCpf.ShowDialog() == DialogResult.OK)
            {
                HtmlView htmlView = new HtmlView(pesquisaClienteCpf.result);
                htmlView.Dock = DockStyle.Fill;
                painel_central.Controls.Clear();
                painel_central.Controls.Add(htmlView);
            }
        }

        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PesquisarStatus pesquisarStatus = new PesquisarStatus();
            pesquisarStatus.ShowDialog();
        }

        private void planilhaDinamicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanilhaDinamica planilhaDinamica = new PlanilhaDinamica();
            planilhaDinamica.Dock = DockStyle.Fill;
            painel_central.Controls.Clear();
            painel_central.Controls.Add(planilhaDinamica);
        }
    }
}
