using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Model;

namespace Theatre.Repository.Common
{
    public interface IPersonnelRepository
    {
        Task<List<Personnel>> GetAllPersonnelAsync();
        Task<List<Personnel>> GetPersonnelAsync(Guid id);
        Task<bool> AddPersonnelAsync(Personnel personnel);
        Task<bool> EditPersonnelAsync(Guid id, Personnel personnel);
        Task<bool> DeletePersonnelAsync(Guid id);
    }
}
