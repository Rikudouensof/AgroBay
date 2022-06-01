using AgroBay.Core.Data;
using AgroBay.Core.Mapping;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.Services.Interface;
using AgroBay.Core.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
    public class UserAddressService : IUserAddressService
    {
        private IUserRepository _repoUser;
        private IUserAddressRepository _repoUserAdress;
        private IHostingEnvironment _env;
        public UserAddressService(IUserAddressRepository userAddressRepository, IUserRepository userRepository, IHostingEnvironment hostingEnvironment)
        {
            _repoUserAdress = userAddressRepository;
            _repoUser = userRepository;
        }


        public DataUserAdressViewModel Get(int id)
        {
            var adress = _repoUserAdress.Get(id);
            var user = _repoUser.Get(adress.UserId);

            DataUserAdressViewModel dataUserAdressViewModel = new DataUserAdressViewModel()
            {
                User = user,
                UserAdress = adress
            };
            return dataUserAdressViewModel;
        }

        public IEnumerable<DataUserAdressViewModel> GetAll()
        {
            var address = _repoUserAdress.GetAll();
            List<DataUserAdressViewModel> addresses = new List<DataUserAdressViewModel>();


            foreach (var item in address)
            {
                try
                {
                    var dataSubcat = Get(item.Id);
                    addresses.Add(dataSubcat);
                }
                catch
                {

                }
            }



            return addresses;
        }

        public UserAdress Add(FormUserProductAddressViewModel input)
        {
            UserAddressMaping userAddressMapping = new UserAddressMaping();
            var address = userAddressMapping.GetUserAdress(input);

            var answer = _repoUserAdress.Add(address);




            return answer;
        }

        public UserAdress Edit(FormUserProductAddressViewModel input)
        {
            UserAddressMaping userAddressMapping = new UserAddressMaping();
            var address = userAddressMapping.GetUserAdress(input);

            var answer = _repoUserAdress.Edit(address);

            return answer;
        }

        public UserAdress Delete(UserAdress address)
        {
            var answer = _repoUserAdress.Delete(address);
            return answer;
        }
    }
}

