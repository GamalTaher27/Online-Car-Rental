using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class Cars
    {
        public int id { get; set; }


        [Display(Name = "category")]
        public string category { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }


        [Display(Name = "Color")]
        public string Color { get; set; }


        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "NumberOfChairs")]
        public int NumberOfChairs { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public string Amount { get; set; }

    }
}