using System.Net.Http.Headers;
using System.Text.Json;
using EXAMINATION.Models.Khalti;
using System.Text;
public class KhaltiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public KhaltiService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<KhaltiInitiateResponse?> InitiatePaymentAsync(KhaltiInitiateRequest payload)
    {
        var secretKey = _config["Khalti:SecretKey"];
        var baseUrl = _config["Khalti:BaseUrl"];

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Key", secretKey);

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{baseUrl}/epayment/initiate/", content);

          if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var json=  await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<KhaltiInitiateResponse>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    public async Task<KhaltiLookupResponse?> LookupPaymentAsync(string pidx)
    {
        var secretKey = _config["Khalti:SecretKey"];
        var baseUrl = _config["Khalti:BaseUrl"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Key", secretKey);

        var body= new {pidx=pidx};
        var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{baseUrl}/epayment/lookup/", content);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var json= await response.Content.ReadAsStringAsync();
           return JsonSerializer.Deserialize<KhaltiLookupResponse>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}