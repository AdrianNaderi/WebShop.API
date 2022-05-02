using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.Entities
{
        public class SizeEntity
        {
                [Key]
                public string Size { get; set; }

                [ValidateNever]
                public ICollection<ProductEntity> Products { get; set; }
        }
}
