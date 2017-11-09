using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System.Threading.Tasks;

namespace ContosoUniversity.Services
{
    public class CourseService : ICourseService
    {
        private readonly SchoolContext _context;

        public CourseService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<int> AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);

            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
