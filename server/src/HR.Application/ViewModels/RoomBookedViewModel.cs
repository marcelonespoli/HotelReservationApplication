using System;

namespace HR.Application.ViewModels
{
    public class RoomBookedViewModel
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public DateTime Date { get; set; }
    }
}
