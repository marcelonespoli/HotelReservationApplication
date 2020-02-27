using System;
using System.Collections.Generic;

namespace HR.Application.ViewModels
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid HotelId { get; set; }

        public ICollection<RoomBookedViewModel> RoomsBooked { get; set; }

        public RoomViewModel()
        {
            RoomsBooked = new List<RoomBookedViewModel>();
        }
    }
}
