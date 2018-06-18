using System.Threading.Tasks;

namespace AsyncStateMachine
{
    public delegate Task<TrafficLightStateFunction> TrafficLightStateFunction(TrafficLightState state);
}