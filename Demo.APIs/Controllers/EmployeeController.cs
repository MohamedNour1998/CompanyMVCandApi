using AutoMapper;
using Demo.BL.Helper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.APIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region field
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        #endregion
        #region ctor
        public EmployeeController(IEmployeeRep employee,IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }
        #endregion
        #region APIs

        [HttpGet]
        [Route("~/API/GetEmployees")]
        public IActionResult GetEmployees()
        {
            try {
                var data = employee.Get();
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "DataRetrived",
                    Data = model

                }); ;
            }
            catch(Exception ex) 
            {
                return NotFound(new ApiResponse<string>() {

                    Code = "404",
                    Status = "NotFound",
                    Message = "Data not Found",
                    Error = ex.Message
                });;
               
            }
            
        }


        [HttpGet]
        [Route("~/API/GetEmployees/{id}")]
        public IActionResult GetEmployeesById(int id)
        {
            try
            {
                var data = employee.GetById(id);
                var model = mapper.Map<EmployeeVM>(data);
                return Ok(new ApiResponse<EmployeeVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "DataRetrived",
                    Data = model

                }); ;
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "NotFound",
                    Message = "Data not Found",
                    Error = ex.Message
                }); ;

            }

        }




        [HttpPost]
        [Route("~/API/PostEmployee")]
        public IActionResult PostEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid) {
                    var data = mapper.Map<Employee>(model);
                    var result = employee.Create(data);

                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "201",
                        Status = "created",
                        Message = "DataSaved",
                        Data = result

                    });
                }
                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not VAlid",
                    Message = "DataInvalid",
                   
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "failed",
                    Message = "NotCreated",
                    Error = ex.Message
                }); ;

            }

        }


        [HttpPut]
        [Route("~/API/PutEmployee")]
        public IActionResult PutEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    var result = employee.Edit(data);

                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = "200",
                        Status = "ok",
                        Message = "DataUpdated",
                        Data = result

                    });
                }
                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not VAlid",
                    Message = "DataInvalid",

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "failed",
                    Message = "NotCreated",
                    Error = ex.Message
                }); ;

            }

        }


        [HttpDelete]
        [Route("~/API/DeleteEmployee")]
        public IActionResult DeleteEmployee(EmployeeVM model)
        {
            try
            {
                
                    var data = mapper.Map<Employee>(model);
                     employee.Delete(data);

                    return Ok(new ApiResponse<EmployeeVM>()
                    {
                        Code = "200",
                        Status = "ok",
                        Message = "DataDeleted",
                        Data = model
                    });
                }
                          
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = "404",
                    Status = "failed",
                    Message = "NotDeleted",
                    Error = ex.Message
                }); ;

            }

        }

        #endregion
    }
}
