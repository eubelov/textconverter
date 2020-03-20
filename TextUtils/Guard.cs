using System;

namespace TextUtils
{
    public static class Guard
    {
        public static void ArgumentNotNullOrEmpty(string input, string name)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
