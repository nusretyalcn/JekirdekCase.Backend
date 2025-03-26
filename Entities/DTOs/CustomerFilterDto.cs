using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerFilterDto:IDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Region { get; set; }
        public string? Email { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
