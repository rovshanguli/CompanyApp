﻿using Domain.Models;
using Repository.Implementations;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        private CompanyRepository _companyRepository;
        private int count { get; set; }
        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }
        public Company Create(Company model)
        {
            model.Id = count;
            _companyRepository.Creat(model);
            count++;
            return model;

        }
        public void Delete(Company company)
        {
            _companyRepository.Delete(company);
        }
        public List<Company> GetAll()
        {
            return _companyRepository.GetAll(null);
        }
        public Company GetById(int id)
        {  if (count != 0)
            {
                return _companyRepository.Get(m => m.Id == id);
            }
            else
            {
                return null;
            }
        }
        public Company Update(int id, Company model)
        {            
            var company = GetById(id);
            if (company != null)
            {
                model.Id = company.Id;
                _companyRepository.Update(model);
                return model;
            }
            else
            {
                return null;
            } 
        }
        public List<Company> GetAllByName(string name)
        {
            return _companyRepository.GetAll(m=>m.Name==name);
        }
    }



}
