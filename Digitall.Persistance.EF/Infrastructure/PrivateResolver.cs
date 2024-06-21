using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Digitall.Persistance.EF.Infrastructure
{
    /// <summary>
    /// Define Private resolver, 
    /// so that Json Deserialiser is able to deserialise the values of all private set properties.
    /// </summary>
    public class PrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property != null && !property.Writable)
            {
                var propertyInfo = member as PropertyInfo;
                var hasPrivateSetter = propertyInfo!.GetSetMethod(true) != null;

                property.Writable = hasPrivateSetter;
            }

            return property;
        }
    }
}
