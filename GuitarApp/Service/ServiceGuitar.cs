using GuitarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Service
{
    public class ServiceGuitar
    {
        private List<Guitar> guitars = new List<Guitar>();

        public List<Guitar> GetMatchingGuitars(GuitarSpec searchSpec)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();

            foreach (var guitar in guitars)
            {
                if (guitar.GetSpec().Matches(searchSpec))
                {
                    matchingGuitars.Add(guitar);
                }
            }

            return matchingGuitars;
        }

        public void AddGuitar(Guitar guitar)
        {
            guitars.Add(guitar);
        }
    }
}