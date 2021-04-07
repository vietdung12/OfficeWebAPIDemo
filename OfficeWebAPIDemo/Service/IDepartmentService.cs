using Microsoft.AspNetCore.Mvc;
using OfficeWebAPIDemo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeWebAPIDemo.Service
{
    public interface IDepartmentService
    {
        Task<JsonResult> Get();
        Task<JsonResult> Insert(Department dep);
        Task<JsonResult> Update(Department dep);
        Task<JsonResult> Delete(int id);
    }
}
