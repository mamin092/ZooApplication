﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public class AnimalFood
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Food Food { get; set; }
        [Required]
        public double Quantity { get; set; }

    }
}
