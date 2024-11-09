using ITI_Project.Data;
using ITI_Project.Models;
using ITI_Project.ViewModel;

namespace ITI_Project.Repository
{
    public interface IAccountRepo
    {
        public void Register(Account acc);
        public Account GetUserByUserName(LoginViewModel acc);
    }
    public class AccountRepo : IAccountRepo
    {
        ITIContext db; 
        public AccountRepo(ITIContext _db)
        {
            db = _db;
        }
        
        public void Register(Account acc)
        {
            db.Accounts.Add(acc);
            db.SaveChanges();
        }
        public Account GetUserByUserName(LoginViewModel acc)
        {
            return db.Accounts.FirstOrDefault(a => a.UserName == acc.UserName);
        }
    }
}
