using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Base;
using bioticket.Models;
using Microsoft.EntityFrameworkCore;

namespace bioticket.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
