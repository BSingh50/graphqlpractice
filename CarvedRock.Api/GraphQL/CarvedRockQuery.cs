using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL;
using GraphQL.Types;
using ProductType = CarvedRock.Api.GraphQL.Types.ProductType;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery: ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository productRepository,
            ProductReviewRepository productReviewRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll());
            
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    context.Errors.Add(new ExecutionError("Some error message"));
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetOne(id);
                });
            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>{Name = "productId"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("productId");
                    return productReviewRepository.GetProductReviews(id);
                });
        }
    }
}