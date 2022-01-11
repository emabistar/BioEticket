using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Base;
using bioticket.Models;

namespace bioticket.Data.Services
{
    public class CinemasService: EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context):base(context)
        {

        }
    }
}
