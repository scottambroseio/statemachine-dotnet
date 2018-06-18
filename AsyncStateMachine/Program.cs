using System;
using System.Threading.Tasks;

namespace AsyncStateMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var state = new TrafficLightState();
                TrafficLightStateFunction stateFunction = Red;

                while (stateFunction != null)
                {
                    stateFunction = await stateFunction(state);
                }
            });

            Console.ReadKey();
        }

        public static async Task<TrafficLightStateFunction> Red(TrafficLightState state)
        {
            state.Red = true;
            state.Amber = false;
            state.Green = false;

            Console.WriteLine("RED");

            await Task.Delay(TimeSpan.FromSeconds(3));

            return RedAndAmber;
        }

        public static async Task<TrafficLightStateFunction> RedAndAmber(TrafficLightState state)
        {
            state.Red = true;
            state.Amber = true;
            state.Green = false;

            Console.WriteLine("RED and AMBER");

            await Task.Delay(TimeSpan.FromSeconds(3));

            return Green;
        }

        public static async Task<TrafficLightStateFunction> Green(TrafficLightState state)
        {
            state.Red = false;
            state.Amber = false;
            state.Green = true;

            Console.WriteLine("GREEN");

            await Task.Delay(TimeSpan.FromSeconds(12));

            return Amber;
        }

        public static async Task<TrafficLightStateFunction> Amber(TrafficLightState state)
        {
            state.Red = false;
            state.Amber = true;
            state.Green = false;

            Console.WriteLine("AMBER");

            await Task.Delay(TimeSpan.FromSeconds(3));

            return Red;
        }
    }
}
