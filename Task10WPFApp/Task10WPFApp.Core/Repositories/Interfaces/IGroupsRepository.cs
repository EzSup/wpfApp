using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Repositories.Interfaces
{
    public interface IGroupsRepository
    {
        /// <summary>
        /// Retrieves a set of groups from the database and returns them as a list
        /// </summary>
        /// <returns>The list of groups</returns>
        List<Group> GetAll();

        /// <summary>
        /// Retrieves a set of groups from the database and returns one of them
        /// </summary>
        /// <param name="courseId">Id of the group to be returned</param>
        /// <returns>Group</returns>
        Group? Get(int id);

        /// <summary>
        /// Allows you to change the group data
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        void Update(GroupUpdateDto dto);

        /// <summary>
        /// Deletes a group from the database
        /// </summary>
        /// <param name="id">Id of the group</param>
        void Delete(int id);

        /// <summary>
        /// Adds a new group to the database
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Add(GroupCreateDto dto);

        /// <summary>
        /// Saves the changes made
        /// </summary>
        void SaveChanges();
    }
}
