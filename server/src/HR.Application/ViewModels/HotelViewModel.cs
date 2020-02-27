using System;
using System.Collections.Generic;

namespace HR.Application.ViewModels
{
    public class HotelViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        
        public string City { get; set; }

        public string Phone { get; set; }

        public int Stars { get; set; }

        public ICollection<RoomViewModel> Rooms { get; set; }

        public HotelViewModel()
        {
            Rooms = new List<RoomViewModel>();
        }
    }
}
