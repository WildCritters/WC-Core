using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IPoolRepository
    {
        IEnumerable<Pool> GetPools();
        Pool GetPoolById(int id);
        void CreatePool(Pool pool);
        void DeletePool(int poolId);
        void UpdatePool(Pool pool);
        void Save();
    }
}
