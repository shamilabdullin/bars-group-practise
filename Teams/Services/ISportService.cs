using Teams.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Services
{
    public interface ISportService
    {
        Task<SportDto> Get(int id);

        Task<int> Create(SportDto teamDto);

        Task<int> Update(SportDto teamDto);

        Task Delete(int id);
    }
}
