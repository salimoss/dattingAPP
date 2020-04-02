using System;

namespace DattingApp.API.Dtos
{
    public class UserForListDto
    {
         public int Id { get; set; }
        
        public string Username { get; set; }
                
        public string  Gender { get; set; }
        public int Age { get; set; }
        public string KnowAs { get; set; }
        public DateTime Created { get; set; }   
        public DateTime LastActive { get; set; }    
        public string city { get; set; }
        public string country { get; set; }
        public string PhotoUrl { get; set; }
    }
}