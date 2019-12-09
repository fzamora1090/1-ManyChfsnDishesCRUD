using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Chefs_n_Dishes.Models;

namespace Chefs_n_Dishes.Models
{
    public class MainModel
    {
        public Dish Dish {get;set;}
        public int ChefId {get;set;}
         public List<Chef> allChefs {get;set;}
    }
}