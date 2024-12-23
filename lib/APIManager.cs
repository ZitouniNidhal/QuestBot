using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuestBot.Lib
{
    public class ApiManager
    {
        private readonly string _apiKey = "https://dialogflow.googleapis.com";
        private readonly string _url = "https://api.dialogflow.com/v1/query?v=20150910";
        private readonly HttpClient _httpClient;

        public ApiManager()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetResponseFromAPI(string userMessage)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _url);
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            request.Content = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    query = userMessage,
                    lang = "fr",
                    sessionId = "unique_session_id"
                }),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var dialogflowResponse = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                    if (dialogflowResponse?.result?.fulfillment?.speech != null)
                    {
                        return dialogflowResponse.result.fulfillment.speech;
                    }
                    else
                    {
                        return "Réponse vide de l'API.";
                    }
                }
                else
                {
                    return "Erreur dans la communication avec l'API.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur API: {ex.Message}");
                return "Erreur lors de l'appel à l'API.";
            }
        }
    }
}
