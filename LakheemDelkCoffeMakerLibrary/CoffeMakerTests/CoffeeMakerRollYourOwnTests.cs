using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMakerLibrary;

namespace CoffeeMakerTests
{
    [TestClass]
    public class CoffeeMakerRollYourOwnTests
    {

        [TestMethod]
        public void RYOTest1()
        {
            
            CoffeeContainer coffeTest = new CoffeeContainer();
            WaterContainer waterTest = new WaterContainer();
            CoffeeMaker makerTest = new CoffeeMaker(coffeTest, waterTest);
            // ARRANGE
            // Call Fill() to fill the coffee maker.
            makerTest.Fill();
            // ACT
            // Call MakeCoffee() requesting a Grande(3).
            makerTest.MakeCoffee(Portion.Grande);
            // ARRANGE
            // Set the coffee to 8 using the CoffeeVolume property.
            // Set the water to 6 using the WaterVolume property.
            makerTest.CoffeeVolume = 8;
            makerTest.WaterVolume = 6;
            // ACT 
            // MakeCoffee() requesting a Tall(2).
            makerTest.MakeCoffee(Portion.Tall);
            // ASSERT
            // Assert that the coffee volume is now 6 using the CoffeeVolume property.
            // Assert that the water volume is now 4 using the WaterVolume property.

            Assert.AreEqual(6, makerTest.CoffeeVolume);
            Assert.AreEqual(4, makerTest.WaterVolume);
        }

        [TestMethod]
        public void RYOTest3()
        {
            CoffeeContainer coffeTest = new CoffeeContainer();
            WaterContainer waterTest = new WaterContainer();
            CoffeeMaker makerTest = new CoffeeMaker(coffeTest, waterTest);
            // ARRANGE
            // Set the coffee to 5 using the CoffeeVolume property.
            // Set the water to 5 using the WaterVolume property. 
            makerTest.CoffeeVolume = 5;
            makerTest.WaterVolume = 5;
            // ACT
            // Clean() the coffee maker.
            makerTest.Clean();
            // ASSERT
            // Assert that the coffee volume is now 0 using the IsEmpty property.
          
            Assert.AreEqual(true, makerTest.IsEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RYOTest4()
        {
            CoffeeContainer coffeTest = new CoffeeContainer();
            WaterContainer waterTest = new WaterContainer();
            CoffeeMaker makerTest = new CoffeeMaker(coffeTest, waterTest);
            // ARRANGE
            // Set the coffee to 4 using the CoffeeVolume property.
            // Set the water to 2 using the WaterVolume property. 
            makerTest.CoffeeVolume = 4;
            makerTest.WaterVolume = 2;

            // ACT
            // MakeCoffee requesting a Grande(3).
            makerTest.MakeCoffee(Portion.Grande);
            // EXPECTED EXCEPTION
            // Check that an InvalidOperationException is thrown.
        }
    }

}
