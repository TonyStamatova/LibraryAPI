using AutoMapper;

using Library.Data.Models;

namespace LibraryApi.Models.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            this.CreateMap<Author, AuthorModel>()
                .ReverseMap();
        }
    }
}