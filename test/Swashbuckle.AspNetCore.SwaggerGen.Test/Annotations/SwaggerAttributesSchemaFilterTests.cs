﻿using System;
using Xunit;
using Moq;
using Swashbuckle.AspNetCore.Swagger;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test
{
    public class SwaggerAttributesSchemaFilterTests
    {
        [Fact]
        public void Apply_DelegatesToSpecifiedFilter_IfTypeDecoratedWithFilterAttribute()
        {
            var schema = new Schema { };
            var filterContext = FilterContextFor(typeof(SwaggerAnnotatedType));

            Subject().Apply(schema, filterContext);

            Assert.NotEmpty(schema.Extensions);
        }

        private SchemaFilterContext FilterContextFor(Type type)
        {
            return new SchemaFilterContext(type, null, null);
        }

        private SwaggerAttributesSchemaFilter Subject()
        {
            return new SwaggerAttributesSchemaFilter(new Mock<IServiceProvider>().Object);
        }
    }
}