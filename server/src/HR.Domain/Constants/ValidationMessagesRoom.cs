namespace HR.Domain.Constants
{
    public class ValidationMessagesRoom
    {
        public const string Error_Name_NoEmpity = "Name is required";
        public const string Error_Name_Length = "Name needs to be between 2 and 150 characters";

        public const string Error_HotelId_NullOrEmpty = "Room must be associated with a Hotel";
    }
}
