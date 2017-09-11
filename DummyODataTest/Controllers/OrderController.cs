using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using c4codata;
using DummyTest.Data;
using Dummy.Test.Helper;

namespace Dummy.Test.Controllers
{

    public class OrderController : ODataController
    {
        private readonly MapperConfiguration _config;
        private readonly Entities _ctx;

        public OrderController()
        {
            _ctx = new Entities();
            _ctx.Database.CommandTimeout = 300;

            //_ctx.GetService<ILoggerFactory>().AddProvider(new TraceLoggerProvider());

            _config = KitMapper.Instance.KitMapperConfig;
        }
        

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxTop = 100,
            MaxExpansionDepth = 5,
            MaxSkip = 100,
            PageSize = 100,
            HandleNullPropagation = HandleNullPropagationOption.True)]
        public IQueryable<OrderDTO> Get()
        {
            return _ctx.Orders
                .ProjectTo<OrderDTO>(_config);
        }



        // GET: odata/MdmCustomerTts(5)
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<OrderDTO> Get([FromODataUri] Guid key)
        {

            return _ctx.Orders.Where(t => t.OrderID == key)
                .ProjectTo<OrderDTO>(_config);
            ;
        }
    }
}