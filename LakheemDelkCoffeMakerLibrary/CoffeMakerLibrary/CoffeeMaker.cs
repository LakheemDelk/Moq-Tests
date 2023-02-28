using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerLibrary
{
    public class CoffeeMaker : ICoffeeMaker
    {
        IContainer waterContainer;
        IContainer coffeeContainer;

        // Construct CoffeeMaker
        public CoffeeMaker(IContainer waterContainer, IContainer coffeeContainer)
        {
            this.waterContainer = waterContainer;
            this.coffeeContainer = coffeeContainer;
        }

        // Make requested coffee portion
        public void MakeCoffee(int portion)
        {
            waterContainer.DispensePortion(portion);
            coffeeContainer.DispensePortion(portion);
        }

        // Fill with water and coffee
        public void Fill()
        {
            waterContainer.Fill();
            coffeeContainer.Fill();
        }

        // Empty all water and coffee and clean both containers (coffee twice)
        public void Clean()
        {
            waterContainer.Empty();
            waterContainer.Clean();

            coffeeContainer.Empty();
            coffeeContainer.Clean();
            coffeeContainer.Clean();
        }

        // Gets and set the coffee volume
        public int CoffeeVolume
        {
            get
            {
                return coffeeContainer.GetVolume();
            }
            set
            {
                coffeeContainer.SetVolume(value);
            }
        }

        // Gets and sets the water volume
        public int WaterVolume
        {
            get
            {
                return waterContainer.GetVolume();
            }

            set
            {
                waterContainer.SetVolume(value);
            }
        }

        // Returns true if there is no water or coffee
        public bool IsEmpty
        {
            get
            {
                return waterContainer.IsEmpty && coffeeContainer.IsEmpty;
            }
        }

    }
}
