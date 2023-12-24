using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
  public class DistrictRep :IDistrictRep
    {
        private readonly DemoContext db;

        public DistrictRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<District> Get(Expression<Func<District, bool>> filter = null)
        {
            if (filter == null)
            {
                var data = db.District.Select(a => a);
                return data;
            }
            else
            {
                return db.District.Where(filter);
            }
        }

        public District GetById(int id)
        {
            var data = db.District.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }


        //==================Refactor==============
        //private IEnumerable<District> GetDistrict()
        //{
        //    return db.District.Select(a => a);
        //}
    }
}
