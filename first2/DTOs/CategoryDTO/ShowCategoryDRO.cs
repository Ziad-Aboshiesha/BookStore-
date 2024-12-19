using first2.DTOs.CategoryDTO;
using first2.Models;

namespace first2.DTOs.CategoyryDTO
{
    public class ShowCategoryDTO :AddCategoryDTO
    {
        public virtual List<String> Books { get; set; } = new List<String>();

    }
}
