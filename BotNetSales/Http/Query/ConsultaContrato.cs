using BotNetSales.App;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotNetSales.Http.Query
{
    public class ConsultaContrato
    {
        public async Task<string> pesquisaContrato(string num_contrato)
        {
            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                { "acao", "search" },
                { "codCidade", Config.COD_ESTADO_OPERADORA },
                { "nomeCidade", Config.CIDADE_OPERADORA },
                { "cidContrato",Config.COD_ESTADO_OPERADORA },
                { "dddVoip","" },
                { "telefoneVoip","" },
                { "dddTelefone","" },
                { "campoHiddenCidade",Config.CIDADE_OPERADORA },
                { "sglEstado",Config.ESTADO_OPERADORA },
                { "cidadeText",Config.CIDADE_OPERADORA },
                { "cidade",Config.COD_ESTADO_OPERADORA },
                { "codNet",num_contrato },
                { "nomeComecando","true" },
                { "tipoCpfCnpj","false" },
                { "tipoTel","false" },
                { "protocolo","" },
                { "dbService",Config.BASE_OPERADORA }
            };
            CookieContainer cookies = new CookieContainer();
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    AllowAutoRedirect = false
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://netsales.netservicos.com.br/NETSales/pesquisaAssinantes.do?acao=prepareSearch");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "netsales.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config.JSESSIONID);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync("https://netsales.netservicos.com.br/NETSales/pesquisaAssinantes.do", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                return contents;
            }
            return null;
        }

        public async Task<string> pesquisaPorNome(string nome)
        {
            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                { "acao", "search" },
                { "codCidade", Config.COD_ESTADO_OPERADORA },
                { "nomeCidade", Config.CIDADE_OPERADORA },
                { "cidContrato",Config.COD_ESTADO_OPERADORA },
                { "dddVoip","" },
                { "telefoneVoip","" },
                { "dddTelefone","" },
                { "campoHiddenCidade",Config.CIDADE_OPERADORA },
                { "sglEstado",Config.ESTADO_OPERADORA },
                { "cidadeText",Config.CIDADE_OPERADORA },
                { "cidade",Config.COD_ESTADO_OPERADORA },
                { "nome",nome },
                { "nomeComecando","true" },
                { "tipoCpfCnpj","false" },
                { "tipoTel","false" },
                { "protocolo","" },
                { "dbService",Config.BASE_OPERADORA }
            };
            CookieContainer cookies = new CookieContainer();
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    AllowAutoRedirect = false
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://netsales.netservicos.com.br/NETSales/pesquisaAssinantes.do?acao=prepareSearch");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "netsales.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config.JSESSIONID);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync("https://netsales.netservicos.com.br/NETSales/pesquisaAssinantes.do", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                return contents;
            }
            return null;
        }
        public async Task<string> pesquisaPorCpfOrCnpj(string cpfOrCnpj)
        {
            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                { "acao", "search" },
                { "codCidade", Config.COD_ESTADO_OPERADORA },
                { "nomeCidade", Config.CIDADE_OPERADORA },
                { "cidContrato",Config.COD_ESTADO_OPERADORA },
                { "dddVoip","" },
                { "telefoneVoip","" },
                { "dddTelefone","" },
                { "campoHiddenCidade",Config.CIDADE_OPERADORA },
                { "sglEstado",Config.ESTADO_OPERADORA },
                { "cidadeText",Config.CIDADE_OPERADORA },
                { "cidade",Config.COD_ESTADO_OPERADORA },
                { "cpfCnpj",cpfOrCnpj },
                { "nomeComecando","true" },
                { "tipoCpfCnpj","false" },
                { "tipoTel","false" },
                { "protocolo","" },
                { "dbService",Config.BASE_OPERADORA }
            };
            CookieContainer cookies = new CookieContainer();
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    AllowAutoRedirect = false
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://netsales.netservicos.com.br/NETSales/pesquisaAssinantes.do?acao=prepareSearch");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "netsales.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config.JSESSIONID);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync("https://netsales.netservicos.com.br/NETSales/pesquisaAssinantes.do", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                return contents;
            }
            return null;
        }
    }
}
