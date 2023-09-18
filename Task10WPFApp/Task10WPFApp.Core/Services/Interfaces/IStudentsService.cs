using Task10WPFApp.Core.Repositories.Interfaces;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Services.Interfaces
{
    public interface IStudentsService
    {
        /// <summary>
        /// Retrieves a set of students from the database and returns them as a list
        /// </summary>
        /// <returns>The list of students</returns>
        List<Student> GetAll();

        /// <summary>
        /// Finds students belonging to a specific group
        /// </summary>
        /// <param name="groupId">Id of the group</param>
        /// <returns>List of the students</returns>
        List<Student>? GetAll(int groupId);

        /// <summary>
        /// Retrieves a set of students from the database and returns one of them
        /// </summary>
        /// <param name="courseId">Id of the student to be returned</param>
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
        /// <param name="id">Id of the student to be deleted</param>
        void Delete(int id);

        /// <summary>
        /// Adds a new student to the database
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Add(StudentCreateDto dto);

        /// <summary>
        /// Exports a list of students to a CSV file
        /// </summary>
        /// <param name="students">The list of students</param>
        /// <param name="filePath">Path to the CSV-file</param>
        public void ExportToCSV(List<Student> students, string filePath);

        /// <summary>
        /// Exports a list of students of the group to a CSV file
        /// </summary>
        /// <param name="groupId">Id of the group</param>
        /// <param name="filePath">Path to the CSV-file</param>
        public void ExportToCSV(int groupId, string filePath);

        /// <summary>
        /// Imports a list of students to a group from a CSV file
        /// </summary>
        /// <param name="groupId">Id of the group</param>
        /// <param name="filePath">Path to the CSV-file</param>
        public void ImportFromCSV(int groupId, string filePath);
    }
}
