using System.ComponentModel.DataAnnotations;

namespace MyCollegeV1.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}