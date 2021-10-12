namespace MinhLam.Recruiter.Domain
{
    public interface IHashedPassword
    {
        string Hash(string purePassword, string keyword);
    }
}
