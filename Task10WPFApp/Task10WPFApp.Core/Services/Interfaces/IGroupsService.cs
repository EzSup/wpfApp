using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Services.Interfaces
{
    public interface IGroupsService
    {
        /// <summary>
        /// Retrieves a set of groups from the database and returns them as a list
        /// </summary>
        /// <returns>The list of groups</returns>
        List<Group> GetAll();

        /// <summary>
        /// Finds groups related to a particular course
        /// </summary>
        /// <param name="courseId">Id of the course</param>
        /// <returns>List of the groups</returns>
        List<Group>? GetAll(int courseId);

        /// <summary>
        /// Retrieves a set of groups from the database and returns one of them
        /// </summary>
        /// <param name="id">Id of the group to be returned</param>
        /// <returns>Group</returns>
        Group? Get(int id);
        /// <summary>
        /// Allows you to change the group data
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        void Update(GroupUpdateDto dto);

        /// <summary>
        /// Adds a new group to the database
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Add(GroupCreateDto dto);

        /// <summary>
        /// Writes group data to a DOCX-file
        /// </summary>
        /// <param name="groupId">Id of the group</param>
        /// <param name="filePath">Path to the DOCX-file</param>
        public void CreateDocxDocument(int groupId, string filePath);

        /// <summary>
        /// Writes group data to a PDF-file
        /// </summary>
        /// <param name="groupId">Id of the group</param>
        /// <param name="filePath">Path to the PDF-file</param>
        public void CreatePdfDocument(int groupId, string filePath);

        /// <summary>
        /// Deletes a group from the database
        /// </summary>
        /// <param name="id">Id of the group to be deleted</param>
        void Delete(int id);
    }
}
