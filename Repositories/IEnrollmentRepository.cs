﻿using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEnrollmentRepository
    {
        Task<bool> Enrollment(Enrollment entity);
    }
}
