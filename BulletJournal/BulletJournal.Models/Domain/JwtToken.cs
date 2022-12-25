using Newtonsoft.Json;

namespace BulletJournal.Models.Domain
{
    public class JwtToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
