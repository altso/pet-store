using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PetStore.CodeFirst.Plumbing
{
    public class XCorrelationIdFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "X-Correlation-ID",
                In = "header",
                Type = "string",
                Format = "uuid",
                Required = false,
            });
        }
    }
}