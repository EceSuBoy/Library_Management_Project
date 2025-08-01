using System.Collections.Generic;
using Library_Automation.Entities.Model;  // Make sure this matches your actual namespace

namespace Library_Automation_Project.ViewModels
{
    public class HomeViewModel
    {
        public List<Kitaplar> LastFiveBooks { get; set; }
        public List<Kitaplar> PopularBooks { get; set; }
    }
}
