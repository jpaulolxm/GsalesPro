using BotNetSales.App;
using BotNetSales.Http.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotNetSales.Http.Auth
{
    public class AuthNetSales
    {
        public async Task<bool> execute(string user, string password)
        {
            if (!await getSession())
            {
                return false;
            }

            if (!await validateSession())
            {
                return false;
            }

            if (!await login(user, password))
            {
                return false;
            }
            return await validateSession();
        }
        private string AlphNumeric(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijlmnopqrstuvxzywk0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private async Task<bool> getSession()
        {
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", " https://updateasc.netservicos.com.br/home/portal.do");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "netsales.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config.JSESSIONID);

            HttpResponseMessage response = await client.GetAsync("https://netsales.netservicos.com.br/NETSales/");
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Config.JSESSIONID = GetBetween.Between(response.Headers.ToString(), "Set-Cookie: ", "; Path=/NETSales; Secure");
                return true;
            }
            return false;
        }
        private async Task<bool> validateSession()
        {
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", "https://netsales.netservicos.com.br/NETSales/");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "netsales.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config.JSESSIONID);

            HttpResponseMessage response = await client.GetAsync("https://netsales.netservicos.com.br/NETSales/index.do");
            var contents = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        private async Task<bool> login(string user, string password)
        {
            Dictionary<string, string> form_data = new Dictionary<string, string>
            {
                { "j_username", user },
                { "j_password", password },
                { "j_captcha_input", AlphNumeric(6) },
                { "dbService","" }
            };
            CookieContainer cookies = new CookieContainer();
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    UseCookies = false,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });
            client.Timeout = TimeSpan.FromHours(2);

            string[] Accept = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "application/x-ms-application", "application/xaml+xml", "application/x-ms-xbap", "*/*" };
            string[] AcceptEncoding = new string[] { "gzip", "deflate" };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", Accept);
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
            client.DefaultRequestHeaders.Add("Accept-Encoding", AcceptEncoding);
            client.DefaultRequestHeaders.Add("Referer", " https://netsales.netservicos.com.br/NETSales/index.do");
            client.DefaultRequestHeaders.Add("User-Agent", Config.useragent);
            client.DefaultRequestHeaders.Add("Host", "netsales.netservicos.com.br");
            client.DefaultRequestHeaders.Add("Cookie", "asc-key-remote=" + Config.ASC_KEY_REMOTE + ";" + Config.JSESSIONID);

            HttpContent content = new FormUrlEncodedContent(form_data);
            HttpResponseMessage response = await client.PostAsync("https://netsales.netservicos.com.br/NETSales/j_security_check", content);
            var contents = await response.Content.ReadAsStringAsync();
            HttpContentHeaders headers = content.Headers;

            if (response.IsSuccessStatusCode)
            {
                if (contents.Contains("Usuário ou Senha inválidos!"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
