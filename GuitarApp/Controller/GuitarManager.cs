using GuitarApp.Exceptions;
using GuitarApp.Models;
using GuitarApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Controller
{
    public class GuitarManager
    {
        private ServiceGuitar service;

        public GuitarManager(ServiceGuitar service)
        {
            this.service = service;
        }

        public List<Guitar> SearchGuitars(GuitarSpec searchSpec)
        {
            List<Guitar> matchingGuitars = service.GetMatchingGuitars(searchSpec);

            if (matchingGuitars.Count == 0)
            {
                throw new GuitarNotFoundException("No guitars found with the specifications.");
            }

            return matchingGuitars;
        }

        public void AddGuitar(Guitar guitar)
        {
            if (guitar == null)
            {
                throw new InvalidGuitarSpecException("Cannot add a null guitar.");
            }
            service.AddGuitar(guitar);
        }
    }
}
