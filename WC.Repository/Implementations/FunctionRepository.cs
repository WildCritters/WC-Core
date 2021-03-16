using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Context;
using WC.Model;
using WC.Repository.Contracts;

namespace WC.Repository.Implementations
{
    public class FunctionRepository : IFunctionRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public FunctionRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Function> GetFunctions()
        {
            return context.Functions.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
