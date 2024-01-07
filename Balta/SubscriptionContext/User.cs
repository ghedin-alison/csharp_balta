using Balta.SharedContext;

namespace Balta.SubscriptionContext;

public class User: Base
{
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
}