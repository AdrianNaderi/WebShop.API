using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.ViewModels.Product
{
    public class UpdateProduct
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
    }
}
