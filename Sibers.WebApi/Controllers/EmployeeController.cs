using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.Services.Interfaces;
using Sibers.Services.Models.Employee;
using Sibers.WebApi.Controllers.Base;
using Sibers.WebApi.Models.Request.Employee;
using Sibers.WebApi.Models.Response.Employee;
using System.Collections.Generic;

namespace Sibers.WebApi.Controllers
{
    /// <summary>
    /// Контроллер работников
    /// </summary>
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService employeeService;

        #region constructor
        public EmployeesController(IEmployeeService employeeService, IMapper mapper) : base(mapper)
        {
            this.employeeService = employeeService;
        }
        #endregion

        /// <summary>
        /// Получить работника по Id
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <returns>Работник</returns>
        [HttpGet("{id}")]
        public ActionResult<EmployeeResponse> GetEmployee(int id)
        {
            var employee = employeeService.GetEmployeeById(id);
            var employeeResponse = mapper.Map<EmployeeResponse>(employee);
            return Ok(employeeResponse);
        }

        /// <summary>
        /// Получить список работников
        /// </summary>
        /// <returns>Список работников</returns>
        [HttpGet]
        public ActionResult<ICollection<EmployeeListItemResponse>> GetEmployees()
        {
            var employees = employeeService.GetEmployees();
            var employeesResponse = mapper.Map<ICollection<EmployeeListItemResponse>>(employees);
            return Ok(employeesResponse);
        }

        /// <summary>
        /// Добавить работника
        /// </summary>
        /// <param name="employeeRequest">Модель работника</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEmployee(
            [FromBody] EmployeeRequest employeeRequest)
        {
            var employee = mapper.Map<EmployeeToSave>(employeeRequest);
            employeeService.AddEmployee(employee);
            return Ok();
        }

        /// <summary>
        /// Изменить информацию о работнике по Id
        /// </summary>
        /// <param name="id">Id работника</param>
        /// <param name="employeeRequest">Модель работника</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateEmployee(
            [FromHeader] int id,
            [FromBody] EmployeeRequest employeeRequest)
        {
            var employee = mapper.Map<EmployeeToSave>(employeeRequest);
            employeeService.UpdateEmployee(id, employee);
            return Ok();
        }

        /// <summary>
        /// Удалить работника по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeleteEmployee(
            [FromHeader] int id)
        {
            employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
