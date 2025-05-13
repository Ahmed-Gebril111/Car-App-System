using CarApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.BLL.Interfaces
{
    public interface ICarRepository
    {

        IEnumerable<Car> GetAll();
        Car GetById(int id);
        int Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
