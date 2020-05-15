using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using mvcUDE.Models;
using mvcUDE.Models.Enums;

namespace mvcUDE.Data
{
    public class SeedingService
    {
        private mvcUDEContext _context;

        public SeedingService(mvcUDEContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any()||
                _context.SalesRecords.Any())
            {
                return;//BD HAS BEEN SEEDED
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "Maria@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Seller s3 = new Seller(3, "Alex Gray", "alex@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1998, 4, 21), 1000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Seller s6 = new Seller(6, "AlexPink", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);

            SalesRecords r1 = new SalesRecords(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.billed,s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecords.AddRange(r1);
            _context.SaveChanges();
        }
    }
}
