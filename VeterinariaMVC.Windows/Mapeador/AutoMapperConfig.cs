using AutoMapper;
using VeterinariaMVC.Mappeador;

namespace VeterinariaMVC.Windows.Mapeador
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
