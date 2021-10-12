using MinhLam.Framework;

namespace MinhLam.Recruiter.Domain
{
    public class JobCategory : AggregateRoot
    {
        public string Name { get; protected set; }
        public int JobNumber { get; protected set; }

        public void IncreaseJobNumber()
        {
            JobNumber = JobNumber + 1;
        }
        public void DecreaseJobNumber()
        {
            JobNumber = JobNumber - 1;
        }
    }
}
