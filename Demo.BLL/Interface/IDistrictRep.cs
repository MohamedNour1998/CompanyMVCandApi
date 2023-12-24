using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IDistrictRep
    {
        IEnumerable<District> Get(Expression<Func<District, bool>> filter = null);
        District GetById(int id);
    }
}
