using AutoMapper;
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;
        public GamesController(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGames()
        {
            var games = await _repository.GetAllGamesAsync();
            return Ok(_mapper.Map<IEnumerable<GameReadDto>>(games));
        }
  
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGameById(int id)
        {
            var game = await _repository.GetGameByIdAsync(id);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GameReadDto>(game));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateGame(GameDto gameCreateDto)
        {
            var gameModel = _mapper.Map<Game>(gameCreateDto);
            await _repository.CreateGameAsync(gameModel);
            var gameReadDto = _mapper.Map<GameReadDto>(gameModel);
            return CreatedAtAction(nameof(GetGameById), new { Id = gameReadDto.Id }, gameReadDto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var gameModel = await _repository.GetGameByIdAsync(id);
            if (gameModel is null)
            {
                return NotFound();
            }
            await _repository.DeleteGameAsync(gameModel);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(int id, GameDto game)
        {
            var gameModel = await _repository.GetGameByIdAsync(id);
            if (gameModel is null)
            {
                return NotFound();
            }
            _mapper.Map(game, gameModel);
            await _repository.UpdateGameAsync(gameModel);
            return NoContent();
        }
    }
}
