using System;
using System.Configuration;

namespace CodeSnippets.Reflection.GenericFactory
{
    public static class GenericFactory
    {
        public static T Get<T>() where T : class
        {
            var requestedType = typeof(T).ToString();
            var resolvedTypeName = ConfigurationManager.AppSettings[requestedType];
            var resolvedType = Type.GetType(resolvedTypeName);
            object instance = Activator.CreateInstance(resolvedType);
            var result = instance as T;
            return result;
        }
    }
}
