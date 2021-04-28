using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IAliasRepository
    {
        IEnumerable<Alias> GetAliases();
        Alias GetAliasById(int id);
        void CreateAlias(Alias alias);
        void DeleteAlias(int aliasId);
        void UpdateAlias(Alias alias);
        void Save();
    }
}
