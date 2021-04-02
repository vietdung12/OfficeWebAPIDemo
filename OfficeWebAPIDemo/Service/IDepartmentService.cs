using Microsoft.AspNetCore.Mvc;
using OfficeWebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeWebAPIDemo.Service
{
    public interface IDepartmentService
    {
        JsonResult Get();
        JsonResult Insert(Department dep);
        JsonResult Update(Department dep);
        JsonResult Delete(int id);
    }
}
