using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContosoUniversity.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly SchoolContext _context;

        public DepartmentService(SchoolContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Department> GetOrderedDepartments()
        {
            var departmentsQuery = from d in _context.Departments.AsNoTracking()
                                   orderby d.Name
                                   select d;

            return departmentsQuery;
        }
    }
}
