using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeWebAPIDemo.Models;
using OfficeWebAPIDemo.Service;

namespace OfficeWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _department;

        public DepartmentController(IDepartmentService department)
        {
            _department = department;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var result = _department.Get();
            if(result == null)
                return new JsonResult("Eror");
            return result;
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            var result = _department.Insert(dep);
            if(result==null)
                return new JsonResult("Eror");
            return result;
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            var result = _department.Update(dep);
            if (result == null)
                return new JsonResult("Eror");
            return result;
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _department.Delete(id);
            if (result == null)
                return new JsonResult("Eror");
            return result;
        }
    }
}
