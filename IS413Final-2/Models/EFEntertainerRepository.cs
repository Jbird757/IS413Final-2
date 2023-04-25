using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IS413Final_2.Models
{
    public class EFEntertainerRepository :IEntertainerRepository
    {
        private EntertainmentAgencyExampleContext _context { get; set; }

        public EFEntertainerRepository (EntertainmentAgencyExampleContext temp)
        {
            _context = temp;
        }

        public IQueryable<Entertainers> Entertainers => _context.Entertainers;

        public void SaveThings(Entertainers entertainers)
        {
            _context.AttachRange(entertainers);
            _context.Entertainers.Add(entertainers);
            _context.SaveChanges();
        }

        public void UpdateThings(Entertainers entertainers)
        {
            _context.Entry(entertainers).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteThings(Entertainers entertainers)
        {
            _context.Set<Entertainers>().Remove(entertainers);
            _context.SaveChanges();

        }
    }
}
