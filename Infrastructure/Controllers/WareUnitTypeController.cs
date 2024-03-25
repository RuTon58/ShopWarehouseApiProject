using Microsoft.AspNetCore.Mvc;
using ShopApi.Core.Application.Data;
using ShopApi.Core.Application.Intefaces;
using ShopApi.Core.Domain.Dtos.WareUtitType;
using ShopApi.Infrastructure.Mappers;

namespace Infrastructure.Controllers{
    [Route("api/wareunittype")]
    public class WareUnitTypeController : Controller{
        private readonly ApplicationDbContext _context;
        private readonly IWareUnitTypeRepository _unitTypeRepository;

        public WareUnitTypeController(ApplicationDbContext context, IWareUnitTypeRepository unitTypeRepository)
        {
            _context = context;
            _unitTypeRepository = unitTypeRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var wareUnitTypeList = await _unitTypeRepository.GetAllAsync();

            return Ok(wareUnitTypeList.Select(unitType => unitType.ToDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            var wareUnitType = await _unitTypeRepository.GetByIdAsync(id);

            return wareUnitType is not null ? Ok(wareUnitType.ToDto()) : NotFound(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWareUnitTypeDto wareUnitTypeDto){
            var wareUnitType = await _unitTypeRepository.CreateAsync(wareUnitTypeDto.ToModelFromCreateDto());

            return CreatedAtAction(nameof(GetById), new {id = wareUnitType.Id}, wareUnitType.ToDto()); 
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateWareUnitTypeDto wareUnitTypeDto){
            var wareUnitType = await _unitTypeRepository.UpdateAsync(id, wareUnitTypeDto);

            return wareUnitType is not null ? Ok(wareUnitType.ToDto()) : NotFound(); 
        }
    
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Dalete([FromRoute]int id){
            var wareUnitType = await _unitTypeRepository.DeleteAsync(id);

            return wareUnitType is not null ? Ok(wareUnitType.ToDto()) : NotFound(); 
        }
    }
}