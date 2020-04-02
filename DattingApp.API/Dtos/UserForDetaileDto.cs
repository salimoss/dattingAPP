using System;
using System.Collections.Generic;
using DattingApp.API.Model;

namespace DattingApp.API.Dtos
{
    public class UserForDetaileDto
    {
         public int Id { get; set; }
        
        public string Username { get; set; }

        
        public string  Gender { get; set; }
        public int Age { get; set; }
        public string KnowAs { get; set; }
        public DateTime Created { get; set; }   
        public DateTime LastActive { get; set; }    
        public string Introduction { get; set; }    
        public string LookingFor { get; set; }  
        public string  Interests    { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        
        public string PhotoUrl { get; set; }

        public ICollection<PhotosForDetaileDto> Photos { get; set; }
    }
}