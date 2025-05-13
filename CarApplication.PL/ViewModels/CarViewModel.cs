using CarApplication.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarApplication.PL.ViewModels
{
    public class CarViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a car type.")]
        [Display(Name = "Car Type")]
        public OperationType OperationType { get; set; }

        [Display(Name = "Car Features")]
        public List<string> Features { get; set; } = new List<string>();

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model year is required.")]
        [Display(Name = "Model Year")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(50)]
        public string Color { get; set; }

        [Required(ErrorMessage = "Fuel type is required.")]
        [Display(Name = "Fuel Type")]
        [StringLength(50)]
        public string FuelType { get; set; }

        [Required(ErrorMessage = "Engine type is required.")]
        [Display(Name = "Engine Type")]
        [StringLength(50)]
        public string EngineType { get; set; }

        [Required(ErrorMessage = "Mileage is required.")]
        public int Miles { get; set; }

        [Display(Name = "Description")]
        [StringLength(1000)]
        public string Description { get; set; }

        [Display(Name = "History")]
        [StringLength(500)]
        public string History { get; set; }

        [Required(ErrorMessage = "Transmission is required.")]
        [StringLength(50)]
        public string Transmission { get; set; }

        [Required(ErrorMessage = "Seats count is required.")]
        [Range(1, 50, ErrorMessage = "Seats must be between 1 and 50.")]
        public int Seats { get; set; }

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

    }
}
