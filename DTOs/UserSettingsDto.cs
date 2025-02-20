using System;

namespace DTOs
{
    public  class UserSettingsDto
    {
        public string Title { get; set; }
        public int? UserID { get; set; }

        public UserSettingsDto(string title, int? userID)
        {
            this.Title = title;
            this.UserID = userID;
        }

        public UserSettingsDto() 
        {
            this.Title = null;
            this.UserID = null;
        }

    }
}
