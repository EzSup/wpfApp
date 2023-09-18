using Task10WPFApp.Core.Repositories.Interfaces;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core.Models;

namespace Task10WPFApp.Core.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public List<Course> GetAll() => _coursesRepository.GetAll();

        public Course? Get(int courseId) => _coursesRepository.Get(courseId);
    }
}
