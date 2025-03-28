﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll(CustomerFilterDto customerFilterDto);
        IResult Add(CustomerDto customerDto);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
