using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model,int libraryId);
        public void Delete(Employee employee);
        Employee GetById(int employeeId);
        public List<Employee> GetByAge(int age);
        public Employee Update(int id, Employee entity);
        List<Employee> GetAllById(int id);
    }
}
