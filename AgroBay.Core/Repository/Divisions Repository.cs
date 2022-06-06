using AgroBay.Core.Data;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Repository
{
  public class Divisions_Repository : IDivisions_Repository
  {
    private AgroBayDbContext _db;
    public Divisions_Repository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public PurposeDivision Get(int id)
    {
      var division = _db.PurposeDivisions.First(c => c.Id == id);
      _db.Entry<PurposeDivision>(division).State = EntityState.Detached;
      return division;
    }

    public IEnumerable<PurposeDivision> GetAll()
    {
      var division = _db.PurposeDivisions.OrderBy(m => m.Name);
      foreach (var item in division)
      {
        _db.Entry<PurposeDivision>(item).State = EntityState.Detached;
      }
      return division;
    }

    public  PurposeDivision Add(PurposeDivision division)
    {


      try
      {
         _db.PurposeDivisions.Add(division);
        _db.SaveChanges();
      }
      catch (Exception es)
      {

        throw;
      }
       
      return division;
    }

    public PurposeDivision Edit(PurposeDivision division)
    {
      _db.PurposeDivisions.Update(division);
      _db.SaveChanges();
      return division;
    }

    public PurposeDivision Delete(PurposeDivision division)
    {
      _db.PurposeDivisions.Remove(division);
      _db.SaveChanges();
      return division;
    }
  }
}
