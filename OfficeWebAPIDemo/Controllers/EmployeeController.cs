using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeWebAPIDemo.Models;
using OfficeWebAPIDemo.Service;

namespace OfficeWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment env)
        {
            _employeeService = employeeService;
            _env = env;
        }
       
        [HttpGet]
        public JsonResult Get()
        {
            var result = _employeeService.Get();
            if(result == null)
                return new JsonResult("Eror");
            return result;
        }

        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            var result = _employeeService.Insert(emp);
            if (result == null)
                return new JsonResult("Eror");
            return result;
        }


        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            var result = _employeeService.Update(emp);
            if (result == null)
                return new JsonResult("Eror");
            return result;
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _employeeService.Delete(id);
            if (result == null)
                return new JsonResult("Eror");
            return result;
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("thumbnail.png");
            }
        }


        //[Route("GetAllDepartmentNames")]
        //public JsonResult GetAllDepartmentNames()
        //{
        //    string query = @"
        //            select DepartmentName from dbo.Department
        //            ";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult(table);
        //}
    }
}
