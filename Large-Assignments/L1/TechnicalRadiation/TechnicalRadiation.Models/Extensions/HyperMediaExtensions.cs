using System.Collections.Generic;
using System.Dynamic;

namespace TechnicalRadiation.Models.Extensions
{
    public static class HyperMediaExtensions
    {
        public static void AddReference<T>(this ExpandoObject item, string key, T value) => ((IDictionary<string, object>)item).Add(key, value);
    }
}