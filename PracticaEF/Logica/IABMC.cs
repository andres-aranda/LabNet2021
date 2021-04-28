using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    interface IABMC<T>
    {
        List<T> GetAll();

        T GetOne(int id);

        void Insert(T newEntity);

        void Update(T updatedEntity);

        void Delete(int id);

    }
}
