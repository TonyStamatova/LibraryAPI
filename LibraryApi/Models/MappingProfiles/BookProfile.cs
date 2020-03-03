using System;
using System.Linq;

using AutoMapper;

using Library.Data.Models;
using Library.Data.Models.Enumerations;

namespace LibraryApi.Models.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<Book, BookModel>()
                .ForMember(
                    m => m.Author,
                    opt => opt.MapFrom(
                        b => string.Join(" ", new string[] { b.Author.FirstName, b.Author.MiddleName, b.Author.LastName, b.Author.Pseudonym }.Where(x => !string.IsNullOrWhiteSpace(x)))))
                .ForMember(
                    m => m.Genre, 
                    opt => opt.MapFrom(
                        b => Enum.GetName(typeof(Genre), b.Genre)))
                .ForMember(
                    m => m.Language, 
                    opt => opt.MapFrom(
                        b => Enum.GetName(typeof(Language), b.Language)))
                .ForMember(
                    m => m.KeyWords, 
                    opt => opt.MapFrom(
                        b => b.KeyWords.Select(kw => kw.KeyWord.Word).ToList()));
        }
    }
}