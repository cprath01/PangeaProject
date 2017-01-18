using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Octokit;
using MQConsumerService.Domain;
using System.Net.Http;
using System.Collections;
using System.Configuration;
using System.Net.Http.Formatting;
using Domain.Converters.Interfaces;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using MQConsumerService.Domain.Common;

namespace ReposAPIService
{
    public class ReposAPI : IReposAPI
    {
        private const string PangeaRepoAPIURL = "PangeaRepoAPIURL";
        private string _URL;
        private IRepoConverter _Converter;

        public ReposAPI(IRepoConverter converter)
        {
            _URL = ConfigurationManager.AppSettings.Get(PangeaRepoAPIURL);
            _Converter = converter;
        }

        public async Task<List<Repos>> Get(string repoList = null)
        {
            var formatters = new List<MediaTypeFormatter>() {
                new JsonMediaTypeFormatter()
            };

            var repos = new List<Repos>();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Test2 App");
            var response = await client.GetAsync(_URL);

            if (response.IsSuccessStatusCode)
            {
                var repositories = await response.Content.ReadAsAsync<IEnumerable<Repository>>(formatters);
                repositories.Limit(repoList);
                repos.AddRange(_Converter.convert(repositories));
            }

            return repos;
        }
    }
}
