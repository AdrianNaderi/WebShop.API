using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.API.Models.Entities;

namespace WebShop.Tests.UnitTests.Fixtures
{
    public class ProductFilterFixtures
    {
        public CategoryEntity Shoes;
        public CategoryEntity Hats;
        public CategoryEntity Jackets;

        public SizeEntity Medium;

        public BrandEntity Bexim;


        public ProductEntity Product_One;
        public ProductEntity Product_Two;
        public ProductEntity Product_Three;
        public ProductEntity Product_Four;


        public ProductFilterFixtures()
        {
            Shoes = new CategoryEntity() { Category = "Shoes"};
            Hats = new CategoryEntity() { Category = "Hats"};
            Jackets = new CategoryEntity() { Category = "Jackets"};
            Medium = new SizeEntity() { Size = "M" };
            Bexim = new BrandEntity() { BrandName = "Bexim", BrandId = 1, Description="Lorem Ipsum" };

            Product_One = new ProductEntity()
            {
                Id = 1,
                Name = "Product One",
                Description = "The First Product",
                Price = 100,
                OnSale = false,
                Category = Shoes.Category,
                Size = Medium.Size,
                BrandId = Bexim.BrandId,
                Quantity = 3,
                ImagePath = "/Img/Shoes"
            };
            Product_Two = new ProductEntity()
            {
                Id = 2,
                Name = "Product Two",
                Description = "The Second Product",
                Price = 100,
                OnSale = false,
                Category = Shoes.Category,
                Size = Medium.Size,
                BrandId = Bexim.BrandId,
                Quantity = 3,
                ImagePath = "/Img/Shoes"
            };
            Product_Three = new ProductEntity()
            {
                Id = 3,
                Name = "Product Three",
                Description = "The Third Product",
                Price = 100,
                OnSale = false,
                Category = Shoes.Category,
                Size = Medium.Size,
                BrandId = Bexim.BrandId,
                Quantity = 3,
                ImagePath = "/Img/Shoes"
            };
            Product_Four = new ProductEntity()
            {
                Id = 4,
                Name = "Product Three",
                Description = "The Third Product",
                Price = 100,
                OnSale = false,
                Category = Hats.Category,
                Size = Medium.Size,
                BrandId = Bexim.BrandId,
                Quantity = 3,
                ImagePath = "/Img/Hats"
            };

        }

    }
}
