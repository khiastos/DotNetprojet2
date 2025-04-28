namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        Product[] GetAllProducts();

        int UpdateProductStocks(int productId, int quantityToRemove);
    }
}
