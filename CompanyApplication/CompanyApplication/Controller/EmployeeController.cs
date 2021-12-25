﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Service;
using Service.Helpers;
using Service.Interfaces;

namespace CompanyApplication.Controller
{
    public class EmployeeController
    {
        private EmployeeService _employeeService { get; }
        private CompanyService _companyService { get; }
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        public void Creat()
        {
            EnterCompanyId: Helper.WriteToConsole(ConsoleColor.Cyan, "Add company Id");
            string id = Console.ReadLine();
            int companyId;
            bool isTrueCompanyId = int.TryParse(id, out companyId);
            if (isTrueCompanyId)
            {
                Helper.WriteToConsole(ConsoleColor.Cyan, "Add employee name");
                string employeename = Console.ReadLine();
                Helper.WriteToConsole(ConsoleColor.Cyan, "Add employee surname : ");
                string employeesurname = Console.ReadLine();
                Helper.WriteToConsole(ConsoleColor.Cyan, "Add employee age : ");
                EnterEmployeeAge: string employeeage = Console.ReadLine();
                int age;
                bool isTrueAge = int.TryParse(employeeage, out age);
                if (isTrueAge)
                {
                    Employee employee = new Employee
                    {
                        Name = employeename,
                        Surname = employeesurname,
                        Age = age
                    };
                    var result = _employeeService.Create(employee,companyId);
                    if (result != null)
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Id} {employee.Name} - {employee.Company.Name} employee created");
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Company was not found");
                        goto EnterCompanyId;

                    }
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Enter correct age");
                    goto EnterEmployeeAge;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Enter correct Id");
                goto EnterCompanyId;
            }
        }
        public void GetById()
        {
            //Helper.WriteToConsole(ConsoleColor.Green, "Add company id");
            //EnterCompanyId: string companyId = Console.ReadLine();
            //int companyid;
            //bool isCompanyIdTrue = int.TryParse(companyId, out companyid);
            //if (isCompanyIdTrue)
            //{
            //    var company = _companyService.GetById(companyid);
            //    if (company == null)
            //    {
            //        Helper.WriteToConsole(ConsoleColor.Red, "Company was not found");
            //        goto EnterCompanyId;
            //    }
                //else
                //{
                    EnterEmployeeId: Helper.WriteToConsole(ConsoleColor.Green, "Add employee id");
                    string employeeId = Console.ReadLine();
                    int employeeid;
                    bool isEmployeeIdTrue = int.TryParse(employeeId, out employeeid);
                    if (isEmployeeIdTrue)
                    {
                        var employee = _employeeService.GetById(employeeid/*,comanyid*/);
                        if (employee == null)
                        {
                            Helper.WriteToConsole(ConsoleColor.Red, "Employee was not found");
                            goto EnterEmployeeId;
                        }
                        else
                        {
                            Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Name} - {employee.Surname} - {employee.Company.Name}");
                        }
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Enter correct id");
                        goto EnterEmployeeId;
                    }
            //    }
            //}
            //else
            //{
            //    Helper.WriteToConsole(ConsoleColor.Red, "Try again company Id");
            //    goto EnterCompanyId;
            //}
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add Employee Id");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool istrue = int.TryParse(companyId, out id);
            if (istrue)
            {
                var employee = _employeeService.GetById(id);
                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Green, "Employee is not found");
                    goto EnterId;
                }
                else
                {

                    Helper.WriteToConsole(ConsoleColor.Red, $"{employee.Name} - Employee is deleted ");

                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try Again ");
                goto EnterId;
            }
        }
        public void GetByAge()
        {
        EnterEmployeeId: Helper.WriteToConsole(ConsoleColor.Green, "Add employee age");
            string employeeAge = Console.ReadLine();
            int employeeage;
            bool isEmployeeIdTrue = int.TryParse(employeeAge, out employeeage);
            if (isEmployeeIdTrue)
            {
                var employee = _employeeService.GetByAge(employeeage);
                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee was not found");
                    goto EnterEmployeeId;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Name} - {employee.Surname} - {employee.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Enter correct age");
                goto EnterEmployeeId;
            }

        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add Company Id");
            EnterId: string companyId = Console.ReadLine();
            int Id;
            bool isidtrue = int.TryParse(companyId, out Id);
            Helper.WriteToConsole(ConsoleColor.Green, "Add new Company Name");
            string newCompany = Console.ReadLine();
            if (isidtrue)
            {
                Company company = new Company
                {
                    Name = newCompany
                };
                Employee employee = new Employee();
                employee.Company = company;
                _employeeService.Update(employee,Id);
                Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Id} - {employee.Name} - {employee.Company} -" +
                    $" Company Updated");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try Again");
                goto EnterId;
            }
        }
        public void GetAll()
        {
            var employees = _employeeService.GetAll();
            foreach (var item in employees)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Company.Name}");
            }
        }
    }
}