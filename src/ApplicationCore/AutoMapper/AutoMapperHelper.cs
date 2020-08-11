using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerFin.ApplicationCore.AutoMapper
{
    public static class AutoMapperHelper
    {
        public static IMapper CreateMapper()
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            return mapConfig.CreateMapper();
        }
    }
}
