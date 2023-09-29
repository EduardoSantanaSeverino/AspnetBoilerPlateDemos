using System.ComponentModel.DataAnnotations;

namespace MyCollegeV2.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}