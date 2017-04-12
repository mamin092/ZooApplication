﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewFood
    {
        public ViewFood(Food food)
        {
            Id = food.Id;
            Name = food.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
