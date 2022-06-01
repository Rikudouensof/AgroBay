using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
    public interface IUserAddressService
    {
        UserAdress Add(FormUserProductAddressViewModel input);
        UserAdress Delete(UserAdress address);
        UserAdress Edit(FormUserProductAddressViewModel input);
        DataUserAdressViewModel Get(int id);
        IEnumerable<DataUserAdressViewModel> GetAll();
    }
}