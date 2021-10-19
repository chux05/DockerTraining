using DockerTraining.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DockerTraining.Server.Data
{
    public interface IItemRepo
    {
        IEnumerable<Item> GetAllItems();

        Item GetItemById(int id);

        void CreateItem(Item item);

        public bool SaveChanges();

    }
}
