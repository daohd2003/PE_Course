﻿using BussinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO dto);
    }
}
