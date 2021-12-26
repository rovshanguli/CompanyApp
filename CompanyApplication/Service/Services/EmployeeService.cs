using Domain.Models;
using Repository.Exceptions;
using Repository.Implementations;
using Service.Helpers;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Data;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _employeeRepository { get; }
        private CompanyRepository _companyRepository { get; }
        private int count { get; set; }
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _companyRepository = new CompanyRepository();
        }
        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = _companyRepository.Get(m => m.Id == companyId);
                if (company == null) return null;
                model.Id = count;
                model.Company = company;
                _employeeRepository.Creat(model);
                count++;
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Employee GetById(int employeeId)
        {
            try
            {
                //Company company = _companyRepository.Get(m => m.Id == compnayId);
                Employee employee = _employeeRepository.Get(m => m.Id == employeeId);
                //if(company==null)
                //{                   
                //   return null;
                //}
                //else
                //{
                if (employee == null)
                {
                    return null;
                }
                else
                {
                    return _employeeRepository.Get(m => m.Id == employeeId);
                }

                //}
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
        public List<Employee> GetByAge(int employeeAge)
        {
            try
            {
                return _employeeRepository.GetAll(m => m.Age == employeeAge);

            }
            catch (Exception)
            {
                throw;
            }


        }
        public Employee Update(int id, Employee entity)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                entity.Id = employee.Id;
                _employeeRepository.Update(entity);
                return entity;
            }
            else
            {
                return null;
            }
        }
        public List<Employee> GetAllById(int id)
        {
            return _employeeRepository.GetAll(m => m.Company.Id == id);
        }
    }
}
