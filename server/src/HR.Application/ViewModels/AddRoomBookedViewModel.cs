using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Application.ViewModels
{
    public class AddRoomBookedViewModel
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
