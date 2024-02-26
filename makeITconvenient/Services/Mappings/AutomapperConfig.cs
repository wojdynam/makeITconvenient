using AutoMapper;
using ComponentModules.BaseModule;
using makeITconvenient.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace makeITconvenient.Services.Mappings
{
    public static class AutomapperConfig
    {
        public static IMapper Initialize() =>
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDto, Person>().ReverseMap();
                cfg.CreateMap<ContactDetailsDto, ContactDetails>().ReverseMap();
                cfg.CreateMap<AddressDto, Address>().ReverseMap();
            }).CreateMapper();
    }
}
