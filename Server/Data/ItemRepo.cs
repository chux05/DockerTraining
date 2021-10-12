using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DockerTraining.Server;
using DockerTraining.Shared;
using Microsoft.EntityFrameworkCore;

namespace DockerTraining.Server.Data
{
    public class ItemRepo : IItemRepo
    {
        protected readonly AppDbContext _context;

        public ItemRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Add(item);

        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
