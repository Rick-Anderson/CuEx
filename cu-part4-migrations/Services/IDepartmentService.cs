using System.Linq;

namespace ContosoUniversity.Services
{
    public interface IDepartmentService
    {
        IQueryable<Models.Department> GetOrderedDepartments();
    }
}
