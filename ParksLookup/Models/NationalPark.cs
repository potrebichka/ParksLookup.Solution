using System.ComponentModel.DataAnnotations;

namespace ParksLookup.Models
{
    public class NationalPark
    {
        public int NationalParkId {get;set;}
        [Required]
        public string States {get;set;} 
        public string LatLong {get;set;} 
        public string Description {get;set;} 
        public string Designation {get;set;} 
        public string ParkCode {get;set;}  
        public string ParkId {get;set;}    
        public string DirectionsInfo {get;set;} 
        public string DirectionsUrl {get;set;} 
        public string FullName {get;set;} 
        public string Url {get;set;} 
        public string WeatherInfo {get;set;} 
        [Required]
        public string Name {get;set;} 
    }
}

