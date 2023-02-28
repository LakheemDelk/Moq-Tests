using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMakerLibrary;
using Moq;

namespace CoffeeMakerTests
{
    [TestClass]
    public class CoffeeMakerMoqTests
    {
        [TestMethod]
        public void MOQTest1()
        {
            int waterVolume = 0;
            int coffeeVolume = 0;
            
            Mock<IContainer> waterMock= new Mock<IContainer>();
            waterMock.Setup(wat => wat.DispensePortion(It.IsAny<int>()))
                               .Callback((int amount) =>
                               {
                                   waterVolume = waterVolume - amount;
                                });
            waterMock.Setup(wat => wat.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 waterVolume = amount;
                             });
            waterMock.Setup(wat => wat.GetVolume())
                             .Returns(waterVolume); 
            waterMock.Setup(wat => wat.Fill())
                              .Callback(() =>
                              {
                                  waterVolume = 10;
                              });

            Mock<IContainer> coffeeMock = new Mock<IContainer>();

            coffeeMock.Setup(cof => cof.DispensePortion(It.IsAny<int>()))
                              .Callback((int amount) =>
                              {
                                  coffeeVolume = coffeeVolume - amount;
                              });
            coffeeMock.Setup(cof => cof.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 coffeeVolume = amount;
                             });
            coffeeMock.Setup(cof => cof.GetVolume())
                             .Returns(coffeeVolume);
            coffeeMock.Setup(cof => cof.Fill())
                              .Callback(() =>
                              {
                                  coffeeVolume = 10;
                              });

