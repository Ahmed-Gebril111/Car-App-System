using CarApplication.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.DAL.Models
{
    public class Car
    {

        public int Id { get; set; }

        [Required]
        public OperationType OperationType { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        public int ModelYear { get; set; }

        public string Features { get; set; }


        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Required]
        [StringLength(50)]
        public string FuelType { get; set; }

        [Required]
        [StringLength(50)]
        public string EngineType { get; set; }

        [Required]
        public int Miles { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(500)]
        public string History { get; set; }

        [Required]
        [StringLength(50)]
        public string Transmission { get; set; }

        [Required]
        public int Seats { get; set; }

        public string ImageName { get; set; }

    }
}
