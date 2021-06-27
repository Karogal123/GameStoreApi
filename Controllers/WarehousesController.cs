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
    [Route("warehouses")]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseRepository _repository;
        private readonly IMapper _mapper;

        public WarehousesController(IWarehouseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWarehouseById(int id)
        {
            var wh = await _repository.GetWarehouseByIdAsync(id);
            if (wh is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WarehoueReadDto>(wh));
        }
    
        [HttpGet]
        public async Task<ActionResult> GetAllWarehouses()
        {
            var whs = await _repository.GetAllWareHousesAsync();
            return Ok(_mapper.Map<IEnumerable<WarehoueReadDto>>(whs));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWarehouse(int id)
        {
            var wh = await _repository.GetWarehouseByIdAsync(id);
            if (wh is null)
            {
                return NotFound();
            }
            await _repository.DeleteWarehouseAsync(wh);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateWarehouse(WarehouseDto warehouseCreatedDto)
        {
            var warehouseModel = _mapper.Map<Warehouse>(warehouseCreatedDto);
            await _repository.CreateWarehouseAsync(warehouseModel);
            var warehouseReadDto = _mapper.Map<WarehoueReadDto>(warehouseModel);
            return CreatedAtAction(nameof(GetWarehouseById), new { Id = warehouseReadDto.Id }, warehouseReadDto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWarehouse(WarehouseDto warehouseUpdateDto, int id)
        {
            var warehouseModel = await _repository.GetWarehouseByIdAsync(id);
            if (warehouseModel is null)
            {
                return NotFound();
            }
            _mapper.Map(warehouseUpdateDto, warehouseModel);
            await _repository.UpdateWarehouseAsync(warehouseModel);
            return Ok();
        }
    }
}
