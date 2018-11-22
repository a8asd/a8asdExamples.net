using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public class TransactionBlock : IDisposable
    {
        public TransactionBlock(DbName name)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            ;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
