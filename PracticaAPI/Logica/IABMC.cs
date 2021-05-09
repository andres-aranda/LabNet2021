using System.Collections.Generic;

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
