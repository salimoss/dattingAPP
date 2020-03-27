
using System.Threading.Tasks;
using DattingApp.API.Model;


namespace DattingApp.API.Data
{
    public interface IAuthRepository
    {
         Task <User> Register(User user,string password);
         Task <User> Loging(string username, string password );
         Task <bool> UserExists(string username);
    }
}