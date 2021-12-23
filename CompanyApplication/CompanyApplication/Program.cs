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
                        default:
                            break;
                    }
                }
            }
        }




        private static void Menus()
        {
            Helper.WriteToConsole(ConsoleColor.Gray, "Select option");
            Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Creat Company       4 - Get Company By Id        7 - Creat Employee         10 - Delete Employee");
            Helper.WriteToConsole(ConsoleColor.Cyan, "2 - Update Company      5- Get Company by Name       8 - UpdateEmployee         11 - Get Employee By Age");
            Helper.WriteToConsole(ConsoleColor.Cyan, "3 - Delete Company      6 - Get All Company          9 - Get Employee By Id     12 - Get All Employee By Company Id");

        }

       
    } 
}
