using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeWebAPIDemo.Db;
using OfficeWebAPIDemo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OfficeWebAPIDemo.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        //private readonly IConfiguration _configuration;
        public EmployeeService(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            //_configuration = configuration;
        }

        public async Task<JsonResult> Delete(int id)
        {
            //string query = @"
            //            EXEC DeleteEmployee " + id + @"
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
            //return new JsonResult("Deleted Successfully");

            var res = await _context.Database.ExecuteSqlRawAsync("DeleteEmployee @p0", parameters: new object[] { id });

            if (res == 1)
                return new JsonResult("Deleted Successfully");
            return new JsonResult("Eror");

        }

        public async Task<JsonResult> Get()
        {
            //string query = @"EXEC GetAllEmployee";
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

            string query = @"EXEC GetAllEmployee";
            List<Employee> Employees = new List<Employee>();
            var result = await _context.Employees.FromSqlRaw(query).ToListAsync();

            if (result == null)
                return new JsonResult("Không có bản ghi");

            foreach (var item in result)
            {
                Employees.Add(new Employee
                {
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    Department = item.Department,
                    DateOfJoining = item.DateOfJoining,
                    PhotoFileName = item.PhotoFileName                   
                });
            }

            return new JsonResult(Employees);

        }

        public async Task<JsonResult> Insert(Employee emp)
        {
            //string query = @"EXEC InsertEmployee 
            //        '" + emp.EmployeeName + @"'
            //        ,'" + emp.Department + @"'
            //        ,'" + emp.DateOfJoining + @"'
            //        ,'" + emp.PhotoFileName + @"'
            //        ";
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

            var res = await _context.Database.ExecuteSqlRawAsync("InsertEmployee @p0, @p1, @p2, @p3", parameters: new object[] { emp.EmployeeName, emp.Department , emp.DateOfJoining, emp.PhotoFileName });

            if (res == 1)
                return new JsonResult("Added Successfully");
            return new JsonResult("Eror");
        }

        public async Task<JsonResult> Update(Employee emp)
        {
            //string query = @"EXEC UpdateEmployee 
            //            " + emp.EmployeeId + @"
            //            ,'" + emp.EmployeeName + @"'
            //            ,'" + emp.Department + @"'
            //            ,'" + emp.DateOfJoining + @"'
            //            ,'" + emp.PhotoFileName + @"'
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

            var res = await _context.Database.ExecuteSqlRawAsync("UpdateEmployee @p0, @p1, @p2, @p3, @p4", parameters: new object[] { emp.EmployeeId, emp.EmployeeName, emp.Department, emp.DateOfJoining, emp.PhotoFileName });

            if (res == 1)
                return new JsonResult("Updated Successfully");
            return new JsonResult("Eror");
        }
    }
}
