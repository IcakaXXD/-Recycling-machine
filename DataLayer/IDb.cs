using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public interface IDb<T, K> where K : IConvertible
    {
        void Create(T item);

        T Read(K key, bool useNavigationalProperties);

        IEnumerable<T> ReadAll(bool useNavigationalProperties);

        void Update(T item, bool useNavigationalProperties);

        void Delete(K key);


    }
}
