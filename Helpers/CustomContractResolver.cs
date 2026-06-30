using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class CustomContractResolver : DefaultContractResolver
{
    private const int HighPriority = -1;
    private const int LowPriority = 1;

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        
        if (IsInheritedProperty(member))
        {
            property.Order = LowPriority;
        }
        else
        {
            property.Order = HighPriority;
        }

        return property;
    }

    private bool IsInheritedProperty(MemberInfo member)
    {
        return member.DeclaringType != typeof(BaseDTO);
    }
}