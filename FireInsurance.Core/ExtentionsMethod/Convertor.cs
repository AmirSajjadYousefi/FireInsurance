using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace FireInsurance.Core.Helpers
{
    public static class Convertor
    {
        public static string ToMiladi(this string value)
        {
            string[] val = value.Split("/");
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Convert.ToInt32(val[0]), Convert.ToInt32(val[1]), Convert.ToInt32(val[2]), pc);
            return dt.Year + "/"
                                     + dt.Month.ToString("00") + "/" +
                                     dt.Day.ToString("00");
        }
        public static dynamic JsonDeserialize(string value)
        {
            var json = JsonConvert.DeserializeObject<JObject>(value);
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            dynamic dobj = jsonSerializer.Deserialize<dynamic>(json.ToString());
            return dobj;
        }

        public static string CombineValueWithDateTime(string value)
        {
            string result = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + value;
            return result;
        }

        public static string MiladiDateToJalaliDate(DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));
        }

        public static string Base64ToImage(string base64String, string imagePath, string imageName)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                string filePath = imagePath + imageName;
                File.WriteAllBytes(filePath, imageBytes);
                return imageName;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "crash";
            }
        }
        public static string Base64ToThumbnail(string base64String, string imagePath, string imageName)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Bitmap thumb = new Bitmap(100, 100);
                    using (Image bmp = Image.FromStream(ms))
                    {
                        using (Graphics g = Graphics.FromImage(thumb))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.DrawImage(bmp, 0, 0, 100, 100);
                        }
                    }
                    string filePath = imagePath + imageName;
                    MemoryStream stream = new MemoryStream();
                    thumb.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    Byte[] newBytes = stream.ToArray();
                    File.WriteAllBytes(filePath, newBytes);
                    return imageName;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "crash";
            }
        }

        public static string Base64ToFile(string base64String, string filePath, string fileName, string fileFormat)
        {
            try
            {
                if (fileFormat.ToLower() == ".jpeg" || fileFormat.ToLower() == ".mp4" || fileFormat.ToLower() == ".gif")                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    string Path = filePath + fileName + fileFormat;
                    File.WriteAllBytes(Path, imageBytes);
                    return fileName + fileFormat;
                }
                else
                {
                    return "InvalidFormat";
                }

            }
            catch
            {
                return "ConvertError";
            }
        }

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long DateTimeToTimestamp(DateTime value)
        {
            return (long)Math.Floor((value.ToUniversalTime() - UnixEpoch).TotalMilliseconds);
        }

        public static DateTime TimeStampToDateTime(long millis)
        {
            return UnixEpoch.AddMilliseconds(millis).ToLocalTime();
        }
        public static string FixText(string value)
        {
            return value.Trim().ToLower();
        }
        public static string ToPersianDate(this DateTime input, bool withTime = true, string dateSeperator = "/")
        {
            if (input == null) return String.Empty;
            PersianCalendar pCal = new PersianCalendar();
            string returnValue = String.Format("{1:0000}{0}{2:00}{0}{3:00}", dateSeperator, pCal.GetYear(input), pCal.GetMonth(input), pCal.GetDayOfMonth(input));
            if (withTime) returnValue += String.Format(" {0:00}:{1:00}:{2:00}", input.Hour, input.Minute, input.Second);
            return returnValue;
        }
    }
}
