using BookRentalDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookRentalDB.Data;

public class StudentRepository
{
    private static List<Student> data = new List<Student>()
    {
        new Student { ID = 1, Name = "Hüseyin", Surname = "Simsek", BirthDate = new DateTime(1990, 1, 1), Mail = "huseyinsimsek@gmail.com"},
        new Student { ID = 2, Name = "Ali", Surname = "Yılmaz", BirthDate = new DateTime(2001, 1, 1), Mail = "aliyılmaz@gmail.com" },
    };

    public List<Student> GetAllStudents()
    {
        return data;
        
    }

    public Student GetStudent(int id) //select * from students where ID=1
    {
        Student result = data.Where(s => s.ID == id).FirstOrDefault();
        return result;
    }

    public void Delete(int id)
    {
        var student = GetStudent(id);
        data.RemoveAll(d=> d.ID == id);
    }

    public void Insert(Student student)
    {
        data.Add(student);
    }

    public void Update(Student student)
    {
        var studentInDB = data.Where(s => s.ID == student.ID).FirstOrDefault();
        
        studentInDB.Name = student.Name;
        studentInDB.Surname = student.Surname;
        studentInDB.BirthDate = student.BirthDate;
    }

    //delete for student --index sayfasına
    //edit butonu koy aynı sayfaya ama içi doly gelecek
    //create butonu koy 
    //id alanı değişemeyecek
    //yeni yaratılan öğrenciyi creatle sonra indexe geç
    
}