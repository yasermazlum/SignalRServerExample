namespace SignalRServerExample.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserConnected(string clientId);
        Task UserDisonnected(string clientId);
    }
}
