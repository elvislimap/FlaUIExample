using System.Collections.Generic;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace AutomationTests2.Utils
{
    public static class Extensions
    {
        public static List<Window> GetWindows(this Application application)
        {
            return application
                .GetAllTopLevelWindows(new UIA3Automation())?.OfType<Window>().ToList();
        }
    }
}