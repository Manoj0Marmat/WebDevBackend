using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevBackend.Models;

namespace WebDevBackend.Dtos.Event
{
    public class AddEventDto
    {
        public string Name { get; set; } // Name of the event
        public string Tagline { get; set; } // Tagline for the event
        public DateTime Schedule { get; set; } // Date and time of the event
        public string Description { get; set; } // Description of the event
        public IFormFile Image { get; set; } // Image file upload
        public string Moderator { get; set; } // User who is going to host
        public EventCategoryClass Category { get; set; } // Category of the event
        public EventSubCategoryClass SubCategory { get; set; } // Subcategory of the event
        public int RigorRank { get; set; } // Integer value representing rigor rank
        public int[] Attendees { get; set; } // Array of user IDs attending the event
    }
}