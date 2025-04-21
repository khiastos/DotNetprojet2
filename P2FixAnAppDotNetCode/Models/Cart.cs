using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public List<CartLine> Lines = new List<CartLine>();


        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            bool IsLineAlreadyExist = false;

            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Product.Id == product.Id)
                {
                    Lines[i].Quantity++;
                    IsLineAlreadyExist = true;
                }
            }
            if (!IsLineAlreadyExist)
            {
                CartLine newCartLine = new CartLine();
                newCartLine.Quantity = quantity;
                newCartLine.Product = product;
                Lines.Add(newCartLine);
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            double totalValue = 0.0;
            for (int i = 0; i < Lines.Count; i++)
            {
                totalValue += Lines[i].Product.Price * Lines[i].Quantity;
            }
            return totalValue;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            double averageValue = 0.0;
            int totalQuantity = 0;
            for (int i = 0; i < Lines.Count; i++)
            {
                totalQuantity += Lines[i].Quantity;
            }
            if (totalQuantity != 0)
            {
                averageValue = GetTotalValue() / totalQuantity;
            }
            return averageValue;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Product.Id == productId)
                {
                    return Lines[i].Product;
                }
            }
            return null;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            Lines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
