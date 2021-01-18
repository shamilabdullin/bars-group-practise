using Teams.Data;
using Teams.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Teams.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamsDbContext _teamsDbContext;

        public TeamService(TeamsDbContext teamsDbContext)
        {
            _teamsDbContext = teamsDbContext ?? throw new ArgumentNullException(nameof(teamsDbContext));
        }

        public async Task<TeamDto[]> Get(int id)
        {
            var teams = await _teamsDbContext.Teams
                .Where(x => x.SportId.HasValue)
                .ToArrayAsync();

            var teamsDtos = new List<TeamDto>();
            foreach(var j in teams)
            {
                teamsDtos.Add(new TeamDto
                {
                    SportName = j.Sport.Name
                });
            }

            return await _teamsDbContext.Teams
                .Where(x => x.Sport.Name == "Футбол")
                .Select(x => new TeamDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SportId = x.SportId,
                    SportName = x.Sport.Name
                })
                .ToArrayAsync();
        }

        public async Task<int> Create(TeamDto teamDto
        )
        {
            Team team = _teamsDbContext.Teams.Find(id);

            AplyDtoToEntity(team, teamDto);

            _teamsDbContext.Teams.Add(team);
            await _teamsDbContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task<int> Update(TeamDto teamDto)
        {
            Team team = _teamsDbContext.Teams.Find(id);

            AplyDtoToEntity(team, teamDto);

            await _teamsDbContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task Delete(int id)
        {
            Team team = _teamsDbContext.Teams.Find(id);

            _teamsDbContext.Teams.Remove(judge);
            await _teamsDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Team team, TeamDto teamDto)
        {
            team.Name = teamDto.Name;
            team.SportId = teamDto.SportId;
        }
    }
}
