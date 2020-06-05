using mvcUDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvcUDE.Services
{
    public class DepartmentService
    {
        private readonly mvcUDEContext context;

        public DepartmentService(mvcUDEContext context)
        {
            this.context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
