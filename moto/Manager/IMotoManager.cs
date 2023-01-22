using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moto.Models
{
    public interface IMotoManager
    {
        Motors GetFromDb(int id);
        List<Motors> ListFromDb();
        void AddToDb(Motors motor);
        void EditToDb(Motors motor);
        void DeleteFromDb(int id);
        void Sold(int id);
        void AddOrder(Orders order);
    }
}
