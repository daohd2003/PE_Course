﻿using BussinessObjects;
using BussinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEnrollmentService
    {
        Task<bool> Enrollment(EnrollmentDTO dto);
    }
}
