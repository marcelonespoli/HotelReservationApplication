using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HR.Application.ViewModels
{
    public class CreateHotelViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Stars is required")]
        public int Stars { get; set; }
    }
}
