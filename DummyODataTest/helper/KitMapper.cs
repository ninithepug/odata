using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using c4codata;
using DummyTest.Data;

namespace Dummy.Test.Helper
{

    public class KitMapper
    {
        private static readonly Lazy<KitMapper> Lazy =
            new Lazy<KitMapper>(() => new KitMapper());


        private KitMapper()
        {
            KitMapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AllowNullDestinationValues = true;
                    cfg.AllowNullCollections = true;
                    cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                    cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                    cfg.RecognizeDestinationPrefixes("DTO_");

                    cfg.CreateMap<Order, OrderDTO>()
                        .ForMember(d=>d.OrderLines,o=>o.AllowNull())
                        .ForMember(d=>d.OrderLines,o=>o.MapFrom(s=>s.OrderLines));
                    cfg.CreateMap<OrderLine, OrderLineDTO>();
                });
        }

        public static KitMapper Instance => Lazy.Value;

        public MapperConfiguration KitMapperConfig { get; set; }
    }
}