using AutoMapper;
using Roldaice.Web.App_Start.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roldaice.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SelectListItemProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}