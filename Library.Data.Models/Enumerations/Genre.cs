using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Library.Data.Models.Enumerations
{
    public enum Genre
    {
        [Description("Other")]
        Other = 0,

        #region Fiction

        [Description("Action and adventure")]
        ActionAndAdventure = 1,

        [Description("Alternate history")]
        AlternateHistory = 2,

        [Description("Anthology")]
        Anthology = 3,

        [Description("Chick lit")]
        ChickLit = 4,

        [Description("Children's")]
        Childrens = 5,

        [Description("Comic book")]
        ComicBook = 6,

        [Description("Coming-of-age")]
        ComingOfAge = 7,

        [Description("Crime")]
        Crime = 8,

        [Description("Drama")]
        Drama = 9,

        [Description("Fairytale")]
        Fairytale = 10,

        [Description("Fantasy")]
        Fantasy = 11,

        [Description("Graphic novel")]
        GraphicNovel = 12,

        [Description("Historical fiction")]
        HistoricalFiction = 13,

        [Description("Horror")]
        Horror = 14,

        [Description("Mystery")]
        Mystery = 15,

        [Description("Paranormal romance")]
        ParanormalRomance = 16,

        [Description("Picture book")]
        PictureBook = 17,

        [Description("Poetry")]
        Poetry = 18,

        [Description("Political thriller")]
        PoliticalThriller = 19,

        [Description("Romance")]
        Romance = 20,

        [Description("Satire")]
        Satire = 21,

        [Description("Science fiction")]
        ScienceFiction = 22,

        [Description("Short story")]
        ShortStory = 23,

        [Description("Suspense")]
        Suspense = 24,

        [Description("Thriller")]
        Thriller = 25,

        [Description("Young adult")]
        YoungAdult = 26,

        #endregion

        #region Non-fiction

        [Description("Art")]
        Art = 101,

        [Description("Autobiography")]
        Autobiography = 102,

        [Description("Biography")]
        Biography = 103,

        [Description("Book review")]
        BookReview = 104,

        [Description("Cookbook")]
        Cookbook = 105,

        [Description("Diary")]
        Diary = 106,

        [Description("Dictionary")]
        Dictionary = 107,

        [Description("Encyclopedia")]
        Encyclopedia = 108,

        [Description("Guide")]
        Guide = 109,

        [Description("Health")]
        Health = 110,

        [Description("History")]
        History = 111,

        [Description("Journal")]
        Journal = 112,

        [Description("Math")]
        Math = 113,

        [Description("Memoir")]
        Memoir = 114,

        [Description("Prayer")]
        Prayer = 115,

        [Description("Religion, spirituality, and new age")]
        ReligionSpiritualityAndNewAge = 116,

        [Description("Textbook")]
        Textbook = 117,

        [Description("Review")]
        Review = 118,

        [Description("Science")]
        Science = 119,

        [Description("Self help")]
        SelfHelp = 120,

        [Description("Travel")]
        Travel = 121,

        [Description("True crime")]
        TrueCrime = 122

        #endregion
    }
}
