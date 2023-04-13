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

        public HotDogStand HotDogStand
        {
            get { return hotDogStand; }
            set { hotDogStand = value; }
        }
        private FrenchFriesStand friesStand;

        public FrenchFriesStand FriesStand
        {
            get { return friesStand; }
            set { friesStand = value; }
        }


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

            mediator.HotDogStand = new HotDogStand(mediator);
            mediator.FriesStand = new FrenchFriesStand(mediator);

            var hotdogKitchen= mediator.HotDogStand;
            var friesKitchen= mediator.FriesStand;

            hotdogKitchen.Send("Can you send more cooking oil?");
            friesKitchen.Send("Sure thing, Homer's on his way");

            friesKitchen.Send("Do you have any extra soda? We've had a rush on them over here.");
            hotdogKitchen.Send("Just a couple, we'll send Homer back with them");

            Console.ReadKey();
        }
    }
}
