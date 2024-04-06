using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;

namespace TrackingProject.BusinessLayer.Abstract
{
    public interface IEmployeeService
    {
        Task<EmployeeManagerResponse> RegisterUserAsync(CreateEmployeeDto model);
        Task<EmployeeManagerResponse> LoginUserAsync(LoginEmployeeDto model);
    }
}
