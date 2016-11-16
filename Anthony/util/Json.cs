using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Codeplex.Data;
using System.IO;

namespace Carmine.util
{
    public class Json
    {
        /// <summary>
        /// Json文字列をパース
        /// （DynamicJsonをラップ）
        /// </summary>
        /// <param name="jsonStr">Json文字列</param>
        /// <returns>DynamicJson</returns>
        public static dynamic JsonParse(string jsonStr)
        {
            return DynamicJson.Parse(jsonStr);
        }

        /// <summary>
        /// Jsonデータ内にKey項目が存在するかチェック
        /// （DynamicJsonをラップ）
        /// </summary>
        /// <param name="Json">DynamicJson</param>
        /// <param name="Key">キー項目</param>
        /// <returns>存在する場合True</returns>
        public static bool IsDefined(DynamicJson Json, string Key)
        {
            if (Json == null)
            {
                return false;
            }

            return Json.IsDefined(Key);
        }

        /// <summary>
        /// Json文字列を生成
        /// （DynamicJsonをラップ）
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Json文字列</returns>
        public static string CreateJsonString(object obj)
        {
            return DynamicJson.Serialize(obj);
        }

        /// <summary>
        /// Json文字列を指定したクラスにUTF8でシリアライズ
        /// </summary>
        /// <typeparam name="T">シリアライズクラス</typeparam>
        /// <param name="jsonStr">Json文字列</param>
        /// <returns></returns>
        public static T JsonSerializer<T>(string jsonStr)
        {
            return JsonSerializer<T>(jsonStr, Encoding.UTF8);
        }

        /// <summary>
        /// Json文字列を指定したクラスにシリアライズ
        /// </summary>
        /// <typeparam name="T">シリアライズクラス</typeparam>
        /// <param name="jsonStr">Json文字列</param>
        /// <param name="encoding">文字エンコード</param>
        /// <returns></returns>
        public static T JsonSerializer<T>(string jsonStr, Encoding encoding)
        {
            // DataContractJsonSerializer のインスタンスを作成
            var serializer = new DataContractJsonSerializer(typeof(T));

            // 戻り値生成
            T retObj;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(encoding.GetBytes(jsonStr)))
            {
                // JSON を読み込む
                retObj = (T)serializer.ReadObject(ms);
            }
            return retObj;
        }

        public static string JsonDeserializer<T>(T obj)
        {
            return JsonDeserializer<T>(obj, Encoding.UTF8);
        }

        public static string JsonDeserializer<T>(T obj,Encoding encoding)
        {
            string jsonStr = string.Empty;
            var deserializer = new DataContractJsonSerializer(typeof(T));

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                deserializer.WriteObject(ms, obj);
                jsonStr = encoding.GetString(ms.ToArray());
            }

            return jsonStr;
        }
    }
}
