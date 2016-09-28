namespace ASPNETWcfServiceNoConfig
{
    public class MyService : IMyService
    {
        public string DoSomething(int value, string data)
        {
            return string.Format("You sent: {0} and {1}", value, data);
        }
    }
}