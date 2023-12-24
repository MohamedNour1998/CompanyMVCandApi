using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly DemoContext db;

        public CountryRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> Get()
        {
            var data = GetCountry();
            return data;
        }

        public Country GetById(int id)
        {
            var data = db.Country.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }


        //==================Refactor==============
        private IEnumerable<Country> GetCountry()
        {
            return db.Country.Select(a => a);
        }
    }
}
