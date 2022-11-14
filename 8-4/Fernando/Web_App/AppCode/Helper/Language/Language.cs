using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;

namespace Web_App.AppCode.Helper.Language
{
    public static partial class LanguageHelper
    {
        private static readonly ResourceManager ResMan = new ResourceManager("Web_App.Configs.Resource.Res", typeof(LanguageHelper).Assembly);

        private static string GetString(string key)
        {
            var cul = CultureInfo.CreateSpecificCulture("en");
            var value = ResMan.GetString(key, cul);
            return value;
        }
    }
}