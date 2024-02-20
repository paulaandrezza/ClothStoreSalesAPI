﻿using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ClothStoreSalesAPI.RequestsModels
{
    public class CreateSaleRequest
    {
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public SaleItem[] Items { get; set; }
    }
}
