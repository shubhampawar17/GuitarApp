using GuitarApp.Controller;
using GuitarApp.Presentation;
using GuitarApp.Service;

namespace GuitarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuitarPresentation presentation = new GuitarPresentation(new GuitarManager(new ServiceGuitar()));
            presentation.ShowMenu();
        }
    }
}
