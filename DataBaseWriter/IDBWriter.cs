using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseWriter
{
    public interface IDBWriter
    {
        public void AddRequest(DBRequest request);
    }
}
