using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public interface IMediator
    {
        void SendMessage(string message, SnackBar snackBar);
    }
    public class SnackBar
    {
        protected IMediator _mediator;

        public SnackBar(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
    public class HotDogStand : SnackBar
    {
        public HotDogStand(IMediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine($"HotDog Stand says: {message}");
            _mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine($"HotDog Stand gets message: {message}");
        }
    }
    public class FrenchFriesStand : SnackBar
    {
        public FrenchFriesStand(IMediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine($"French Fries Stand says: {message}");
            _mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine($"French Fries Stand gets message: {message}");
        }
    }
    public class SnackBarMediator : IMediator
    {
        private HotDogStand hotDogStand;
        private FrenchFriesStand friesStand;

        public HotDogStand HotDogStand { set { hotDogStand = value; } }
        public FrenchFriesStand FriesStand { set { friesStand = value; } }

        public void SendMessage(string message, SnackBar snackBar)
        {
            if (snackBar == hotDogStand)
                friesStand.Notify(message);
            if (snackBar == friesStand)
                hotDogStand.Notify(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SnackBarMediator mediator = new SnackBarMediator();

            HotDogStand hotdogKitchen = new HotDogStand(mediator);
            FrenchFriesStand friesKitchen = new FrenchFriesStand(mediator);

            mediator.HotDogStand = hotdogKitchen;
            mediator.FriesStand = friesKitchen;

            hotdogKitchen.Send("Can you send more cooking oil?");
            friesKitchen.Send("Sure thing, Homer's on his way");

            friesKitchen.Send("Do you have any extra soda? We've had a rush on them over here.");
            hotdogKitchen.Send("Just a couple, we'll send Homer back with them");

            Console.ReadKey();
        }
    }
}
