using CarApplication.BLL.Interfaces;
using CarApplication.DAL.Contexts;
using CarApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.BLL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly MVCAppDbContext _dbContext;

        public CarRepository(MVCAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Car> GetAll()
        {
            //return _dbContext.Cars
            //    .Include(c => c.ImageName)
            //    .ToList();
            return  _dbContext.Cars.ToList();

        }

        public Car GetById(int id)
        {
            //return _dbContext.Cars
            //    .Include(c => c.ImageName)
            //    .FirstOrDefault(c => c.Id == id);
            return _dbContext.Cars.Find(id);
        }

        public int Add(Car car)
        {
            _dbContext.Cars.Add(car);
            return _dbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            _dbContext.Cars.Update(car);
            _dbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            _dbContext.Cars.Remove(car);
            _dbContext.SaveChanges();
        }


    }
}
