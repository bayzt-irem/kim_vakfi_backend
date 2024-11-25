using System.ComponentModel.DataAnnotations;

namespace Items.Enums
{
    public enum UserType
    {
        [Display(Name = "Admin")]
        Admin = 1,

        [Display(Name = "User")]
        User = 2
    }
}
