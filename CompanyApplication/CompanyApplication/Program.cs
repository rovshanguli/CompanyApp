using CompanyApplication.Controller;
using Domain.Models;
using Service;
using Service.Helpers;
using Service.Interfaces;
using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyController companyController = new CompanyController();
            EmployeeController employeeController = new EmployeeController();
            
            while (true)
            {
                Menus();
                string selectOption = Console.ReadLine();
                int option;
                bool isTrueOption = int.TryParse(selectOption, out option);
                if (isTrueOption)
                {
                    switch (option)
                    {
                        case (int)MyEnum.Menus.CreatCompany:
                            companyController.Creat();
                            break;
                        case (int)MyEnum.Menus.UpdateCompany:
                            companyController.Update();
                            break;
                        case (int)MyEnum.Menus.DeleteCompany:
                            companyController.Delete();
                            break;
                        case (int)MyEnum.Menus.GetCompanyById:
                            companyController.GetById();
                            break;
                        case (int)MyEnum.Menus.GetCompanyByName:
                            companyController.GetByName();
                            break;
                        case (int)MyEnum.Menus.GetAllCompany:
                            companyController.GetAll();
                            break;
                        case (int)MyEnum.Menus.CreatEmployee:
                            employeeController.Creat();
                            break;
                        case (int)MyEnum.Menus.UpdateEmployee:
                            employeeController.Update();
                            break;
                        case (int)MyEnum.Menus.GetEmployeeById:
                            employeeController.GetById();
                            break;
                        case (int)MyEnum.Menus.DeleteEmployee:
                            employeeController.Delete();
                            break;
                        case (int)MyEnum.Menus.GetEmployeeByAge:
                            employeeController.GetByAge();
                            break;
                        case (int)MyEnum.Menus.GetAllEmployeeByCompanyId:
                            employeeController.GetAll();
                            break;


                    }
                }
            }
        }




        private static void Menus()
        {
            Helper.WriteToConsole(ConsoleColor.Gray, "Please Select option");
            Helper.WriteToConsole(ConsoleColor.Blue, "1 - Creat Company       4 - Get Company By Id        7 - Creat Employee         10 - Delete Employee");
            Helper.WriteToConsole(ConsoleColor.Blue, "2 - Update Company      5- Get Company by Name       8 - UpdateEmployee         11 - Get Employee By Age");
            Helper.WriteToConsole(ConsoleColor.Blue, "3 - Delete Company      6 - Get All Company          9 - Get Employee By Id     12 - Get All Employee By Company Id");
            Helper.WriteToConsole(ConsoleColor.Green,"======================================================================================================================");
        }

       
    } 
}
