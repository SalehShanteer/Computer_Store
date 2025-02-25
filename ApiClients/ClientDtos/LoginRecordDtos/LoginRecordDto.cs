using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class LoginRecordDto
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public DateTime? LoginTime { get; set; }
        public bool LoginStatus { get; set; }
        public string FailureReason { get; set; }

        public LoginRecordDto()
        {
            this.ID = null;
            this.UserID = null;
            this.LoginTime = null;
            this.LoginStatus = false;
            this.FailureReason = null;
        }

        public LoginRecordDto(int? id, int? userID, DateTime? loginTime, bool loginStatus, string failureReason)
        {
            this.ID = id;
            this.UserID = userID;
            this.LoginTime = loginTime;
            this.LoginStatus = loginStatus;
            this.FailureReason = failureReason;
        }

    }
}
