using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class LoginRecordValidation
    {
        public static bool ValidateLoginRecord(LoginRecordDto loginRecord)
        {
            return loginRecord is not null && loginRecord.UserID is not null;
        }


    }
}
