using ContosoUniversity.Models;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _departmentService;

        public CreateModel(ICourseService courseService,
                           IDepartmentService departmentService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList();
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        [BindProperty]
        public SelectList SL_DepartmentID { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                 emptyCourse,
                 "course",   // Prefix for form value.
                 s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits))
            {
                await _courseService.AddCourseAsync(emptyCourse);
                return RedirectToPage("./Index");
            }

            PopulateDepartmentsDropDownList();
            return Page();
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _departmentService.GetOrderedDepartments();

            SL_DepartmentID = 
                new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
        }
    }
}