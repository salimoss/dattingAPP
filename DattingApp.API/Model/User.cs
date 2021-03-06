using System;
using System.Collections.Generic;

namespace DattingApp.API.Model
{
    public class User
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        
        public string  Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnowAs { get; set; }
        public DateTime Created { get; set; }   
        public DateTime LastActive { get; set; }    
        public string Introduction { get; set; }    
        public string LookingFor { get; set; }  
        public string  Interests    { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public ICollection<Photo> Photos { get; set; }


        

    }
}