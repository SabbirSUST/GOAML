using System.Collections.Generic;

namespace GOAML.DomainModels.GlobalVariable
{
    public class LogInInfo
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long ProfileId { get; set; }
        public string ProfileCode { get; set; }
        public string ProfileName { get; set; }
        //public List<RolePermission> RolePermissions { get; set; }
        public string RoleName { get; set; }
        public long RoleId { get; set; }
        public bool PermissionType { get; set; }

        public List<bool> AccessList { get; set; }
        public List<string> ServiceList { get; set; }
        public string IpAddress { get; set; }
        public string ClientServiceSerial { get; set; }
        public bool LiveStatus { get; set; }
        public LogInInfo() { }
    }
}