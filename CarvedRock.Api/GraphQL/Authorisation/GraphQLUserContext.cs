using System.Collections.Generic;
using System.Security.Claims;

namespace CarvedRock.Api.GraphQL.Authorisation
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}