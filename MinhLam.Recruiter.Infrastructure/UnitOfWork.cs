using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobContext context;

        public UnitOfWork(JobContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
