using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeWebAPIDemo.Db;
using OfficeWebAPIDemo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace OfficeWebAPIDemo.Service
{
    public class DepartmentService : IDepartmentService
    {
        //private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public DepartmentService(IConfiguration configuration, AppDbContext context)
        {
            //_configuration = configuration;
            _context = context;
        }

        public async Task<JsonResult> Delete(int id)
        {
            //string query = @"
            //            EXEC DeleteDepartment " + id + @"
            //            ";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //SqlDataReader myReader;
            //using (Microsoft.Data.SqlClient.SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);

            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new JsonResult("Deleted Successfully");

            var res = await _context.Database.ExecuteSqlRawAsync("DeleteDepartment @p0", parameters: new object[] { id });

            if (res == 1)
                return new JsonResult("Deleted Successfully");
            return new JsonResult("Eror");
        }

        public async Task<JsonResult> Get()
        {
            //string query = @"EXEC GetAllDepartment";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);

            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new JsonResult(table);

            string query = @"EXEC GetAllDepartment";
            List<Department> Departments = new List<Department>();
            var result = await _context.Departments.FromSqlRaw(query).ToListAsync();

            if (result == null)
                return new JsonResult("Không có bản ghi");

            foreach (var item in result)
            {
                Departments.Add(new Department
                {
                    DepartmentId = item.DepartmentId,
                    DepartmentName = item.DepartmentName
                });               
            }
                
            return new JsonResult(Departments);
        }

        public async Task<JsonResult> Insert(Department dep)
        {
            //string query = @"EXEC InsertDepartment '" + dep.DepartmentName + @"'";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);

            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new JsonResult("Added Successfully");                                   

            SqlParameter retVal = new SqlParameter
            {
                ParameterName = "@retVal",
                SqlDbType = System.Data.SqlDbType.Int,
                //Direction of this parameter is output.
                Direction = System.Data.ParameterDirection.Output
            }; 
            
            await _context.Database.ExecuteSqlRawAsync("InsertDepartment1 @p0, @retVal OUT", parameters: new object[] { dep.DepartmentName, retVal });

            int ret = int.Parse(retVal.Value.ToString());
            if(ret == 200)
                return new JsonResult("Added Successfully");
            return new JsonResult("Eror");
        }

        public async Task<JsonResult> Update(Department dep)
        {
            //string query = @"EXEC UpdateDepartment 
            //            '" + dep.DepartmentName + @"',
            //            " + dep.DepartmentId + @"
            //            ";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand myCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);

            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new JsonResult("Updated Successfully");           

             var res = await _context.Database.ExecuteSqlRawAsync("UpdateDepartment @p0, @p1", parameters: new object[] { dep.DepartmentName, dep.DepartmentId });
            
            if (res == 1)
                return new JsonResult("Updated Successfully");
            return new JsonResult("Eror");
        }
    }
}
