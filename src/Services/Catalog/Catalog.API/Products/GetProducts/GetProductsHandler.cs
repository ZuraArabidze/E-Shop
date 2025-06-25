namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session) 
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToPagedListAsync(
            (query.PageNumber is >= 1) ? query.PageNumber.Value : 1 , 
            (query.PageSize is >= 1) ? query.PageSize.Value :  10, 
            cancellationToken);

        return new GetProductsResult(products);
    }
}

