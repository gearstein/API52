using API52.Context;
using API52.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Context : MyContext
        where Entity : class
    {
        public readonly MyContext MyContext;
        private readonly DbSet<Entity> entities;
        public GeneralRepository(MyContext myContext)
        {
            this.MyContext = myContext;
            entities = myContext.Set<Entity>();
        }
        public int Delete(Key key)
        {
            var find =  entities.Find(key);
            if(find != null)
            {
                entities.Remove(find);
            }
            return MyContext.SaveChanges();
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
        }

        public int Insert(Entity e)
        {
            entities.Add(e);
            var insert = MyContext.SaveChanges();
            return insert;
        }

        public int Update(Entity e, Key key)
        {
            MyContext.Entry(e).State = EntityState.Modified;
            MyContext.Update(e);
            return MyContext.SaveChanges();
        }
    }
}
