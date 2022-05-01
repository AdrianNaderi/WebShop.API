using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.API.Models.Entities
{
        public class ProductTag
        {
                [ForeignKey("Product")]
                public int ProductId { get; set; }
                public Product Product { get; set; }

                [ForeignKey("Tag")]
                public string Tag { get; set; }
                public TagEntity TagEntity { get; set; }
        }
}
