using Clean.Architecture.Domain.Defination;

namespace Clean.Architecture.Application.Interfaces.Persistance.Defination
{
    public interface IAdminAccountData
    {
        AdminAccount Login(string UserName, string Password);

    }
}