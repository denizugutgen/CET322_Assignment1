using BookRentalDB.Data;
using BookRentalDB.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace BookRentalDB.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        StudentRepository repository = new StudentRepository();

        var students = repository.GetAllStudents();
        return View(students);

    }

    public IActionResult Detail(int id)
    {
        StudentRepository repository = new StudentRepository();
        var student = repository.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            return View(student);
            
        }
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        StudentRepository repository = new StudentRepository();
        repository.Insert(student);
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int id)
    {
        StudentRepository repository = new StudentRepository();
        var student = repository.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            return View(student);
        }
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            StudentRepository repository = new StudentRepository();
            repository.Update(student); 
            return RedirectToAction("Index");
        }

        return View(student);
    }

    public IActionResult Delete(int id)
    {
        StudentRepository repository = new StudentRepository();
        repository.Delete(id);
        return RedirectToAction("Index");
    }
    
}