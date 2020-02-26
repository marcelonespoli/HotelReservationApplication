﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Application.ViewModels
{
    public class RoomBookedViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Room is required")]
        public Guid RoomId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
