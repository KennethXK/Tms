﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TMS
{
    public class Company : Entity<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
