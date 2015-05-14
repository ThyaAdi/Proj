using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Net;
using System.Security.AccessControl;
using System.Xml;

namespace Util
{
    /// <summary>
    /// Object that handles Application Settings
    /// </summary>
    public static class AppSettings 
    {
        public static String ConnectionStr
        {
            get
            {
                return GetString("ConnectionStr");
            }
        }
        public static String ClientId
        {
            get
            {
                return GetString("ClientId");
            }
        }
        private static object GetSoftwareRoot(string tagName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "AppConfig.XML");
            XmlNode xnode = doc;
            return xnode.SelectSingleNode("descendant::"+tagName).InnerText;
        }

        private static void Set(String key)
        {            
            object value = GetSoftwareRoot(key);

            Type tempType = value.GetType();
            if (tempType == typeof(int))
            {                
                value = (int)value;
            }
            else if (tempType == typeof(ushort))
            {
                value = (ushort)value;
            }
            else if (tempType == typeof(bool))
            {
                if ((bool)value)
                    value = 1;
                else
                    value = 0;
            }
            else if (tempType == typeof(String))
            {
                value = (String)value;
            }
            else if (tempType == typeof(float))
            {

                value = BitConverter.ToInt32( BitConverter.GetBytes((float)value),0);
            }
            else if (tempType == typeof(double))
            {
                value = BitConverter.ToInt64(BitConverter.GetBytes((double)value),0);
            }
            else if (tempType == typeof(DateTime))
            {
                value = BitConverter.ToInt64(BitConverter.GetBytes( ((DateTime)value).Ticks),0);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static String GetString(String keyToGet)
        {
            return GetSoftwareRoot(keyToGet) as string;
        }
        private static bool GetBool(String keyToGet)
        {
            return Convert.ToBoolean(GetSoftwareRoot(keyToGet));
        }
        private static int GetInt(String keyToGet)
        {
            return GetUShort(keyToGet);
        }
        private static ushort GetUShort(String keyToGet)
        {
            return Convert.ToUInt16(GetSoftwareRoot(keyToGet));
        }
        private static float GetFloat(String keyToGet)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(GetInt(keyToGet)), 0);
        }
        private static double GetDouble(String keyToGet)
        {
            return BitConverter.ToDouble(BitConverter.GetBytes(GetInt(keyToGet)), 0);
        }
        private static decimal GetDecimal(String keyToGet)
        {
            return (decimal) GetDouble(keyToGet);
        }
    }  
}
