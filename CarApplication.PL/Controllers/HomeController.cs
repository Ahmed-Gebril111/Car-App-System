using System.Diagnostics;
using AutoMapper;
using CarApplication.BLL.Interfaces;
using CarApplication.DAL.Models.Enums;
using CarApplication.PL.Models;
using CarApplication.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarApplication.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,ICarRepository carRepository,IMapper mapper)
        {
            _logger = logger;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }


        public IActionResult Sale()
        {
            // 1) Pull & filter your car entities  
            var saleEntities = _carRepository
                .GetAll()
                .Where(c => c.OperationType == OperationType.Sale)
                .ToList();

            // 2) AutoMap to your view-models
            var saleVMs = _mapper.Map<List<CarViewModel>>(saleEntities);

            // 3) Pass to the view
            return View(saleVMs);
        }


        public IActionResult Rent()
        {
            // 1) Pull your car entities from the database
            var RentEntities = _carRepository
                           .GetAll()
                           .Where(c => c.OperationType == OperationType.Rent)
                           .ToList();
            // 2) Map to your view models
            var rentVMs = _mapper.Map<List<CarViewModel>>(RentEntities);


            // 3) Pass that list into the view
            return View(rentVMs);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
