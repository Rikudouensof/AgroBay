using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IDivisions_Repository
  {
    PurposeDivision Add(PurposeDivision division);
    PurposeDivision Delete(PurposeDivision division);
    PurposeDivision Edit(PurposeDivision division);
    PurposeDivision Get(int id);
    IEnumerable<PurposeDivision> GetAll();
  }
}