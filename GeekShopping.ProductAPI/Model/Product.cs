﻿using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public required string Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public required string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public required string ImageURL { get; set; }
    }
}
