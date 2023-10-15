using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer__CRUD_
{
    public interface IDb<T,K>
    {
        Task CreateAsync(T item);

        Task<T> ReadAsync(K key, bool useNavigationalProperties = false, bool isReadOnly = true);

        Task<ICollection<T>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true);

        Task UpdateAsync(T item, bool useNavigationalProperties = false);

        Task DeleteAsync(K key);
    }
}
