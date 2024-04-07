using DingTalkClient.Messages;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using System.Web;

namespace DingTalkClient
{
    /// <summary>
    /// 钉钉群机器人Client端
    /// </summary>
    public class DingDingClient
    {
        private string _webHookUrl;

        private string? _secret;

        private readonly HttpClient _httpClient;

        private string _requsetUrl;

        private static readonly JsonSerializerOptions _jsonSerializerOptions;

        static DingDingClient()
        {
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        public DingDingClient(string webHookUrl, string? secret)
        {
            _webHookUrl = webHookUrl;
            _secret = secret;
            _requsetUrl = webHookUrl;

            //每个机器人每分钟最多发送20条消息到群里，如果超过20条，会限流10分钟。
            var options = new TokenBucketRateLimiterOptions
            {
                TokenLimit = 20,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 1,
                ReplenishmentPeriod = TimeSpan.FromMinutes(1), 
                TokensPerPeriod = 20,
                AutoReplenishment = true
            };

            _httpClient = new HttpClient(new ClientSideRateLimitedHandler(limiter : new TokenBucketRateLimiter(options) ));
        }

        /// <summary>
        /// 发送一条消息
        /// </summary>
        public async Task<string> SendAsync<T>(T message) where T : IDingDingMessage
        {
            if (!string.IsNullOrEmpty(_secret))
            {
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                var encoding = new UTF8Encoding();

                byte[] signBytes = encoding.GetBytes($"{timestamp}\n{_secret}"); //时间戳和密钥当做签名字符串
                byte[] secretByte = encoding.GetBytes(_secret);

                using (var hmacsha256 = new HMACSHA256(secretByte))
                {
                    byte[] hashmessage = hmacsha256.ComputeHash(signBytes);
                    string sign = HttpUtility.UrlEncode(Convert.ToBase64String(hashmessage));
                    _requsetUrl = $"{_webHookUrl}&timestamp={timestamp}&sign={sign}";
                }
            }

            try
            {
                var json = JsonSerializer.Serialize(message, _jsonSerializerOptions);
                StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
                using HttpResponseMessage response = await _httpClient.PostAsync(_requsetUrl, jsonContent);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
