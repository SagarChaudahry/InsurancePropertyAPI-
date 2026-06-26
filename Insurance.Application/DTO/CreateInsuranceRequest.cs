using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entity.DbModel;

namespace Insurance.Application.DTO
{
    public class CreateInsuranceRequest
    {
        public InsuredPerson InsuredPerson { get; set; } = new();

        public Property Properties { get; set; } = new();
        public Policy Policy { get; set; } = new();

    }
}
