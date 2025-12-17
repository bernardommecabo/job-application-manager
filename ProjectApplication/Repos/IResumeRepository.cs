using ProjectDomain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Repos
{
    public interface IResumeRepository
    {
        Task<ResumeEntity> GetResumeByIdAsync(int id);
        Task CreateResumeAsync(ResumeEntity resume);
        Task UpdateResumeAsync(ResumeEntity resume);
        Task DeleteResumeAsync(int id);
    }
}
