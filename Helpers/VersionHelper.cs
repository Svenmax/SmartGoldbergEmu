using System;
using System.Reflection;

namespace SmartGoldbergEmu.Helpers
{
    public static class VersionHelper
    {
        public static string GetDisplayVersion()
        {
#if DEBUG
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return $"v{version}";
#else
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return $"v{version}";
#endif
        }
    }
} 