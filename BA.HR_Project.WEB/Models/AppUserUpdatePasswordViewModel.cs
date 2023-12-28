namespace BA.HR_Project.WEB.Models
{
    public class AppUserUpdatePasswordViewModel
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
