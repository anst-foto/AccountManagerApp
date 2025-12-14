using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagerApp.BLL;

public class AccountsService : BaseService, ICrud<Account>
{
    public async IAsyncEnumerable<Account> GetAllAsync()
    {
        //return _db.Accounts.Include(a => a.User).AsAsyncEnumerable();

        var accounts = await _db.Accounts
            .ToListAsync();

        foreach (var account in accounts)
        {
            yield return account;
        }
    }

    public async Task<Account> AddAsync(Account entity)
    {
        var newAccount = await _db.Accounts.AddAsync(entity);
        await _db.SaveChangesAsync();

        return newAccount.Entity;
    }

    public async Task<Account> UpdateAsync(Account entity)
    {
        var updateAccount = _db.Accounts.Update(entity);
        await _db.SaveChangesAsync();

        return updateAccount.Entity;
    }

    public async Task<Account> DeleteAsync(Account entity)
    {
        entity.IsActive = false;

        return await UpdateAsync(entity);
    }
}
