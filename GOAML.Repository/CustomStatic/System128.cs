using System;
using System.Globalization;
using System.Linq;
using GOAML.DomainModels.GlobalVariable;
using Enum = GOAML.Repository.Helper.Enum;


namespace GOAML.Repository.CustomStatic
{
    public static class System128
    {
        public static DateTime GetToday { get { return DateTime.Today; } }
        public static string GenerateGuid()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var guid = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return guid;
        }

        public static string PasswordGenerator()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#*$!";
            var random = new Random();
            var passwordGenerator = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return passwordGenerator;
        }
        
        public static string GenerateSerial(string title, long lastId, string profileCode)
        {
            var serial = lastId.ToString(CultureInfo.InvariantCulture).PadLeft(lastId.ToString(CultureInfo.InvariantCulture).Length + 6 - lastId.ToString(CultureInfo.InvariantCulture).Length, '0');
            return title + profileCode + GetCurrentDateTimeForOnlineServer().ToString("yy") + serial;
        }

        public static string GenerateCode(string title, long lastId)
        {
            var serial = lastId.ToString(CultureInfo.InvariantCulture).PadLeft(lastId.ToString(CultureInfo.InvariantCulture).Length + 6 - lastId.ToString(CultureInfo.InvariantCulture).Length, '0');
            return title + serial;
        }
        public static DbResponse SuccessMessage(object param)
        {
            return new DbResponse { Message = "Saved Successfully.", MessageType = (int)Enum.ResponseCode.Success, ReturnValue = param };
        }

        public static DbResponse FailureMessage(object param)
        {
            return new DbResponse { Message = "Save failed.", MessageType = (int)Enum.ResponseCode.Failed, ReturnValue = param };
        }

        public static DbResponse ExistMessage(object param)
        {
            return new DbResponse { Message = "Data Already Exist.", MessageType = (int)Enum.ResponseCode.Exist, ReturnValue = param };
        }
        public static DbResponse ExceptionMessage(Exception e)
        {
            return new DbResponse { Message = e.Message, MessageType = (int)Enum.ResponseCode.Error, ReturnValue = e.ToString() };
        }

        public static DbResponse NotExistMessage(object param)
        {
            return new DbResponse { Message = "Data Not Found.", MessageType = (int)Enum.ResponseCode.NotExist, ReturnValue = param };
        }

        public static DbResponse DeleteMessage(object param)
        {
            return new DbResponse { Message = "Data Deleted.", MessageType = (int)Enum.ResponseCode.Success, ReturnValue = param };
        }

        public static DbResponse DeleteFailureMessage(object param)
        {
            return new DbResponse { Message = "Delete Failed.", MessageType = (int)Enum.ResponseCode.Failed, ReturnValue = param };
        }

        public static DbResponse UnauthorizedMessage(object param)
        {
            return new DbResponse { Message = "Unauthorized Request.", MessageType = (int)Enum.ResponseCode.Warning, ReturnValue = param };
        }
       
        public static DateTime GetCurrentDateTimeForOnlineServer()
        {
            return DateTime.Now.AddHours(13);
        }
    }
}
