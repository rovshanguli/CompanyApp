using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Creat(Company entity)
        {
            try
            {
                if (entity == null) throw new CustomException("Entity is null");

                AppDbContext<Company>.datas.Add(entity);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Company entity)
        {
            try
            {
                AppDbContext<Company>.datas.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Company Get(Predicate<Company> filter)
        {
            return filter == null ? AppDbContext<Company>.datas[0] : AppDbContext<Company>.datas.Find(filter);
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            return filter == null ? AppDbContext<Company>.datas : AppDbContext<Company>.datas.FindAll(filter);
        }

        public bool Update(Company entity)
        {
            try
            {
                var company = Get(m => m.Id == entity.Id);
                if(company != null)
                {
                    if (!string.IsNullOrEmpty(entity.Name))
                        company.Name = entity.Name;

                    if (!string.IsNullOrEmpty(entity.Adrress))
                        company.Adrress = entity.Adrress;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
