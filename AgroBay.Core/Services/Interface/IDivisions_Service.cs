using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
    public interface IDivisions_Service
    {
        Task<PurposeDivision> Add(FormPurposeDivisionViewModel input);
        PurposeDivision Delete(PurposeDivision division);
        Task<PurposeDivision> Edit(FormPurposeDivisionViewModel input);
        PurposeDivision Get(int id);
        IEnumerable<PurposeDivision> GetAll();
    }
}