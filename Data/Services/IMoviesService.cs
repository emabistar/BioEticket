using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Base;
using bioticket.Models;
using bioticket.ViewModels;

namespace bioticket.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropDownsVM> GetNewMovieDropsDownValue();

        Task AddNewMovieAsync(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM data);

    }
}
