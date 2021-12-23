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
            CompanyService companyservice = new CompanyService();
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
                            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name");
                            string companyname = Console.ReadLine();
                            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company adrress : ");
                            string companyadrress = Console.ReadLine();
                            Company company = new Company
                            {
                                Name = companyname,
                                Adrress = companyadrress
                            };                               
                            var result = companyservice.Create(company);
                                if (result != null)
                                {
                                    Helper.WriteToConsole(ConsoleColor.Green, $"{company.Id} {company.Name} company created");
                                }                               
                                else
                                {
                                    Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");
                                
                                }

                            break;
                        case (int)MyEnum.Menus.UpdateCompany:
                            break;
                        case (int)MyEnum.Menus.DeleteCompany:
                            break;
                        case (int)MyEnum.Menus.GetCompanyById:
                            Helper.WriteToConsole(ConsoleColor.Green, "Add company id");
                        EnterId: string companyId = Console.ReadLine();
                            int id;
                            bool isIdTrue = int.TryParse(companyId, out id);
                            if (isIdTrue)
                            {
                                var company1 = companyservice.GetById(id);
                                if (company1 == null)
                                {
                                    Helper.WriteToConsole(ConsoleColor.Red, "Company was not found");
                                    goto EnterId;
                                }
                                else
                                {
                                    Helper.WriteToConsole(ConsoleColor.Green, $"{company1.Id} - {company1.Name} - {company1.Adrress}");
                                }
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, "Try again Id");
                                goto EnterId;

                            }
                            break;
                        case (int)MyEnum.Menus.GetCompanyByName:
                            break;
                        case (int)MyEnum.Menus.GetAllCompany:
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
