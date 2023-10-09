using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer__CRUD_
{
    public interface IDb<T,K>
    {
        void Create(T item);

        T Read(K key, bool useNavigationalProperties = false);

        IEnumerable<T> ReadAll(bool useNavigationalProperties = false);

        void Update(T item, bool useNavigationalProperties = false, bool readOnly = false);

        void Delete(K key, bool readOnly = false);
    }
}
