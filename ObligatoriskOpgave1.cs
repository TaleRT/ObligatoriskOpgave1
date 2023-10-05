using System.Reflection;
using System.Security.Cryptography.X509Certificates;
    public class Book
    {
        public string? Title { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
  

    public void ValidateTitle()
    {
        if (Title == null)
        {
            throw new ArgumentNullException("Der skal være en titel");
        }
        if (Title.Length <= 3)
        {
            throw new ArgumentException("Titlen skal være 3 karaktere");
        }
    }
    
    public void ValidatePrice()
    {
        if (Price <= 0 || Price > 1200)
        {
            throw new ArgumentException("Det skal være et positivt tal eller under 1200");
        }
    }
    public override string ToString()
    {
        return $"ID: {Id}, Title: {Title}, Price: {Price:C}";
    }







}
