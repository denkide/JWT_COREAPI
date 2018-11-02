using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPSPApi.Models;

namespace WPSPApi.DataProvider
{
    public interface IPatrollerDataProvider
    {
        Task<IEnumerable<Patroller>> GetPatrollers();
        Task<Patroller> GetPatroller(int skiPatrolNumber);

        Task AddPatroller(Patroller p);

        Task UpdatePatroller(Patroller p);

        Task DeletePatroller(int skiPatrolNumber);
    }
}
