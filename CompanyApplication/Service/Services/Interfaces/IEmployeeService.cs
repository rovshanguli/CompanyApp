using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model,int libraryId);
        public void Delete(int id);
        Employee GetById(int employeeId);
        public Employee GetByAge(int age);
        public Employee Update(Employee entity, int id);
        List<Employee> GetAll();
    }
}
