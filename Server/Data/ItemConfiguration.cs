using DockerTraining.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTraining.Server.Data
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            var rng = new Random();
            builder.HasData(

               new Item("Wash clothes")
               {
                   Id = 1,
                   IsComplete = false
               },
               new Item("Get Coffee")
               {
                   Id = 2,
                   IsComplete = true
               },
               new Item("Call Dr Stone")
               {
                    Id = 3,
                    IsComplete = false
               },
               new Item("Buy Flowers for wife")
               {
                    Id = 4,
                    IsComplete = false
               }
           );

        }
    }
}
