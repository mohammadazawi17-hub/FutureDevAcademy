using Application.Common;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<string>> LoginAsync(LoginDto dto);
        Task<Result> RegisterStudentAsync(RegisterStudentDto dto);
    }
}
