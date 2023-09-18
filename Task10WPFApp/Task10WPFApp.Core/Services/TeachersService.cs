using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;
using Task10WPFApp.Core.Repositories;
using Task10WPFApp.Core.Repositories.Interfaces;
using Task10WPFApp.Core.Services.Interfaces;

namespace Task10WPFApp.Core.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersService(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }

        public List<Teacher> GetAll() => _teachersRepository.GetAll();
        public Teacher? Get(int id) => _teachersRepository.Get(id);        

        public void Delete(int teacherId) => _teachersRepository.Delete(teacherId);
        public void Update(TeacherUpdateDto dto) => _teachersRepository.Update(dto);
        public void Add(TeacherCreateDto dto) => _teachersRepository.Add(dto);
    }
}
