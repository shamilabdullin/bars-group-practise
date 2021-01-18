using Teams.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Services
{
    public interface ITeamService
    {
        Task<TeamDto[]> Get(int id);

        Task<int> Create(TeamDto teamDto);

        Task<int> Update(TeamDto teamDto);

        Task Delete(int id);
    }
}
