using Devs2Blu.CopaMundo.Models;
using Devs2Blu.CopaMundo.Models.Copa;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models.Services
{
    public class CopaAPIService
    {
        
        private readonly HttpClient _httpcliente;

        public CopaAPIService()
        {
            _httpcliente = new HttpClient(); 
        }

        public async Task<List<Group>> GetGroups()
        {
            //oq retorna da api
            var objResponse = await Get<GetListGroups>(URL_GROUPS);

            //pegando só a lista de groups
            var listGroups = objResponse.Groups;

            //retornando lista de groups
            return listGroups;
        }

        public async Task<List<Match>> GetMatches()
        {
            var objResponse = await Get<GetListMatches>(URL_JOGOS);
            var listMatches = objResponse.Matches;
            return listMatches;
        }

        public String GetFlag(string type, string country)
        {
            string URL_FLAGS = $"https://countryflagsapi.com/{type}/{country}";
            return URL_FLAGS;

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


        #region URL_API
        
        private const String URL_GROUPS = "https://raw.githubusercontent.com/openfootball/worldcup.json/master/2022/worldcup.groups.json";
        private const String URL_JOGOS = "https://raw.githubusercontent.com/openfootball/worldcup.json/master/2022/worldcup.json";
        #endregion

    }
}
