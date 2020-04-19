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
                    m => m.Genre, 
                    opt => opt.MapFrom(
                        b => Enum.GetName(typeof(Genre), b.Genre)))
                .ForMember(
                    m => m.GenreType,
                    opt => opt.MapFrom(
                        b => Enum.GetName(typeof(GenreType), b.GenreType)))
                .ForMember(
                    m => m.Language, 
                    opt => opt.MapFrom(
                        b => Enum.GetName(typeof(Language), b.Language)))
                .ForMember(
                    m => m.KeyWords, 
                    opt => opt.MapFrom(
                        b => b.KeyWords.Select(kw => kw.KeyWord.Word).ToList()));

            this.CreateMap<BookModel, Book>()
                .ForMember(
                    b => b.Author,
                    opt => opt.MapFrom(
                        m => m.Author))
                .ForMember(
                    b => b.Genre,
                    opt => opt.MapFrom(
                        m => Enum.Parse(typeof(Genre), m.Genre)))
                .ForMember(
                    b => b.Language,
                    opt => opt.MapFrom(
                        m => Enum.Parse(typeof(Language), m.Language)))
                .ForMember(
                    b => b.KeyWords,
                    opt => opt.MapFrom(
                        m => m.KeyWords
                            .Select(str => new BookKeyWord
                            {
                                KeyWord = new KeyWord
                                {
                                    Word = str
                                }
                            })))
                .AfterMap(
                    (m, b) => b.GenreType = 
                        b.Genre == 0
                            ? GenreType.Other
                            : (int)b.Genre < 100
                                ? GenreType.Fiction
                                : GenreType.NonFiction)
                .AfterMap(
                    (m, b) => b.ContentPath = string.Empty);
        }
    }
}