using Microsoft.AspNetCore.Mvc;
using ShopApi.Core.Application.Data;
using ShopApi.Core.Application.Intefaces;
using ShopApi.Core.Domain.Dtos.Ware;
using ShopApi.Infrastructure.Mappers;

namespace Infrastructure.Controllers{
    [Route("api/ware")]
    public class WareController : Controller{
        private readonly ApplicationDbContext _context;
        private readonly IWareUnitTypeRepository _unitTypeRepository;
        private readonly IWareRepository _wareRepository;

        public WareController(ApplicationDbContext context, IWareUnitTypeRepository unitTypeRepository, IWareRepository wareRepository)
        {   
            _context = context;
            _unitTypeRepository = unitTypeRepository;
            _wareRepository = wareRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var wareModel = await _wareRepository.GetAllAsync();

            return Ok(wareModel.Select(ware => ware.ToDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var wareModel = await _wareRepository.GetByIdAsync(id);

            return wareModel is not null ? Ok(wareModel.ToDto()) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWareDto wareDto){
            var wareUnitModel = await _unitTypeRepository.GetByIdAsync(wareDto.UnitTypeId);
            
            if(wareUnitModel is null){
                return BadRequest("Not exists ware unit type with this id");
            }

            var wareModel = await _wareRepository.CreateAsync(wareDto.ToModelFromCreateDto(wareUnitModel));

            return CreatedAtAction(nameof(GetById), new {id = wareModel.Id}, wareModel.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] UpdateWareDto wareDto){
            var wareUnitModel = await _unitTypeRepository.GetByIdAsync(wareDto.UnitTypeId);
            
            if(wareUnitModel is null){
                return BadRequest("Not exists ware unit type with this id");
            }
            
            var wareModel = await _wareRepository.UpdateAsync(id, wareDto.ToModelFromUpdateDto(wareUnitModel));

            return wareModel is not null ? Ok(wareModel.ToDto()) : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var wareModel = await _wareRepository.DeleteAsync(id);

            return wareModel is not null ? Ok(wareModel.ToDto()) : NotFound();
        }
    }
}