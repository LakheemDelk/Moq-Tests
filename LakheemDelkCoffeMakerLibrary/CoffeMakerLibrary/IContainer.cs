using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerLibrary
{
    public interface IContainer
    {
        // Subtracts the requested portion from the current volume.
        // Throws InvalidOperationException if container does not have enough to dispense requested portion.
        void DispensePortion(int portion);

        // Return the current volume.
        int GetVolume();

        // Sets the current volume.
        void SetVolume(int volume);

        // Sets the container volume to 0.
        void Empty();

        // Fills container to maximum volume (10).
        void Fill();

        // Returns true is container is empty, otherwise false.
        bool IsEmpty
        {
            get;
        }

        // Cleans the container.
        void Clean();
    }
}
