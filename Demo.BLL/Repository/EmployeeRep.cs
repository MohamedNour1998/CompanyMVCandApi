using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
   public class EmployeeRep :IEmployeeRep
    {
        private readonly DemoContext db;

        public EmployeeRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> Get()
        {
            var data = GetEmployee();
            return data;
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public Employee Create(Employee odj)
        {

            db.Employee.Add(odj);
            db.SaveChanges();
            return db.Employee.OrderBy(a => a.Id).LastOrDefault();  //for API
        }

        public Employee Edit(Employee odj)
        {
            //var olddata = db.Department.Find(odj.Id);

            //olddata.Name = odj.Name;
            //olddata.Code = odj.Code;

            db.Entry(odj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return db.Employee.Find(odj.Id);
        }

        public void Delete(Employee odj /*int id*/)
        {
            // var olddata = db.Department.Find(id);
            //db.Department.Remove(olddata);
            db.Employee.Remove(odj);
            db.SaveChanges();
        }

        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Include("Department").Where(a => a.Name.Contains( Name));
            return data;
        }



        //==================Refactor==============
        private IEnumerable<Employee> GetEmployee()
        {
            return db.Employee.Include("Department").Include("District").Select(a => a);
        }

      
    }
}
