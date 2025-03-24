using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll(CustomerFilterDto customerFilterDto)
        {
            Expression<Func<Customer, bool>> predicate = c => true; // Başlangıçta tüm veriyi getir

            // Müşteri adı filtresi
            if (!string.IsNullOrEmpty(customerFilterDto.Name))
            {
                predicate = predicate.And(c => c.FirstName.Contains(customerFilterDto.Name));
            }

            // Bölge filtresi
            if (!string.IsNullOrEmpty(customerFilterDto.Region))
            {
                predicate = predicate.And(c => c.Region.Contains(customerFilterDto.Region));
            }

            // Başlangıç tarihi filtresi
            if (customerFilterDto.StartDate.HasValue)
            {
                predicate = predicate.And(c => c.RegistrationDate >= customerFilterDto.StartDate.Value);
            }

            // Bitiş tarihi filtresi
            if (customerFilterDto.EndDate.HasValue)
            {
                predicate = predicate.And(c => c.RegistrationDate <= customerFilterDto.EndDate.Value);
            }

            // Filtre uygulama


            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(predicate).OrderByDescending(c => c.Id).ToList(), "Müşteriler listelendi");
        }


        public IResult Add(Customer customer)
        {

            DateOnly.FromDateTime(DateTime.UtcNow);
            _customerDal.Add(customer);
            return new SuccessResult("Müşteri eklendi");
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult("Müşteri Güncellendi");
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("Müşteri Silindi");
        }
    }
}
