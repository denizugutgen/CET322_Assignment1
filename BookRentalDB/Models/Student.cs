namespace BookRentalDB.Models;

public class Student
{
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string Mail { get; set; }
}