using System.Threading.Tasks;

namespace ContosoUniversity.Services
{
    public interface ICourseService
    {
        Task<int> AddCourseAsync(Models.Course course);
    }
}
