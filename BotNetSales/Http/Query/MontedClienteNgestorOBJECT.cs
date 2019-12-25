using System.Collections.Generic;
using System.Data;

namespace BotNetSales.Http.Query
{
    public class MontedClienteNgestorOBJECT
    {
        public List<ClienteNgestor> clientes = new List<ClienteNgestor>();
        public async void execute(DataTable data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                try
                {
                    ClienteNgestor cliente = new ClienteNgestor();
                    cliente.ABERTURA    = data.Rows[i][0].ToString();
                    cliente.AGENDAMENTO = data.Rows[i][1].ToString();
                    cliente.CONTRATO    = data.Rows[i][2].ToString();
                    cliente.OS          = data.Rows[i][3].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.CLIENTE     = data.Rows[i][4].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.PTV         = data.Rows[i][5].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.VIRTUA      = data.Rows[i][6].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.NET_FONE    = data.Rows[i][7].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.A_LAR_CARTE = data.Rows[i][8].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.CELULAR     = data.Rows[i][9].ToString().Replace("\r", " ").Replace("\n", " ");
                    string produto      = data.Rows[i][10].ToString().Replace("\r", " ").Replace("\n", " ");
                  
                    cliente.PRODUTO     = produto;
                    cliente.F_PAGAMENTO = data.Rows[i][11].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.RESPONSAVEL = data.Rows[i][12].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.STATUS      = data.Rows[i][13].ToString();
                    cliente.DT_ST       = data.Rows[i][14].ToString();
                    cliente.OBS         = data.Rows[i][15].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.PERIODO     = data.Rows[i][16].ToString();
                    cliente.CEP         = data.Rows[i][17].ToString();
                    cliente.BAIRRO      = data.Rows[i][18].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.ENDERECO    = data.Rows[i][19].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.VENDEDOR    = data.Rows[i][20].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.GRUPO       = data.Rows[i][21].ToString();
                    cliente.TELEFONE    = data.Rows[i][22].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.ESTADO      = data.Rows[i][23].ToString();
                    cliente.CIDADE      = data.Rows[i][24].ToString();
                    cliente.OBS_VENDA   = data.Rows[i][25].ToString().Replace("\r", " ").Replace("\n", " ");
                    cliente.LOGIN       = data.Rows[i][26].ToString();
                    clientes.Add(cliente);
                }
                catch
                {
                    continue;
                }
            }

        }
    }
}
