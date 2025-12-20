using Application.Common;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<List<UserDto>>> GetAllAsync();
        Task<Result<UserDto>> GetByIdAsync(int id);
        Task<Result> DeleteAsync(int id);
    }
}
