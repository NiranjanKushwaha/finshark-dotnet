using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var stocks = await _context.Stocks.ToListAsync();
            var stockResult = stocks.Select(s=>s.ToStockDto());
            return Ok(stockResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _context.Stocks.FindAsync(id);
            if(stock == null){
                return NotFound();
            }
            return Ok(stock?.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockRequest ){
            var stockModel = createStockRequest.ToStockEntity();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id },stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){
           var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id==id);
           if(stockModel == null){
            return NotFound();
           }
           stockModel.Symbol = updateDto.Symbol;
           stockModel.CompanyName = updateDto.CompanyName;
           stockModel.Purchase  = updateDto.Purchase;
           stockModel.Divident = updateDto.Divident;
           stockModel.Industry = updateDto.Industry;
           stockModel.MarketCap = updateDto.MarketCap;

           _context.SaveChanges();
           return Ok(stockModel.ToStockDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id){
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return NotFound();
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}