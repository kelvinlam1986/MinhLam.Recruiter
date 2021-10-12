using MinhLam.Framework;
using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Infrastructure.Utilities
{
    public class HashedPassword : IHashedPassword
    {
        public string Hash(string purePassword, string keyword)
        {
            return Cryptography.Encrypt(purePassword, keyword);
        }
    }
}
