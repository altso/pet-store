using AutoMapper;
using PetStore.Core;
using PetStore.SchemaFirst.Generated;

namespace PetStore.SchemaFirst.Plumbing
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetViewModel>().ReverseMap();
            //CreateMap<Cat, CatViewModel>().IncludeBase<Pet, PetViewModel>().ReverseMap();
            //CreateMap<Dog, DogViewModel>().IncludeBase<Pet, PetViewModel>().ReverseMap();
        }
    }
}