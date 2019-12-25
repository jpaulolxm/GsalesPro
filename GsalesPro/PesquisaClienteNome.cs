using BotNetSales.Http.Query;
using BotNetSales.Repository;
using GsalesPro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsalesPro
{
    public partial class PesquisaClienteNome : MetroFramework.Forms.MetroForm
    {
        public PesquisaClienteNome()
        {
            InitializeComponent();
        }
        public string result = "";
        private void PesquisaClienteNome_Load(object sender, EventArgs e)
        {

        }

        private async void btn_pesquisar_Click(object sender, EventArgs e)
        {
            NetSalesManager netSalesManager = new NetSalesManager();
            btn_pesquisar.Enabled = false;
            textBox1.Enabled      = false;
            lbl_wait.Visible = true;
            if (await netSalesManager.connect(Settings.Default["user"].ToString(), Settings.Default["password"].ToString()))
            {
                ConsultaContrato consultaContrato = new ConsultaContrato();
                result = await consultaContrato.pesquisaPorNome(textBox1.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
           
        }
    }
}
