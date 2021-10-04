using System.Security.Claims;
using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.GraphQL.Authorisation;
using CarvedRock.Api.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ProductReviewRepository productReviewRepository,
            IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the product");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced");
            Field(t => t.PhotoFileName).Description("The file name of the photo");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");

            Field<ListGraphType<ProductReviewType>>("reviews",resolve: context =>
            {
                var user = context.UserContext;
                var loader =
                    dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetReviewByProductId", productReviewRepository.GetProductReviewLookup);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}