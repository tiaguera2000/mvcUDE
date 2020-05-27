using mvcUDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
=
namespace mvcUDE.Services
{
    public class DepartmentService
    {
        private readonly mvcUDEContext context;

        public DepartmentService(mvcUDEContext context)
        {
            this.context = context;
        }

        public List<Department> FindAll()
        {
            return context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
