using eMovies.Data.Base;
using eMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
       public CinemasService(ApplicationDbContext context) : base(context)
       {

       }
    }
}
