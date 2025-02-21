using System;
using System.Linq;

namespace trickyclown
{
    public static class ReflectionUtility
    {
        /// <summary>
        /// Returns a Type by its name.
        /// </summary>
        public static Type GetTypeByName(string name)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Reverse())
            {
                var tt = assembly.GetType(name);
                if (tt != null)
                {
                    return tt;
                }
            }
            return null;
        }
    }
}