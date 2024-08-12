using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace YatriSewa_MVC.Models
{
    public class GoogleReCaptchaService
    {
        private readonly string _recaptchaSecretKey;
        private readonly HttpClient _httpClient;

        public GoogleReCaptchaService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _recaptchaSecretKey = configuration["GoogleReCaptcha:SecretKey"];
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<bool> IsCaptchaValid(string token)
        {
            var response = await _httpClient.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_recaptchaSecretKey}&response={token}");
            var captchaResult = JsonConvert.DeserializeObject<CaptchaResponse>(response);
            return captchaResult.Success;
        }
    }

    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
