using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                Divident = stockModel.Divident,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }

        public static Stock ToStockEntity(this CreateStockRequestDto stockRequestDto)
        {
            return new Stock
            {
                Symbol = stockRequestDto.Symbol,
                CompanyName = stockRequestDto.CompanyName,
                Purchase = stockRequestDto.Purchase,
                Divident = stockRequestDto.Divident,
                Industry = stockRequestDto.Industry,
                MarketCap = stockRequestDto.MarketCap,
            };
        }
    }
}
