using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Serilog;

namespace Bee.ZatcaHelper.Util;

public class WebClient
{
    private readonly HttpClient _client = new();

    public WebClient(string baseUrl, Dictionary<string, string> customHeaders)
    {
        _client.BaseAddress = new Uri(baseUrl);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.Add("Accept-Version", "V2");

        foreach (var (header, value) in customHeaders)
        {
            _client.DefaultRequestHeaders.Add(header, value);
        }
    }

    public WebClient(string baseUrl, Dictionary<string, string> customHeaders, string userName, string password)
        : this(baseUrl, customHeaders)
    {
        var credentials = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(userName + ":" + password));
        _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {credentials}");
    }

    public async Task<HttpResponseMessage> PostAsJsonAsync(string controller, object data)
    {
        HttpResponseMessage response = new();

        try
        {
            response = await _client.PostAsJsonAsync(controller, data).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Exception occured - {0}", ex.Message);
        }

        return response;
    }
}