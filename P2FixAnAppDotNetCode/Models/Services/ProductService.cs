using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts().ToList();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            List<Product> products = GetAllProducts();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    return products[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            if (cart is not null)
            {
                foreach (CartLine line in cart.Lines)
                {
                    _productRepository.UpdateProductStocks(line.Product.Id, line.Quantity);
                }
            }
        }
    }
}
