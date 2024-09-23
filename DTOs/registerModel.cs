namespace BookServicesApi.DTOs
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }  
        public string Address {get;set;}
        public string City {get;set;}
        public string Province {get;set;}
        public string ZipCode {get;set;}
        public string Phone {get;set;}

    }
}