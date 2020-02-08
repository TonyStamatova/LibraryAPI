using System.ComponentModel;

namespace Library.Data.Models.Enumerations
{
    public enum GenreType
    {
        [Description("Other")]
        Other = 0,

        [Description ("Fiction")]
        Fiction = 1,

        [Description ("Non-fiction")]
        NonFiction = 2
    }
}
