using AutoMapper;
using CarApplication.DAL.Models;
using CarApplication.PL.ViewModels;

namespace CarApplication.PL.MappingProfiles
{
    public class CarProfile : Profile
    {

        public CarProfile()
        {
            //CreateMap<CarViewModel, Car>()
            //    // join the list into a comma-separated string
            //    .ForMember(dest => dest.Features,
            //               opt => opt.MapFrom(src =>
            //                   src.Features != null && src.Features.Any()
            //                     ? string.Join(",", src.Features)
            //                     : null))
            //    //// use the VM.ImageFiles (set after upload) for the entity.Images
            //    //.ForMember(dest => dest.ImageName,
            //    //           opt => opt.MapFrom(src => src.Image))
            //    .ReverseMap();

            //=================================================================================

            // ViewModel → Entity
            CreateMap<CarViewModel, Car>()
                .ForMember(dest => dest.ImageName,
                           opt => opt.MapFrom(src => src.ImageName))
                .ForMember(dest => dest.Features,
                           opt => opt.MapFrom(src =>
                               src.Features != null && src.Features.Any()
                                 ? string.Join(",", src.Features)
                                 : null));

            // Entity → ViewModel
            CreateMap<Car, CarViewModel>()
                .ForMember(dest => dest.ImageName,
                           opt => opt.MapFrom(src => src.ImageName))
                .ForMember(dest => dest.Features,
                           opt => opt.MapFrom(src =>
                               !string.IsNullOrEmpty(src.Features)
                                 ? src.Features.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                               .Select(f => f.Trim())
                                               .ToList()
                                 : new List<string>()));




        }

    }
}
