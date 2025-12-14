using AccountManagerApp.DAL;

namespace AccountManagerApp.BLL;

public abstract class BaseService
{
    protected readonly DataBaseContext _db = DataBaseContextFactory.Create();
}
