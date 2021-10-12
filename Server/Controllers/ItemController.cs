using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DockerTraining.Shared;
using DockerTraining.Server.Data;

namespace DockerTraining.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly ItemRepo itemRepo;

        public ItemController(ILogger<ItemController> logger, ItemRepo _itemRepo) 
        {
            _logger = logger;
            itemRepo = _itemRepo;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return itemRepo.GetAllItems();
        }

        [HttpGet("{id}")]
        public Item GetSpecificItem(int id)
        {
            return itemRepo.GetItemById(id);
        }

        [HttpPost]
        public void CreateItem(Item item)
        {
            itemRepo.CreateItem(item);
        }
    }
}
