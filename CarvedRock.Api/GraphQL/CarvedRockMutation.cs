using CarvedRock.Api.Data.Entities;
using CarvedRock.Api.GraphQL.Messaging;
using CarvedRock.Api.GraphQL.Types;
using CarvedRock.Api.Repositories;
using GraphQL;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation : ObjectGraphType
    {
        public CarvedRockMutation(ProductReviewRepository reviewRepository,
            ReviewMessageService reviewMessageService)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>> {Name = "review"}),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    await reviewRepository.AddReview(review);
                    reviewMessageService.AddReviewAddedMessage(review);
                    return review;
                });
        }
    }
}