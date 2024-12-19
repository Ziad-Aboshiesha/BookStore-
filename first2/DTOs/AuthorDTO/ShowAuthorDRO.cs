using first2.Models;

namespace first2.DTOs.AuthorDTO
{
    public class ShowAuthorDTO :AddAuthorDTO
    {
        public virtual List<String> Books { get; set; } = new List<String>();

    }
}
