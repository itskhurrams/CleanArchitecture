using System;
namespace Clean.Architecture.Common
{
    public class Conversion
    {
        public static bool ToBool(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    if(value.ToString().ToLower() == "true")
                        return true;
                    else if (value.ToString().ToLower() == "false")
                        return false;
                    else
                        return Convert.ToBoolean(value);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                try
                {
                    if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                    {
                        return Convert.ToBoolean(Convert.ToInt32(value));
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static Guid ToGuid(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Guid.Parse(Convert.ToString(value));
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
        public static string ToString(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToString(value);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static TimeSpan ToTimeSpan(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return (TimeSpan)value;
                }
                else
                {
                    return new TimeSpan(0, 0, 0);
                }
            }
            catch (Exception)
            {
                return new TimeSpan(0, 0, 0);
            }
        }
        public static int ToInt(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static short ToShort(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToInt16(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int64 ToInt64(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToInt64(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int64 ToLong(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToInt64(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Decimal ToDecimal(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToDecimal(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static double ToDouble(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToDouble(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static float ToSingle(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToSingle(value);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static DateTime ToDateTime(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return Convert.ToDateTime(value);
                }
                else
                {
                    return new DateTime(1900, 1, 1);
                }
            }
            catch (Exception)
            {
                return new DateTime(1900, 1, 1);
            }
        }
        public static string ToHash(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return value.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static Byte[] ToByteArray(object value)
        {
            try
            {
                if (value != null && value != DBNull.Value && value.ToString() != string.Empty)
                {
                    return (Byte[])(value);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string OppositeDateTimeConvert(string yyyymmdd)
        {
            try
            {
                if (yyyymmdd.Length >= 14)
                {
                    yyyymmdd = yyyymmdd.Substring(4, 2) + "/" + yyyymmdd.Substring(6, 2) + "/" + yyyymmdd.Substring(0, 4) + " " + yyyymmdd.Substring(8, 2) + ":" + yyyymmdd.Substring(10, 2) + ":" + yyyymmdd.Substring(12, 2);
                }
                else if (yyyymmdd.Length == 8)
                {
                    yyyymmdd = yyyymmdd.Substring(4, 2) + "/" + yyyymmdd.Substring(6, 2) + "/" + yyyymmdd.Substring(0, 4);
                }
                return yyyymmdd;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}