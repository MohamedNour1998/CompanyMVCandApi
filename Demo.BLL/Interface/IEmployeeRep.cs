using Demo.BL.Models;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
   public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();

        Employee GetById(int id);

        IEnumerable<Employee> SearchByName(string Name);

        //for mvc
        //void Create(Employee odj);

        Employee Create(Employee odj);    //for API
        //for mvc
       // void Edit(Employee odj);

        Employee Edit(Employee odj); //for API
        void Delete(Employee odj);
    }
}
