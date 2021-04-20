using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using middlewareTest.Models;
using System.Text;
using System.Xml;
using Swashbuckle.Swagger;
using Newtonsoft.Json;

namespace middlewareTest.Services
{
    public class B2bData : IB2BData
    {
        public async Task<string> GetData(string url)
        {
            string json = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                json = JsonConvert.SerializeXmlNode(doc);
            }
            catch(Exception ex)
            {
                json = "Error:{error:An error has occurred,description:" + $"{ ex.Message}" + "}";
            }
            return json;
        }
    }
}
