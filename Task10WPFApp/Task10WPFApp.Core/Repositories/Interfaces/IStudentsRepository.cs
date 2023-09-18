using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Repositories.Interfaces
{
    public interface IStudentsRepository
    {
        /// <summary>
        /// Retrieves a set of students from the database and returns them as a list
        /// </summary>
        /// <returns>The list of students</returns>
        List<Student> GetAll();

        /// <summary>
        /// Retrieves a set of students of the group from the database and returns them as a list
        /// </summary>
        /// <param name="groupId">Id og the group</param>
        /// <returns>The list of students</returns>
        List<Student> GetAll(int groupId);

        /// <summary>
        /// Retrieves a set of students from the database and returns one of them
        /// </summary>
        /// <param name="id">Id of the student to be returned</param>
        /// <returns>Group</returns>
        Student? Get(int id);

        /// <summary>
        /// Allows you to change the student`s data
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Update(StudentUpdateDto dto);

        /// <summary>
        /// Deletes a student from the database
        /// </summary>
        /// <param name="id">Id of the student</param>
        public void Delete(int id);

        /// <summary>
        /// Adds a new student to the database
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Add(StudentCreateDto dto);

        /// <summary>
        /// Saves the changes made
        /// </summary>
        public void SaveChanges();
    }
}
