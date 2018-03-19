using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest_api.DB.DAOs
{
    interface IRepository<X>
    {
        List<X> GetAll();
        X GetByID(int id);
        void Insert(X item);
        void Delete(int id);
        void Update(X item);
    }
}
