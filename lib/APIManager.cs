using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class APIManager
{
    private readonly string _apiKey = "YOUR_DIALOGFLOW_API_KEY";
    private readonly string _url = "https://api.dialogflow.com/v1/query?v=20150910";
    private HttpClient _httpClient;

    public APIManager()
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
                return dialogflowResponse.result.fulfillment.speech;
            }
            else
            {
                return "Erreur dans la communication avec l'API.";
            }
        }
        catch (Exception ex)
        {
            GD.PrintErr($"Erreur API: {ex.Message}");
            return "Erreur lors de l'appel à l'API.";
        }
    }
}
