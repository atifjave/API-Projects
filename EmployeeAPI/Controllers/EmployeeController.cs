using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BAL;
using DAL;
using Models;


namespace EmployeeAPI.Controllers
{
    //[EnableCors(origins: "https://localhost:44368,http://localhost:4200", headers: "*", methods: "*")]
    //[enablecors(origins: "https://localhost:44326", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        readonly EmployeeService employeeService = new EmployeeService();
        [AllowAnonymous]
        [HttpGet]
        [Route("api/employee/list")]
        public IList<EmployeeViewModel> Get()
        {

            return employeeService.GetAllEmployee();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("api/employee/employeeById/{id}")]
        public IList<EmployeeViewModel> GetById(int id)
        {

            return employeeService.GetEmployeeById(id);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("api/employee/DeleteemployeeById/{id:int}")]
        public IHttpActionResult DeleteEmployeeById(int id)
        {

            employeeService.DeleteEmployeeById(id);
                return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("api/employee/employeeAdd")]
        public IHttpActionResult Add(EmployeeViewModel empolyee)
        {
            employeeService.Insert(empolyee);
            return Ok();

        }
    }
}