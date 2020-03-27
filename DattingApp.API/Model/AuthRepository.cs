using System;
using System.Threading.Tasks;
using DattingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DattingApp.API.Model
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
           _context = context;

        }
        public async Task<User> Loging(string username, string password)
        {
           // throw new System.NotImplementedException();
           var user= await _context.users.FirstOrDefaultAsync(
               x =>x.Username==username
           );
            if(user == null)
            return null;
            if(!VerifyPasswordHash(password,user.PasswordHash,user.passwordSalt))
            return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
           using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)
            ){
                
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           for(int i=0;i<computedHash.Length;i++)
           {
               if (computedHash[i] != passwordHash[i]) return false;
           }
           
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
           // throw new System.NotImplementedException();
             byte[] passwordHash,passwordSalt;
            CreatePasswordHash(password,out passwordHash,out passwordSalt);
            user.PasswordHash=passwordHash;
            user.passwordSalt=passwordSalt;
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()
            ){
                passwordSalt=hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            //throw new System.NotImplementedException();
        if (await _context.users.AnyAsync(
            x => x.Username == username
        ))
        return true;
        return false;
        }
    }
}