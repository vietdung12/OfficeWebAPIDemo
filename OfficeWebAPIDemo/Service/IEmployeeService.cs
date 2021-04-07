using Microsoft.AspNetCore.Mvc;
using OfficeWebAPIDemo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeWebAPIDemo.Service
{
    public interface IEmployeeService
    {
        Task<JsonResult> Get();
        Task<JsonResult> Insert(Employee emp);
        Task<JsonResult> Update(Employee emp);
        Task<JsonResult> Delete(int id);
    }
}
