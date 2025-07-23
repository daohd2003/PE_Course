using AutoMapper;
using BussinessObjects;
using BussinessObjects.DTOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _articleRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateCourse(CreateCourseDTO dto)
        {
            var article = _mapper.Map<Course>(dto);
            return await _articleRepository.CreateCourse(article);
        }

        public async Task<bool> DeleteCourse(int id)
        {
            return await _articleRepository.DeleteCourse(id);
        }

        public async Task<CourseDetailDTO?> GetCourseDetails(int id)
        {
            var article = await _articleRepository.GetCourseById(id);
            var dto = _mapper.Map<CourseDetailDTO?>(article);
            return dto;
        }

        public IQueryable<Course> GetCoursesAsQueryable()
        {
            return _articleRepository.GetAllCoursesAsQueryable();
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesForList()
        {
            var articles = await _articleRepository.GetCourses();
            var dtos = _mapper.Map<IEnumerable<CourseDTO>>(articles);

            return dtos;
        }

        public async Task<bool> UpdateCourse(UpdateCourseDTO dto)
        {
            var article = _mapper.Map<Course>(dto);
            return await _articleRepository.UpdateCourse(article);
        }
    }
}
