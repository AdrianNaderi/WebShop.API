using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebShop.API.Models.Entities
{
        public class TagEntity
        {
                [Key]
                public string Tag { get; set; }
                
        }
}
