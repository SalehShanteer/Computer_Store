using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore_Business
{
    public class gvMessages
    {
       

        // Message boxes messages

        // Form
        public static string errorOpenFormMessag(string FormTitle)
        {
            return $"Error: Failed to {FormTitle} Form.";
        }

        // Saving
        public static string errorSaveMessage = "An error occurred while saving the data.";

        public static string errorSaveTitle = "Save error";

        public static string saveMessage(string entity)
        {
            return $"The {entity} has been saved successfully.";
        }
        public static string saveTitle(string entity)
        {
            return $"{entity} saved";
        }

        public static string askForSaveMessage(string entity)
        {
            return $"Are you sure you want to save {entity}?";
        }

        //Deleting

        public static string errorDeleteMessage = "An error occurred while deleting the data.";

        public static string errorDeleteTitle = "Delete error";

        public static string deleteMessage(string entity, int ID)
        {
            return $"The {entity} with ID = ({ID}) has been Deleted successfully.";
        }

        public static string deleteTitle(string entity)
        {
            return $"{entity} Deleted";
        }

        public static string askForDeleteMessage(string entity, int ID)
        {
            return $"Are you sure you want to delete {entity} with ID = ({ID})?";
        }

        //Login

        public static string errorLoginWrongPassword = "Inserted password is wrong";

        public static string errorLoginUsernameNotFound = "Username not found!";

        public static string errorLoginRegisterCurrentUser = "Error: Failed to register current user";

        // Error provider
        public static string errorProviderMessage = "Please ensure all required fields are filled out correctly. Check the error beside the field with the issue.";

        // Permissions messages
        public static string errorPermissionMessage = "You do not have permission to perform this action.";
        public static string errorPermissionTitle = "Permission Denied";




    }
}
