using ComputerStore_DataAccessLayer;
using DTOs;
using System;
using System.Data;

namespace ComputerStore_BusinessLayer
{
    public class clsLoginRecord
    {

        public LoginRecordDto loginRecordDto { get {
                return new LoginRecordDto(this.ID, this.UserID, this.LoginTime, this.LoginStatus, this.FailureReason);
            } }

        public int? ID { get; set; }
        public int? UserID { get; set; }
        public DateTime? LoginTime { get; set; }
        public bool LoginStatus { get; set; }
        public string? FailureReason { get; set; }


        public clsLoginRecord(LoginRecordDto loginRecordDto)
        {
            this.ID = loginRecordDto.ID;
            this.UserID = loginRecordDto.UserID;
            this.LoginTime = loginRecordDto.LoginTime;
            this.LoginStatus = loginRecordDto.LoginStatus;
            this.FailureReason = loginRecordDto.FailureReason;
        }

        private bool _AddNewLoginRecord()
        {
            return clsLoginRecordData.AddNewLoginRecord(this.UserID, this.LoginStatus, this.FailureReason) != null;
        }

        public bool Save()
        {
            if (_AddNewLoginRecord())
            {
                return true;
            }
            return false;
        }

        public static clsLoginRecord Find(int id)
        {
            LoginRecordDto loginRecordDto = clsLoginRecordData.GetLoginRecordByID(id);

            if (loginRecordDto is not null)
            {
                return new clsLoginRecord(loginRecordDto);
            }

            return null;
        }

        public static DataTable GetAllLoginRecords()
        {
            return clsLoginRecordData.GetAllLoginRecords();
        }

        public static int? GetLoginRecordsCount()
        {
            return clsLoginRecordData.GetLoginRecordsCount();
        }
    }
}
