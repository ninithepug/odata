using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using c4codata;
using DummyTest.Data;

namespace DummyODataTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder
            {
                Namespace = "c4codata",
                ContainerName = "c4codata"
            };


            builder.EntitySet<OrderDTO>("Order").EntityType
                .HasKey(t => t.OrderID);
            builder.EntitySet<OrderLineDTO>("OrderLine").EntityType.HasKey(t => t.OrderLineID);
           
            //entityset.EntityType.HasKey(e => new { e.CustomerID });
            config.Routes.MapODataRoute(
                "ODataRoute",
                "odata",
                builder.GetEdmModel());
        }
    }
}
