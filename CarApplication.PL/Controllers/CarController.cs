using AutoMapper;
using CarApplication.BLL.Interfaces;
using CarApplication.DAL.Models;
using CarApplication.PL.Helpers;
using CarApplication.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarApplication.PL.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(CarViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.ImageName = DocumentSettings.UploadFile(model.Image, "Images");
                var MappedCar = _mapper.Map<CarViewModel, Car>(model);
                int Result =  _carRepository.Add(MappedCar);
                if (Result > 1)
                {
                    TempData["Success"] = "Car has been added successfully.";
                }
            }
            return RedirectToAction(nameof(Index), "Home");

        }

        //public IActionResult Details()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Details(int id)
        {
            // 1) Fetch the entity
            var carEntity = _carRepository.GetById(id);
            if (carEntity == null)
                return NotFound();          // or Redirect/Show an error page

            // 2) Map to VM
            var vm = _mapper.Map<CarViewModel>(carEntity);

            // 3) Pass into the view
            return View(vm);
        }




    }
}
