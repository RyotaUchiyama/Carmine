using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;

namespace Carmine.util
{
    class Json
    {
        public static dynamic JsonParse(string jsonString)
        {
            return DynamicJson.Parse(jsonString);
        }

        public static bool IsDefined(DynamicJson Json, string Key)
        {
            if (Json == null)
            {
                return false;
            }

            return Json.IsDefined(Key);
        }

        public static string CreateJsonString(object obj)
        {
            return DynamicJson.Serialize(obj);
        }

    }
}
