﻿using System;
using Microsoft.AspNetCore.Mvc;
using Guldtand.Domain.Services;
using System.Net;
using System.Threading.Tasks;
using GuldtandApi.Models;

namespace GuldtandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var employeeList = await _employeeService.GetAllEmployeesAsync();
                //var employeeListModel = new EmployeeListModel(employeeList);

                return Ok(employeeList);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: " + $"ArgumentException details: {exception.Message}");

                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: " + $"Exception details: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}