using Clean.Architecture.Domain.Defination;

namespace Clean.Architecture.Domain.Interfaces.Defination
{
    public interface IAdminAccountData
    {
        AdminAccount Login(string UserName, string Password);

    }
}