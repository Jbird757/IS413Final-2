using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Final_2.Models
{
    public interface IEntertainerRepository
    {
        IQueryable<Entertainers> Entertainers { get; }

        void SaveThings(Entertainers entertainers);

        void UpdateThings(Entertainers entertainers);

        void DeleteThings(Entertainers entertainers);
    }
}
