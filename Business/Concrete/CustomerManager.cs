using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using LinqKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [LogAspect]
        [SecuredOperation("admin")]
        public IDataResult<List<Customer>> GetAll(CustomerFilterDto customerFilterDto)
        {
            Expression<Func<Customer, bool>> predicate = c => true; // Başlangıçta tüm veriyi getir

            // Müşteri adı filtresi
            if (!string.IsNullOrEmpty(customerFilterDto.FirstName))
            {
                predicate = predicate.And(c => c.FirstName.Contains(customerFilterDto.FirstName));
            }
            
            if (!string.IsNullOrEmpty(customerFilterDto.LastName))
            {
                predicate = predicate.And(c => c.LastName.Contains(customerFilterDto.LastName));
            }

            if (!string.IsNullOrEmpty(customerFilterDto.Email))
            {
                predicate = predicate.And(c => c.Email.Contains(customerFilterDto.Email));
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

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin")]
        [LogAspect]
        public IResult Add(CustomerDto customerDto)
        {
            Customer customer = new Customer() 
            {
                
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Region = customerDto.Region,
                RegistrationDate= DateOnly.FromDateTime(DateTime.UtcNow)
        };

            IResult result = BusinessRules.Run(CheckIfCustomerExists(customerDto.Email));
            if (result != null)
            {
                return result;
            }

            
            _customerDal.Add(customer);
            return new SuccessResult("Müşteri eklendi");
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin")]
        [LogAspect]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult("Müşteri Güncellendi");
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin")]
        [LogAspect]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("Müşteri Silindi");
        }


        private IResult CheckIfCustomerExists(string email)
        {
            var result = _customerDal.GetAll(p => p.Email == email).Any();
            if (result)
            {
                return new ErrorResult("Müşteri zaten kayıtlı");
            }

            return new SuccessResult(); 
        }

    }
}
