using Microsoft.AspNetCore.Mvc;
using OfficeWebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeWebAPIDemo.Service
{
    public interface IEmployeeService
    {
        JsonResult Get();
        JsonResult Insert(Employee emp);
        JsonResult Update(Employee emp);
        JsonResult Delete(int id);
    }
}
