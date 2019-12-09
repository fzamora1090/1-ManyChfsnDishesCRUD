using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// NEEDED TO BE ABLE TO USE EF FRAMEWORK

namespace Chefs_n_Dishes.Models
{
    public class ChefsnDishesDBContext : DbContext
    {
        public ChefsnDishesDBContext(DbContextOptions options) : base(options){ }
       // Added DBContext interface with base options to import default params for the dbcontext "constructor"
        public  DbSet<Chef> Chefs { get;set; }
        // added DbSet for each schema and DB TITLE OF THE TABLES TO BE CREATED; that i will be using this app
        public DbSet<Dish> Dishes { get;set; }

        
    }
}