            CoffeeMaker makerTest = new CoffeeMaker(waterMock.Object, coffeeMock.Object);
            // ARRANGE
            // Call Fill() to fill the coffee maker.
            makerTest.Fill();
            // ACT
            // Call MakeCoffee() requesting a Grande(3).
            makerTest.MakeCoffee(Portion.Grande);
            // ASSERT
            // Assert that the coffee volume is now 7 using the CoffeeVolume property.
            // Assert that the water volume is now 7 using the WaterVolume property.
            makerTest.WaterVolume = waterVolume;
            makerTest.CoffeeVolume = coffeeVolume;
            Assert.AreEqual(7, waterVolume);
            Assert.AreEqual(7, coffeeVolume);
        }

        [TestMethod]
        public void MOQTest2()
        {
            int waterVolume = 0;
            int coffeeVolume = 0;

            Mock<IContainer> waterMock = new Mock<IContainer>();
            waterMock.Setup(wat => wat.DispensePortion(It.IsAny<int>()))
                               .Callback((int amount) =>
                               {
                                   waterVolume = waterVolume - amount;
                               });
            waterMock.Setup(wat => wat.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 waterVolume = amount;
                             });
            waterMock.Setup(wat => wat.GetVolume())
                             .Returns(waterVolume);
            waterMock.Setup(wat => wat.Fill())
                              .Callback(() =>
                              {
                                  waterVolume = 10;
                              });

            Mock<IContainer> coffeeMock = new Mock<IContainer>();

            coffeeMock.Setup(cof => cof.DispensePortion(It.IsAny<int>()))
                              .Callback((int amount) =>
                              {
                                  coffeeVolume = coffeeVolume - amount;
                              });
            coffeeMock.Setup(cof => cof.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 coffeeVolume = amount;
                             });
            coffeeMock.Setup(cof => cof.GetVolume())
                             .Returns(coffeeVolume);
            coffeeMock.Setup(cof => cof.Fill())
                              .Callback(() =>
                              {
                                  coffeeVolume = 10;
                              });

            CoffeeMaker makerTest = new CoffeeMaker(waterMock.Object, coffeeMock.Object);
            // ARRANGE
            // Set the coffee to 8 using the CoffeeVolume property.
            // Set the water to 6 using the WaterVolume property.
            makerTest.CoffeeVolume = 8;
            makerTest.WaterVolume = 6;
            waterVolume = 6;
            coffeeVolume = 8;

            // ACT 
            // MakeCoffee() requesting a Tall(2).
            makerTest.MakeCoffee(Portion.Tall);
            // ASSERT
            // Assert that the coffee volume is now 6 using the CoffeeVolume property.
            // Assert that the water volume is now 4 using the WaterVolume property.
            Assert.AreEqual(6, coffeeVolume);
            Assert.AreEqual(4, waterVolume);
        }

        [TestMethod]
        public void MOQTest3()
        {
            int waterVolume = 0;
            int coffeeVolume = 0;

            Mock<IContainer> waterMock = new Mock<IContainer>();
            waterMock.Setup(wat => wat.DispensePortion(It.IsAny<int>()))
                               .Callback((int amount) =>
                               {
                                   waterVolume = waterVolume - amount;
                               });
            waterMock.Setup(wat => wat.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 waterVolume = amount;
                             });
            waterMock.Setup(wat => wat.GetVolume())
                             .Returns(waterVolume);
            waterMock.Setup(wat => wat.IsEmpty)
                             .Returns(true);
            waterMock.Setup(wat => wat.Clean())
                              .Callback(() =>
                              {
                                  waterVolume = 0;
                              });

            Mock<IContainer> coffeeMock = new Mock<IContainer>();

            coffeeMock.Setup(cof => cof.DispensePortion(It.IsAny<int>()))
                              .Callback((int amount) =>
                              {
                                  coffeeVolume = coffeeVolume - amount;
                              });
            coffeeMock.Setup(cof => cof.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 coffeeVolume = amount;
                             });
            coffeeMock.Setup(cof => cof.GetVolume())
                             .Returns(coffeeVolume);
            coffeeMock.Setup(cof => cof.IsEmpty)
                             .Returns(true);
            coffeeMock.Setup(cof => cof.Clean())
                              .Callback(() =>
                              {
                                  coffeeVolume = 0;
                              });

            CoffeeMaker makerTest = new CoffeeMaker(waterMock.Object, coffeeMock.Object);

            // ARRANGE
            // Set the coffee to 5 using the CoffeeVolume property.
            // Set the water to 5 using the WaterVolume property. 
            waterVolume = 5;
            coffeeVolume = 5;
            // ACT
            // Clean() the coffee maker.
            makerTest.Clean();

            // ASSERT
            // Assert that the coffee volume is now 0 using the IsEmpty property.
            Assert.AreEqual(makerTest.IsEmpty, true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MOQTest4()
        {
            int waterVolume = 0;
            int coffeeVolume = 0;

            Mock<IContainer> waterMock = new Mock<IContainer>();
            waterMock.Setup(wat => wat.DispensePortion(It.IsAny<int>()))
                              .Throws<InvalidOperationException>();
            waterMock.Setup(wat => wat.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 waterVolume = amount;
                             });
            waterMock.Setup(wat => wat.GetVolume())
                             .Returns(waterVolume);
            waterMock.Setup(wat => wat.Fill())
                              .Callback(() =>
                              {
                                  waterVolume = 10;
                              });

            Mock<IContainer> coffeeMock = new Mock<IContainer>();

            coffeeMock.Setup(cof => cof.DispensePortion(It.IsAny<int>()))
                              .Throws<InvalidOperationException>();
                        
            coffeeMock.Setup(cof => cof.SetVolume(It.IsAny<int>()))
                             .Callback((int amount) =>
                             {
                                 coffeeVolume = amount;
                             });
            coffeeMock.Setup(cof => cof.GetVolume())
                             .Returns(coffeeVolume);
            coffeeMock.Setup(cof => cof.Fill())
                              .Callback(() =>
                              {
                                  coffeeVolume = 10;
                              });

            CoffeeMaker makerTest = new CoffeeMaker(waterMock.Object, coffeeMock.Object);

            // ARRANGE
            // Set the coffee to 4 using the CoffeeVolume property.
            // Set the water to 2 using the WaterVolume property. 
            coffeeVolume = 4;
            waterVolume = 2;
            // ACT
            // MakeCoffee requesting a Grande(3).
            makerTest.MakeCoffee(Portion.Grande);
            // EXPECTED EXCEPTION
            // Check that an InvalidOperationException is thrown.
        }


        [TestMethod]
        public void MOQTest5()
        {
            // ARRANGE
            int waterVolume = 0;
            int coffeeVolume = 0;

            Mock<IContainer> waterMock = new Mock<IContainer>();
            waterMock.Setup(wat => wat.Clean())
                               .Callback(() =>
                               {
                                   waterVolume = 0;
                               });
            waterMock.Setup(wat => wat.Fill())
                              .Callback(() =>
                              {
                                  waterVolume = 10;
                              });

            Mock<IContainer> coffeeMock = new Mock<IContainer>();
            coffeeMock.Setup(cof => cof.Clean())
                             .Callback(() =>
                             {
                                 coffeeVolume = 0;
                             });
            coffeeMock.Setup(cof => cof.Fill())
                              .Callback(() =>
                              {
                                  coffeeVolume = 10;
                              });

            CoffeeMaker makerTest = new CoffeeMaker(waterMock.Object, coffeeMock.Object);
            // ACT
            // Clean() the CoffeeMaker.
            makerTest.Clean();
            // VERIFY
            // Verify that cleaning the CoffeeMaker calls the water containers Clean() once.
            // Verify that cleaning the CoffeeMaker calls the coffee containers Clean() twice.
            waterMock.Verify(wat => wat.Clean(), Times.Once());
            coffeeMock.Verify(cof => cof.Clean(), Times.Exactly(2));
        }

    }
}
