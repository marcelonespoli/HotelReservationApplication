namespace HR.Domain.Constants
{
    public class ValidationMessagesRoomBooked
    {
        public const string Error_RoomId_NullOrEmpty = "Room booked must be associated with a Room";

        public const string Error_Date_Null = "Date is required";
        public const string Error_Date_GreaterThanOrEqualToday = "Date must to be greater than or equal today";
    }
}
