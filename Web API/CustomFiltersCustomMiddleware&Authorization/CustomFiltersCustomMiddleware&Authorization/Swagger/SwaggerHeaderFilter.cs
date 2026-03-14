using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomFiltersCustomMiddleware_Authorization.Swagger
{
    public class SwaggerHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IOpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "username",
                In = ParameterLocation.Header,
                Required = false,
                Description = "Enter username: admin or user",
                Schema = new OpenApiSchema
                {
                    Type = JsonSchemaType.String
                }
            });
        }
    }
}