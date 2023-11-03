using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App_Logic
{
    public class AdminRegulation
    {
        private const string SERVICE_BASE_URL = "https://conferenceregulatory.azurewebsites.net";

        public ArticleRegulationInfo GetArticleGeneratedInfo()
        {
            //Se crean los parametros que se deben enviar al URL
            string urlMethod = "/api/ArticleRegulatory/GenerateArticleInformation";
            //Se obtienen
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string parameters = string.Format("?year={0}&month={1}", year, month);

            string finalURI = SERVICE_BASE_URL + urlMethod + parameters;

            //Se hace el llamado del API
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(finalURI);

            var invocationResult = client.GetAsync(finalURI).Result;

            if (invocationResult.IsSuccessStatusCode)
            {
                //Convertir el resultado (JSON) en el objeto que tenemos modelado en los DTO
                var patito = invocationResult.Content.ReadAsStringAsync().Result;

                var dtoObject = JsonConvert.DeserializeObject<ArticleRegulationInfo>(patito);

                return dtoObject;
            }

            return null;
        }

        public List<Author> GetRegisteredAuthors()
        {
            var urlMethod = "/api/Author/GetAllAuthors";
            var urlFinal = SERVICE_BASE_URL + urlMethod;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlFinal);

            var resultado = client.GetAsync(urlFinal).Result;

            if (resultado.IsSuccessStatusCode)
            {
                var jsonObject = resultado.Content.ReadAsStringAsync().Result;

                var apiResponse = JsonConvert.DeserializeObject<List<Author>>(jsonObject);

                return apiResponse;
            }
            return null;
        }
    }
}
