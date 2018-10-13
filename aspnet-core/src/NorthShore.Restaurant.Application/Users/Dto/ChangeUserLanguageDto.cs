using System.ComponentModel.DataAnnotations;

namespace NorthShore.Restaurant.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}