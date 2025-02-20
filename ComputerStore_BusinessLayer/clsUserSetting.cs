using ComputerStore_DataAccessLayer;
using DTOs;
using System;

namespace ComputerStore_BusinessLayer
{
    public class clsUserSetting
    {

        public string Title { get; set; }
        public int? UserID { get; set; }
        public clsUser UserInfo { get; }
        public UserSettingsDto userSettingsDto
        {
            get { return new(this.Title, this.UserID); }
        }

        public clsUserSetting(UserSettingsDto userSettingsDto)
        {
            this.Title = userSettingsDto.Title;
            this.UserID = userSettingsDto.UserID;
            this.UserInfo = clsUser.Find(UserID);
        }

        private bool _UpdateUserSetting()
        {
            return clsUserSettingData.UpdateUserSetting(this.userSettingsDto);
        }

        public bool Save()
        {
            return _UpdateUserSetting();
        }

        public static clsUserSetting Find(string Title)
        {
            UserSettingsDto userSettingsDto = clsUserSettingData.FindUserSettingByTitle(Title);

            if (userSettingsDto is not  null)
            {
                return new clsUserSetting(userSettingsDto);
            }
            return null;
        }

        public static int? GetCurrentUserID()
        {
            return clsUserSettingData.GetCurrentUserID();
        }

    }
}
