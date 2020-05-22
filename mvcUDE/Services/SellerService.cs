using mvcUDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcUDE.Services
{
    public class SellerService 
    {
        private readonly mvcUDEContext _context;

        public SellerService(mvcUDEContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
