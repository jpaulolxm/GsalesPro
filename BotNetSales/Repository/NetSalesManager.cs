using BotAscWebBrowser.Http;
using BotNetSales.App;
using BotNetSales.Http.Auth;
using BotNetSales.Http.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotNetSales.Repository
{
    public class NetSalesManager
    {
        public async Task<bool> connect(string user, string password)
        {
            try
            {
                AuthASC auth = new AuthASC();
                string[] ASCCookies = await auth.execute();
                if (ASCCookies == null)
                {
                    return false;
                }

                Config.ASC_KEY_REMOTE = ASCCookies[0];

                AuthNetSales authNetSales = new AuthNetSales();
                return await authNetSales.execute(user, password);
            }
            catch { }
            return false;
        }
        private List<string> ContratosForaFieldsBlackList = new List<string>();
        private List<string> ContratosNgestorForaFieldsBlackList = new List<string>();
        public List<string> ContratosNaoEncontrados = new List<string>();
        public async Task<List<ClienteNgestor>> foraFieldNgestor(List<ClienteNgestor> clientes)
        {
            List<ClienteNgestor> clienteForaFields = new List<ClienteNgestor>();

            foreach (var cliente in clientes)
            {
                if (!ContratosNgestorForaFieldsBlackList.Contains(cliente.CONTRATO))
                {
                    ConsultaContrato consultaContrato = new ConsultaContrato();
                    string content = await consultaContrato.pesquisaContrato(cliente.CONTRATO);
                    var status = readContentForaFieldNgestor(content);
                    if (string.IsNullOrWhiteSpace(status))
                    {
                        cliente.STATUS_NETSALES = "NAO ENCONTRADO";
                        clienteForaFields.Add(cliente);
                        ContratosNgestorForaFieldsBlackList.Add(cliente.CONTRATO);
                    }
                    else
                    {
                        cliente.STATUS_NETSALES = status;
                        clienteForaFields.Add(cliente);
                        ContratosNgestorForaFieldsBlackList.Add(cliente.CONTRATO);
                    }
                   
                }
            }

            return clienteForaFields;
        }

        public async Task<string> consultaContrato(string contrato)
        {
            if (!ContratosNgestorForaFieldsBlackList.Contains(contrato))
            {
                ConsultaContrato consultaContrato = new ConsultaContrato();
                string content = await consultaContrato.pesquisaContrato(contrato);
                var status = readContentForaFieldNgestor(content);
                if (string.IsNullOrWhiteSpace(status))
                {
                    ContratosNgestorForaFieldsBlackList.Add(contrato);
                    return "NAO ENCONTRADO";
                }
                else
                {
                    ContratosNgestorForaFieldsBlackList.Add(contrato);
                    return status;
                }
            }
            return "CONTRATO DUPLICADO";
        }


        private string readContentForaFieldNgestor(string CONTENT)
        {
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(CONTENT);
                var node_td = htmlDoc.DocumentNode.SelectNodes("//table[contains(@id, \"resultadoPesquisaAssinante\")]/tr/td");
                var arrayStatus = criarArray(node_td);
                return arrayStatus[13].Value.Trim();
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<ClienteForaField>> foraField(List<string> contratos)
        {
            List<ClienteForaField> clienteForaFields = new List<ClienteForaField>();
           
            foreach (var contrato in contratos)
            {
                if (!ContratosForaFieldsBlackList.Contains(contrato))
                {
                    ConsultaContrato consultaContrato = new ConsultaContrato();
                    string content = await consultaContrato.pesquisaContrato(contrato);
                    var cliente = readContentForaField(content, contrato);
                    if (cliente == null)
                    {
                        ContratosNaoEncontrados.Add(contrato);
                    }
                    else
                    {
                        clienteForaFields.Add(cliente);
                        ContratosForaFieldsBlackList.Add(contrato);
                    }
                    
                }
            }

            return clienteForaFields;
        }
        private ClienteForaField readContentForaField(string CONTENT, string NUM_CONTRATO)
        {
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(CONTENT);

                var node_td = htmlDoc.DocumentNode.SelectNodes("//table[contains(@id, \"resultadoPesquisaAssinante\")]/tr/td");
                var arrayStatus = criarArray(node_td);


                ClienteForaField clienteForaField = new ClienteForaField();
                clienteForaField.NUM_CONTRATO   = NUM_CONTRATO;
                clienteForaField.NOME_TITULAR   = arrayStatus[10].Value.Trim();
                clienteForaField.STATUS         = arrayStatus[13].Value.Trim();

                return clienteForaField;
            }
            catch
            {
                return null;
            }
        }
        private List<KeyValuePair<int, string>> criarArray(HtmlAgilityPack.HtmlNodeCollection htmlNode)
        {
            try
            {
                List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
                int key = 0;

                foreach (var item in htmlNode)
                {
                    lista.Add(new KeyValuePair<int, string>(key, item.InnerText));
                    key++;
                }
                return lista;
            }
            catch
            {
                return null;
            }

        }
    }
}
