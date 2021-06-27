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
    [ApiController]
    [Route("authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            var authorModel = await _repository.GetAuthorByIdAsync(id);
            if (authorModel is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorReadDto>(authorModel));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthors()
        {
            var authorsModel = await _repository.GetAllAuthorsAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorReadDto>>(authorsModel));
        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var authorsModel = await _repository.GetAuthorByIdAsync(id);
            if (authorsModel is null)
            {
                return NotFound();
            }
            await _repository.DeleteAuthorAsync(authorsModel);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateAuthor(AuthorDto authorCreateDto)
        {
            var authorModel = _mapper.Map<Author>(authorCreateDto);
            await _repository.CreateAuthorAsync(authorModel);
            var authorReadDto = _mapper.Map<AuthorReadDto>(authorModel);
            return CreatedAtAction(nameof(GetAuthorById), new { Id = authorReadDto.Id }, authorReadDto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, AuthorDto authorUpdateDto)
        {
            var authorModel = await _repository.GetAuthorByIdAsync(id);
            if (authorModel is null)
            {
                return NotFound();
            }
            var authorUpdate = _mapper.Map(authorUpdateDto, authorModel);
            await _repository.UpdateAuthorAsync(authorUpdate);
            return Ok();
        }

    }
}
