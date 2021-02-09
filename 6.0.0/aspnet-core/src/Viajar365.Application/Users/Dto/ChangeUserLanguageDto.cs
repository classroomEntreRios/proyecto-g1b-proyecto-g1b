using System.ComponentModel.DataAnnotations;

namespace Viajar365.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}