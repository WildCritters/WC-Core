using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IFunctionRepository
    {
        IEnumerable<Function> GetFunctions();
    }
}
