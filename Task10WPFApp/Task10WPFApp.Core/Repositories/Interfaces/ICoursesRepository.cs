using Task10WPFApp.Core.Models;

namespace Task10WPFApp.Core.Repositories.Interfaces
{
    public interface ICoursesRepository
    {
        /// <summary>
        /// Retrieves a set of courses from the database and returns them as a list
        /// </summary>
        /// <returns>The list of courses</returns>
        List<Course> GetAll();
        /// <summary>
        /// Retrieves a set of courses from the database and returns one of them
        /// </summary>
        /// <param name="courseId">Id of the course to be returned</param>
        /// <returns>Course</returns>
        Course? Get(int courseId);
    }
}
