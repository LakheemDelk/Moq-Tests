using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerLibrary
{
   public class CoffeeContainer : IContainer
    {
        public int Volume = 0;
        public int SOAP = 0;
        public int Dry = 0;

        public void DispensePortion(int portion)
        {
            if (this.Volume > portion)
            {
                this.Volume = this.Volume - portion;
            }
            else 
            {
                check();

                throw new InvalidOperationException();
            }
            check();

        }

        // Return the current volume.
        public int GetVolume()
        {

            return this.Volume;
            check();
        }

        // Sets the current volume.
        public void SetVolume(int volume)
        {

            this.Volume = volume;
            check();

        }

        // Sets the container volume to 0.
        public void Empty()
        {
            this.Volume = 0;
            check();
        }

        // Fills container to maximum volume (10).
        public void Fill()
        {
            this.Volume = 10;
            check();
        }

        // Returns true is container is empty, otherwise false.
        public bool IsEmpty
        {
            get;
            set;
        }

        public void check()
        {
            if(Volume == 0) 
            {
                IsEmpty = true;
            }
            else
            {
                IsEmpty = false;
            }


        }   

        // Cleans the container.
        public void Clean()
        {
            if (this.Volume != 0)
            {
                Empty();
            }
            this.Volume = this.Volume + SOAP;
            this.Volume = this.Volume - SOAP;
            this.Volume = this.Volume + Dry;
            check();
        }
     
        

    }
}
