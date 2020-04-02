using System;

namespace DattingApp.API.Dtos
{
    public class PhotosForDetaileDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; } 
        public DateTime DateAdded { get; set; }

        
        public bool IsMain { get; set; }
    }
}