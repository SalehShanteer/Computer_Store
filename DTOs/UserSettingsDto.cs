using System;

namespace DTOs
{
    public  class UserSettingsDto
    {
        public string? Title { get; set; }
        public int? UserID { get; set; }
        public UserDto UserInfo { get; set; }

        public UserSettingsDto(string? title, int? userID, UserDto userInfo)
        {
            this.Title = title;
            this.UserID = userID;
            this.UserInfo = userInfo;
        }

        public UserSettingsDto() 
        {
            this.Title = null;
            this.UserID = null;
            this.UserInfo = new UserDto();
        }

    }
}
