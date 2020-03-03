using AutoMapper;
using Library.Data.Models;

namespace LibraryApi.Models.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<Book, BookModel>();
        }
    }
}