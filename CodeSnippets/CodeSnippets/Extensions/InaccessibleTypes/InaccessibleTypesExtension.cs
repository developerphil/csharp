using System.Reflection;

namespace CodeSnippets.Extensions.InaccessibleTypes
{
    public static class InaccessibleTypesExtension
    {
        public static string StringUpper(this object obj)
        {
            var upper = string.Empty;

            var type = typeof (InaccessibleTypes).GetNestedType("Inaccessible", BindingFlags.NonPublic);

            if (obj.GetType() == type)
            {
                var method = type.GetMethod("GetString", BindingFlags.NonPublic | BindingFlags.Instance);
                var result = method.Invoke(obj, null) as string;
                upper = result.ToUpper();
            }

            return upper;
        }
    }
}