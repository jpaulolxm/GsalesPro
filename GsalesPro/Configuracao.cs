using GsalesPro.Properties;
using System;
using System.Windows.Forms;
namespace GsalesPro
{
    public partial class Configuracao : MetroFramework.Forms.MetroForm
    {
        public Configuracao()
        {
            InitializeComponent();
        }
        private void Configuracao_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_user.Text) && !string.IsNullOrWhiteSpace(txt_password.Text))
            {
                Settings.Default["user"] = txt_user.Text;
                Settings.Default["password"] = txt_password.Text;
                Settings.Default.Save();
                MessageBox.Show("Cadastro efetuado com sucesso!", "Gsales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Campos devem ser preenchidos corretamente!", "Gsales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
