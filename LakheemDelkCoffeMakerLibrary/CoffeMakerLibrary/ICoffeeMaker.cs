namespace CoffeeMakerLibrary
{
    public interface ICoffeeMaker
    {
        int CoffeeVolume { get; set; }
        bool IsEmpty { get; }
        int WaterVolume { get; set; }

        void Clean();
        void Fill();
        void MakeCoffee(int portion);
    }
}