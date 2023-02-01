using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models.DTOAPI;

namespace Devs2Blu.ProjetosAula.CSharpMVCRevisao.Service
{
    public class ServiceAPI
    {

        private readonly HttpClient _httpClient;

        public ServiceAPI()//metodo construtor
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CardDTO>> GetListCards()
        {
            //dentro de GetListDataCardsDTO tem o atributo Data
            //essa var recebe a função Get, onde estamos passando o tipo do T e a URL como parametro
            var objJSONResponse = await Get<GetListDataCardsDTO>(URL_API_PT);

            //recebe a lista Data dentro de GetListDataCardsDTO
            var listCards = objJSONResponse.Data;

            //retorna uma lista
            return listCards;
        }

        //vai trazer um card pesquisando pelo nome
        public async Task<List<CardDTO>> GetCardByName(string name)
        {
            //era pra ser urlSearch
            //utilzando aquela url base e criando outra
            var urlSearch = $"{URL_API}?name={name}";

            //oq vem dps do ? é um paremetro, e dentro das chaves é um valor
            var objJSONResponse = await Get<GetListDataCardsDTO>(urlSearch);
            var listCards = objJSONResponse.Data;
            return listCards;
        }

        #region BaseMethods

        //um objeto
        public async Task<T> Get<T>(string url)
        {
            var objHttp = await GetAsync(url);

            if (!objHttp.IsSuccessStatusCode)
                return (T)(object)url;

            //retorna um objeto
            return await objHttp.Content.ReadFromJsonAsync<T>();

        }

        //lista dos objetos
        public async Task<List<T>> GetList<T>(string url)
        {
            var listHttp = await GetAsync(url);

            if (!listHttp.IsSuccessStatusCode)
                return new List<T>();

            //retorna uma lista de objetos
            return await listHttp.Content.ReadFromJsonAsync<List<T>>();

        }

        //comunicação com a API
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var getRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };
            return await _httpClient.SendAsync(getRequest);
        }
        #endregion

        #region CONST
        private const string URL_API = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        private const string URL_API_PT = "https://db.ygoprodeck.com/api/v7/cardinfo.php?language=pt";
        #endregion
    }

}
