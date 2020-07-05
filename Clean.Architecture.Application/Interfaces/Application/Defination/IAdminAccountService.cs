using Clean.Architecture.Domain.Defination;

namespace Clean.Architecture.Application.Interfaces.Application.Defination
{
    public interface IAdminAccountService
    {
        AdminAccount Login(string UserName, string Password);

    }
}
