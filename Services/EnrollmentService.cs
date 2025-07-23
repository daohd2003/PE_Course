using AutoMapper;
using BussinessObjects.DTOs;
using BussinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }
        public Task<bool> Enrollment(EnrollmentDTO dto)
        {
            var comment = _mapper.Map<Enrollment>(dto);
            return _enrollmentRepository.Enrollment(comment);
        }
    }
}
