using mvcUDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvcUDE.Services
{
    public class SalesRecordService 
    {
        private readonly mvcUDEContext _context;

        public SalesRecordService(mvcUDEContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecords>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)result = result.Where(x => x.Date >= minDate.Value);
            
            if (maxDate.HasValue) result = result.Where(x => x.Date <= maxDate.Value);

            return await result.Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();//join do sql
        }
        public async Task<List<IGrouping<Department,SalesRecords>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue) result = result.Where(x => x.Date >= minDate.Value);

            if (maxDate.HasValue) result = result.Where(x => x.Date <= maxDate.Value);

            return await result.Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();//join do sql
        }
    }
}
