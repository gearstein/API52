using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Repository.Interfaces
{
    public interface IRepository <Entity,Key> where Entity : class
    {
        IEnumerable<Entity> Get(); //Sama seperti List (menampung banyak data tabel employee)
        Entity Get(Key key); //hanya dapat menampung satu data tabel employee
        int Insert(Entity e);
        int Update(Entity e, Key key);
        int Delete(Key key);
    }
}
