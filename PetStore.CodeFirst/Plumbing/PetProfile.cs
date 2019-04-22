using AutoMapper;
using PetStore.CodeFirst.Models;
using PetStore.Core;

namespace PetStore.CodeFirst.Plumbing
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetViewModel>().ReverseMap();
            CreateMap<Cat, CatViewModel>().IncludeBase<Pet, PetViewModel>().ReverseMap();
            CreateMap<Dog, DogViewModel>().IncludeBase<Pet, PetViewModel>().ReverseMap();
        }
    }
}