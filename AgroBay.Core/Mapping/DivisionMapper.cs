using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  public class DivisionMapper
  {

    public  PurposeDivision GetDivision(FormPurposeDivisionViewModel input)
    {
      PurposeDivision purposeDivision = new PurposeDivision()
      {
        Name = input.Name,
        Id = 0
      };
      try
      {
        purposeDivision.Id = (int)input.Id;
      }
      catch 
      {

      }

      return purposeDivision;
    }
  }
}
