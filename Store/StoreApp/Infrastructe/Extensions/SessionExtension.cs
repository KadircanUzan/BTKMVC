using System.Text.Json;

namespace StoreApp.Infrastructe.Extensions
{
    /*
    Static bir sınıfın bütün üyeleri statik olur.
    newleme yapamadan oluşturabiliriz.
    */
    public static class SessionExtension
    {
        /*
            this ISession session => Bu parametre dikkate alınmaz. Genişletilen ifade anlamına gelir.
            key ve value parametrelerini kullanılıp Session içerisinde saklarız.
        */
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null 
                   ? default(T)
                   : JsonSerializer.Deserialize<T>(data); 
            
        }
    }
}