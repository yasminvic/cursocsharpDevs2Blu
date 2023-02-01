using Devs2Blu.ReceitasProjetoMVC.Models.Receita;
using System.Xml.Linq;

namespace Devs2Blu.ReceitasProjetoMVC.Service
{
    public class ServiceApi
    {
        private readonly HttpClient _httpClient;

        public ServiceApi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            var objResponse = await Get<GetListReceitas>(URL_TAGS);
            var listRecipes = objResponse.Results;
            return listRecipes;
        }

        public async Task<List<Recipe>> GetRecipeByName(string name)
        {
            string url = $"{URL_TAGS}&q={name}";
            var objResponse = await Get<GetListReceitas>(url);  
            var listRecipes = objResponse.Results;
            return listRecipes;
        }

        //quando clica em descrição
        public async Task<Recipe> GetRecipeById(int id)
        {
            string url = $"{URL_DESCR}{id}";
            var objResponse = await Get<Recipe>(url);
            var listRecipes = objResponse;
            return objResponse;
        }

        public async Task<List<Recipe>> GetRandomRecipe()
        {
            Random random = new Random();
            int n1 = random.Next(1,10);
            int n2 = random.Next(10, 20);;

            string url = $"{URL_API}/recipes/list?from={n1}&size={n2}&tags=under_30_minutes";

            var objResponse = await Get<GetListReceitas>(url);
            var listReceitas = objResponse.Results;
            return listReceitas;


        }

        #region base methods

        public async Task<T> Get<T>(string url)
        {
            var response = await GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return (T)(object)url;
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<List<T>> GetList<T>(string url)
        {
            var response = await GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<T>();
            }

            return await response.Content.ReadFromJsonAsync<List<T>>();
        }

        //comunicação com a API
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var getRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    {"X-RapidAPI-Key", "7aff568922msh4fc94b4b3a7d874p1fdcaejsn15a689ba2dc3" },
                    {"X-RapidAPI-Host", "tasty.p.rapidapi.com" }
                }
            };

            return await _httpClient.SendAsync(getRequest);
        }

        #endregion

        #region URL_API
        private const string URL_API = "https://tasty.p.rapidapi.com";
        private const string URL_TAGS = $"{URL_API}/recipes/list?from=0&size=20&tags=under_30_minutes";
        private const string URL_DESCR = $"{URL_API}/recipes/get-more-info?id=";
        #endregion
    }
}
