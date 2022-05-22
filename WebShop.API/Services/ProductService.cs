using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebShop.API.Data;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;
using WebShop.API.Models.ViewModels.FilterData;
using WebShop.API.Models.ViewModels.Product;

namespace WebShop.API.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> GetProductByName(string productName)
        {
            if (await _db.Products.AnyAsync(x => x.Name == productName))
                return true;
            else return false;
        }

        public async Task CreateProductAsync(CreateProduct product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            await _db.Products.AddAsync(productEntity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(ProductEntity product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>> ReadAllProductsAsync()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }

        public async Task<ProductViewModel> ReadSingleProductAsync(int id)
        {
            var productEntity = await _db.Products.Include(x => x.BrandEntity).FirstOrDefaultAsync();
            return _mapper.Map<ProductViewModel>(productEntity);
        }

        public async Task UpdateProductAsync(UpdateProduct product)
        {
            var productEntity = _mapper.Map<UpdateProduct>(product);
            _db.Update(productEntity);
            await _db.SaveChangesAsync();

        }



        public async Task<FilterViewModel> GetFilterData()
        {
            var filterData = new FilterViewModel();
            filterData.Categories = await FilterDataForCategories();
            filterData.Colors = await FilterDataForColor();
            filterData.Sizes = await FilterDataForSizes();
            return filterData;
        }

        private async Task<ICollection<CategoryFilterOption>> FilterDataForCategories()
        {
            var categories = _db.Categories.Include(x=>x.Products);
            var categoryOptions = new List<CategoryFilterOption>();
            foreach (var category in categories)
            {
                var cfo = new CategoryFilterOption();

                cfo.Category = category.Category;
                cfo.Count = category.Products?.Count== null ? 0: category.Products.Count;
                categoryOptions.Add(cfo);
            }
            return categoryOptions;
        }

        private async Task<ICollection<SizeFilterOption>> FilterDataForSizes()
        {
            var sizes = _db.Sizes.Include(x=>x.Products);
            var sizeOptions = new List<SizeFilterOption>();
            foreach (var size in sizes)
            {
                var cfo = new SizeFilterOption();

                cfo.Size = size.Size;
                cfo.Count = size.Products?.Count== null ? 0: size.Products.Count;
                sizeOptions.Add(cfo);
            }
            return sizeOptions;
        }

        private async Task<ICollection<ColorFilterOption>> FilterDataForColor()
        {
            var colors = _db.Colors.Include(x=>x.ProductColors).ThenInclude(y=>y.Product);
            var colorOptions = new List<ColorFilterOption>();
            foreach (var color in colors)
            {
                var cfo = new ColorFilterOption();

                cfo.Color = color.Color;
                cfo.Hex = color.Hex;
                cfo.Count = color.ProductColors?.Count== null ? 0: color.ProductColors.Count;
                colorOptions.Add(cfo);
            }
            return colorOptions;
        }

        public async Task<IEnumerable<ProductEntity>> GetFilteredProductsAsync(Filter filter)
        {
            Type t = filter.GetType();
            IQueryable<ProductEntity> query = _db.Products;
            foreach (var item in t.GetProperties())
            {
                if (item.GetValue(filter, null).ToString() is not "")
                    query = Querybuilder(item.ToString().Split(' ')[1], item.GetValue(filter, null).ToString(), query);
            }
            query = QueryOrderbuilder(filter.OrderByAsc, query);
            query = Pagebuilder(filter.DisplayCount, filter.Page, query);
            return await query.ToListAsync();
        }

        private IQueryable<ProductEntity> Querybuilder(string prop, string value, IQueryable<ProductEntity> query)
        {
            switch (prop)
            {
                case "Category":
                    return FilterByCategories(value, query);
                case "Color":
                    return FilterByColors(value, query);
                case "Size":
                    return FilterBySizes(value, query);
                case "Brand":
                    return FilterByBrands(value, query);
                case "OnSale":
                    return FilterByOnSale(query);
                case "InStock":
                    return FilterByInStock(query);
                default:
                    return null;
            }
        }

        private IQueryable<ProductEntity> QueryOrderbuilder(bool isAscending, IQueryable<ProductEntity> query, string property = "name")
        {
            switch (property)
            {
                case "name":
                    return OrderByName(isAscending, query);
                default:
                    return query;
            }
        }

        private IQueryable<ProductEntity> Pagebuilder(int displayCount, int page, IQueryable<ProductEntity> query)
        {
            return query
                   .Skip(displayCount * (page - 1))
                   .Take(displayCount);
        }
        #region Filters
        private IQueryable<ProductEntity> FilterByCategories(string category, IQueryable<ProductEntity> query)
        {
            return query.Where(x => x.Category == category);
        }

        private IQueryable<ProductEntity> FilterByColors(string color, IQueryable<ProductEntity> query)
        {
            //return query.Where(x => x.Color == color);
            return query;
        }

        private IQueryable<ProductEntity> FilterBySizes(string size, IQueryable<ProductEntity> query)
        {
            return query.Where(x => x.Size == size);
        }

        private IQueryable<ProductEntity> FilterByBrands(string brand, IQueryable<ProductEntity> query)
        {
            return query.Where(x => x.BrandId == int.Parse(brand));
        }

        private IQueryable<ProductEntity> FilterByOnSale(IQueryable<ProductEntity> query)
        {
            return query.Where(x => x.OnSale == true);
        }

        private IQueryable<ProductEntity> FilterByInStock(IQueryable<ProductEntity> query)
        {
            return query.Where(x => x.Quantity != 0);
        }

        private IQueryable<ProductEntity> OrderByName(bool isAscending, IQueryable<ProductEntity> query)
        {
            if (isAscending)
            {
                return query.OrderBy(x => x.Name);
            }
            else
            {
                return query.OrderByDescending(x => x.Name);
            }
        }


        #endregion
    }
}
