using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
   public class DepartmentRep : IDepartmentRep
    {

        private readonly DemoContext db;

        public DepartmentRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Department> Get()
        {
            var data = GetDepartment();
            return data;
        }

        public Department GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Department odj)
        {
          
            db.Department.Add(odj);
            db.SaveChanges();
        }

        public void Edit(Department odj)
        {
            //var olddata = db.Department.Find(odj.Id);

            //olddata.Name = odj.Name;
            //olddata.Code = odj.Code;

            db.Entry(odj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Department odj /*int id*/)
        {
            // var olddata = db.Department.Find(id);
            //db.Department.Remove(olddata);
            db.Department.Remove(odj);
            db.SaveChanges();
        }

       

        //==================Refactor==============
        private IEnumerable<Department> GetDepartment()
        {
            return db.Department.Select(a => a);
        }
    }
}
