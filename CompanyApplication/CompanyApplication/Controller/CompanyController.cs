using Domain.Models;
using Service;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    
   
    public class CompanyController
    {
        private CompanyService _companyservice { get; }
        public CompanyController()
        {
            _companyservice = new CompanyService();
        }
        public void Creat()
        {
            
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name");
            string companyname = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company adrress : ");
            string companyadrress = Console.ReadLine();
            Company company = new Company
            {
                Name = companyname,
                Adrress = companyadrress
            };
            var result = _companyservice.Create(company);
            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{company.Id} {company.Name} company created");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");

            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add company id");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);                      
            if (isIdTrue)
            {

                Helper.WriteToConsole(ConsoleColor.Green, "Add new company name ");
                string newName = Console.ReadLine();
                Helper.WriteToConsole(ConsoleColor.Green, "Add new company address ");
                string newAddress = Console.ReadLine();
                Company company = new Company()
                {
                    Name = newName,
                    Adrress = newAddress 
                };
                var newCompany = _companyservice.Update(id, company);
                if (newCompany != null)
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"Succesfully update : {newCompany.Name} - {newCompany.Adrress}");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company was not found");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again Id");
                goto EnterId;

            }

        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add company id");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);
            if (isIdTrue)
            {
                var company1 = _companyservice.GetById(id);
                if (company1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company was not found");
                    goto EnterId;
                }
                else
                {
                    _companyservice.Delete(company1);
                    Helper.WriteToConsole(ConsoleColor.Green, $"Company is deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again Id");
                goto EnterId;

            }

        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add company id");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);           
            if (isIdTrue)
            {   
                
                var company1 = _companyservice.GetById(id);
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
        }             
        public void GetByName()
        {
            Helper.WriteToConsole(ConsoleColor.Green, "Add company name");
            string companyName = Console.ReadLine();
            var companies = _companyservice.GetAllByName(companyName);
            
            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Adrress}");
            }
        }
        public void GetAll()
        {
            var companies = _companyservice.GetAll();
            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Adrress}");
            }
        }
    }
}
