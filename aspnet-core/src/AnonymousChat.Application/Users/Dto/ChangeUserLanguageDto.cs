using System.ComponentModel.DataAnnotations;

namespace AnonymousChat.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}