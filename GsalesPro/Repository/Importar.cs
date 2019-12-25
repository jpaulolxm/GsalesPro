using BotNetSales.Http.Query;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsalesPro.Repository
{
    class Importar
    {
        public async Task<List<ClienteNgestor>> readExcel(string filePath)
        {
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var data = reader.AsDataSet().Tables[0];
                        if (validateHeaders(data))
                        {
                            MontedClienteNgestorOBJECT montedCliente = new MontedClienteNgestorOBJECT();
                            montedCliente.execute(data);
                            montedCliente.clientes.RemoveAt(0);
                            return montedCliente.clientes;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private bool validateHeaders(DataTable data)
        {
            if (data.Columns.Count == 27)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Planilha não esta no padrão", "GSales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
