using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinariaMVC.Mappeador;

namespace VeterinariaMVC.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = config.CreateMapper();
        }

    }
}