using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.Application.ViewModels
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hotel is required")]
        public Guid HotelId { get; set; }

        public ICollection<AddRoomBookedViewModel> RoomsBooked { get; set; }

        public CreateRoomViewModel()
        {
            RoomsBooked = new List<AddRoomBookedViewModel>();
        }
    }
}
