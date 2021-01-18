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
    public class SportService : ISportService
    {
        private readonly TeamsDbContext _teamsDbContext;

        public TeamService(TeamsDbContext teamsDbContext)
        {
            _teamsDbContext = teamsDbContext ?? throw new ArgumentNullException(nameof(teamsDbContext));
        }

        public async Task<SportDto> Get(int id)
        {
            return await _teamsDbContext.Sports
                .Where(x => x.Id == id)
                .Select(x => new SportDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> Create(SportDto teamDto)
        {
            Sport team = new Sport();

            AplyDtoToEntity(team, teamDto);

            _teamsDbContext.Sports.Add(team);
            await _teamsDbContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task<int> Update(SportDto teamDto)
        {
            Sport team = _teamsDbContext.Sports.Find(teamDto.Id);

            AplyDtoToEntity(team, teamDto);

            await _teamsDbContext.SaveChangesAsync();

            return team.Id;
        }

        public async Task Delete(int id)
        {
            Sport sport = _teamsDbContext.Sports.Find(id);

            _teamsDbContext.Sports.Remove(sport);
            await _teamsDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Sport sport, SportDto sportDto)
        {
            sport.Name = sportDto.Name;
            sport.Description = sportDto.Description;
        }
    }
}
