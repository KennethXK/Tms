using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Dtos.Company
{
    public class UpdateCompanyDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
