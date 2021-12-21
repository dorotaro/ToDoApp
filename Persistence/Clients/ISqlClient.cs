using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public interface ISqlClient
    {
        Task Execute<T>(string query, object param=null);

        Task<IEnumerable<T>> Query<T>(string query, object param=null);


    }
}
