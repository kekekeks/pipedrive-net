using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PipedriveNet
{
    internal class ContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<MemberInfo, string> _names = new Dictionary<MemberInfo, string>();
        public ContractResolver() : base(false)
        {

        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return GetSnakeCase(propertyName);
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var lst = new List<JsonProperty>();
            foreach (var member in GetSerializableMembers(type))
            {
                var prop = CreateProperty(member, memberSerialization);
                string customName;
                if (_names.TryGetValue(member, out customName))
                    prop.PropertyName = customName;

                lst.Add(prop);
            }

            return lst;
        }

        //https://gist.github.com/crallen/9238178
        private string GetSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var buffer = "";

            for (var i = 0; i < input.Length; i++)
            {
                var isLast = (i == input.Length - 1);
                var isSecondFromLast = (i == input.Length - 2);

                var curr = input[i];
                var next = !isLast ? input[i + 1] : '\0';
                var afterNext = !isSecondFromLast && !isLast ? input[i + 2] : '\0';

                buffer += char.ToLower(curr);

                if (!char.IsDigit(curr) && char.IsUpper(next))
                {
                    if (char.IsUpper(curr))
                    {
                        if (!isLast && !isSecondFromLast && !char.IsUpper(afterNext))
                            buffer += "_";
                    }
                    else
                        buffer += "_";
                }

                if (!char.IsDigit(curr) && char.IsDigit(next))
                    buffer += "_";
                if (char.IsDigit(curr) && !char.IsDigit(next) && !isLast)
                    buffer += "_";
            }

            return buffer;
        }

        public void Register(PropertyInfo property, string key)
        {
            _names[property] = key;
        }

        public string ResolveCustomName(PropertyInfo property)
        {
            return _names[property];
        }
    }
}