using Devs2Blu.CopaMundo.Models;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services
{
    public class CopaAPIService
    {
        private const String URL_GROUPS = "https://raw.githubusercontent.com/openfootball/worldcup.json/master/2022/worldcup.groups.json";
        private const String URL_JOGOS = "https://raw.githubusercontent.com/openfootball/worldcup.json/master/2022/worldcup.json";

        private readonly HttpClient _httpcliente;

        public CopaAPIService()
        {
            HttpClient httpclient = new HttpClient(); 
        }

        public async Task<Copa> GetGroups()
        {
            return await Get<Copa>(URL_GROUPS);
        }

        public async Task<Copa> GetJogos()
        {
            return await Get<Copa>(URL_JOGOS);
        }

        public async Task<T> Get<T>(string url)
        {
            var listHttp = await GetAsync(url);

            if (!listHttp.IsSuccessStatusCode)
            {
                return (T)(object)url;
            }

            return await listHttp.Content.ReadFromJsonAsync<T>();

        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var getResquest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            return await _httpcliente.SendAsync(getResquest);
        }
    }
}
