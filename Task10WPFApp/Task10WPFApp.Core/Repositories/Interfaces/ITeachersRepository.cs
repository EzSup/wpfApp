using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Repositories.Interfaces
{
    public interface ITeachersRepository
    {
        /// <summary>
        /// Retrieves a set of teachers from the database and returns them as a list
        /// </summary>
        /// <returns>The list of teachers</returns>
        List<Teacher> GetAll();


        /// <summary>
        /// Retrieves a set of teachers from the database and returns one of them
        /// </summary>
        /// <param name="id">Id of the teacher to be returned</param>
        /// <returns>Teacher</returns>
        Teacher? Get(int id);

        /// <summary>
        /// Allows you to change the teacher`s data
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Update(TeacherUpdateDto dto);

        /// <summary>
        /// Deletes a teacher from the database
        /// </summary>
        /// <param name="id">Id of the teacher</param>
        public void Delete(int id);

        /// <summary>
        /// Adds a new teacher to the database
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        public void Add(TeacherCreateDto dto);

        /// <summary>
        /// Saves the changes made
        /// </summary>
        public void SaveChanges();
    }
}
