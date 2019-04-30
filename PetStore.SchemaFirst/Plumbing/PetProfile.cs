using AutoMapper;
using PetStore.SchemaFirst.Generated;

namespace PetStore.SchemaFirst.Plumbing
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Core.Pet, Pet>().ReverseMap();
            CreateMap<Core.Cat, Cat>().IncludeBase<Core.Pet, Pet>().ReverseMap();
            CreateMap<Core.Dog, Dog>().IncludeBase<Core.Pet, Pet>().ReverseMap();
        }
    }
}