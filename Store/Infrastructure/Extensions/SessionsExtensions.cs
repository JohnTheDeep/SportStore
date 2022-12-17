using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Store.Infrastructure.Extensions
{
    public static class SessionsExtensions
    {
        public static void SetJson(this ISession _session, string key, object value)
        {
            _session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession _session, string key)
        {
            var _sessionData = _session.GetString(key);
            return _sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(_sessionData);
        }
    }
}
