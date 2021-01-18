using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data.Models;
using Teams.Services;
using Microsoft.AspNetCore.Mvc;

namespace Teams.Controllers
{
    [Route("Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

    
        // Получение команды по идентификатору.
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var teamDto = await _teamService.Get(id);
            return Ok(new { Success = true, Team = teamDto });
        }

        
		// Добавление команды.
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(TeamDto teamDto)
        {
            return Ok(new { Success = true, TeamId = await _teamService.Create(teamDto) });
        }

        // Обновление команды.
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(TeamDto teamDto)
        {
            return Ok(new { Success = true, TeamId = await _teamService.Update(teamDto) });
        }

        // Удаление команды.
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}