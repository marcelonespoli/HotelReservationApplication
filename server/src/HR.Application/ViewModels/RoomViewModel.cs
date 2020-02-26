using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.Application.ViewModels
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hotel is required")]
        public Guid HotelId { get; set; }

        public ICollection<RoomBookedViewModel> RoomsBooked { get; set; }

        public RoomViewModel()
        {
            RoomsBooked = new List<RoomBookedViewModel>();
        }
    }
}
