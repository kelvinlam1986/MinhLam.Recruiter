namespace MinhLam.Recruiter.Application.Commands
{
    public class RCLoginCommand
    {
        public RCLoginCommand(string email, string purePassword)
        {
            this.Email = email;
            this.PurePassword = purePassword;
        }

        public string Email { get; set; }
        public string PurePassword { get; set; }
    }

}
