using System;
using System.Linq;

using AutoMapper;

using Library.Data.Models;
using Library.Data.Models.Enumerations;

namespace LibraryApi.Models.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            this.CreateMap<Author, AuthorModel>();
        }
    }
}