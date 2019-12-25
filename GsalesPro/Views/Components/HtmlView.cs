using System;
using System.Windows.Forms;

namespace GsalesPro.Views.Components
{
    public partial class HtmlView : UserControl
    {
        private string _html = "";
        public HtmlView(string html)
        {
            _html = html;
            InitializeComponent();
        }
       
        private void HtmlView_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_html))
            {
                webBrowser1.DocumentText = _html;
            }
            else
            {
                webBrowser1.DocumentText = "<body><h1>Ocorreu um erro! <br> Por favor tente novamente.</h1></body>";
            }
           
        }

        private bool bCancel = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int i;
            for (i = 0; i < webBrowser1.Document.Links.Count; i++)
            {
                webBrowser1.Document.Links[i].Click += new HtmlElementEventHandler(this.LinkClick);
            }
        }
        private void LinkClick(object sender, System.EventArgs e)
        {
            bCancel = true;
        }
       
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (bCancel == true)
            {
                e.Cancel = true;
                bCancel = false;
            }
        }
    }
}
