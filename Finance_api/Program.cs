using Finance_api.Models;
using Newtonsoft.Json;
using Serilog.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Finance_api
{
    internal class Program
    {
        private static Logger _logger = MyLogger.WriteLogInFile();
        public Program(Logger logger)
        {
            _logger = logger;
        }
        async static Task Main(string[] args)
        {
            DataBaseOperations baseOperations = new DataBaseOperations();   
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();
                var token = "d36118a8c3f5e5fc6d09a3dbc69a1738";
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"http://api.marketstack.com/v1/eod?access_key={token}&symbols=AAPL");
                response = await client.SendAsync(requestMessage);

                response.EnsureSuccessStatusCode();
                var jsonPage = await response.Content.ReadAsStringAsync();

                MainDeserialize deserializePage = JsonConvert.DeserializeObject<MainDeserialize>(jsonPage);
                await baseOperations.FillRows(deserializePage);
                _logger.Information("Successfull");
            }
            catch (Exception ex)
            {
                _logger.Warning(ex + DateTime.Now.ToString());  
            }
        }
    }
}
