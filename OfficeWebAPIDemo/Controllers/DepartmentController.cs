using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeWebAPIDemo.Models.Entity;
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
        public async Task<JsonResult> Get()
        {
            var result = await _department.Get();            
            return result;
        }

        [HttpPost]
        public async Task<JsonResult> Post(Department dep)
        {            
            var result = await _department.Insert(dep);           
            return result;
        }

        [HttpPut]
        public async Task<JsonResult> Put(Department dep)
        {
            var result = await _department.Update(dep);            
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _department.Delete(id);           
            return result;
        }
    }
}
