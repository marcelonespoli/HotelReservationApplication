namespace HR.Domain.Constants
{
    public class ValidationMessagesHotel
    {
        public const string Error_Name_NotEmpty = "Name is required";
        public const string Error_Name_Length = "Name needs to be between 2 and 250 characters";

        public const string Error_Address_NotEmpty = "Address is required";
        public const string Error_Address_Length = "Address needs to be between 2 and 350 characters";

        public const string Error_City_NotEmpty = "City is required";
        public const string Error_City_Length = "City needs to be between 2 and 150 characters";

        public const string Error_Phone_NotEmpty = "Phone is required";
        public const string Error_Phone_Length = "Phone needs to be between 8 and 15 characters";

        public const string Error_Stars_Length = "Stars needs to be between 0 and 5";
    }
}
