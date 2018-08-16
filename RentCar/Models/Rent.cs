using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace RentCar.Models
{
    public class Rent
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
       
        public int CarId { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        
        public double TotalAmount { get; set; }
        
        public string State { get; set; }



    }
}