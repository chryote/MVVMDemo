using DBServices.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Services
{
    public interface ICRUDService
    {
        Task<bool> Create(
            string name,
            string email,
            int age,
            string gender,
            string password
        );
        Task<Array> FindID(int id);
        Task<bool> Update(int id);
        bool Delete(int id);
    }
}
