using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Repositories.Interfaces;

namespace Task10WPFApp.Core.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CoursesRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Course> GetAll()
        {
            return _dbContext.Courses.ToList();
        }

        public Course? Get(int courseId)
        {
            return _dbContext.Courses.Find(courseId);
        }
    }
}
