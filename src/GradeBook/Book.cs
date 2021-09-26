using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    // Class Constructor is public & uses same name as class.
    public Book(string name)
    {
      this.grades = new List<double>();
      Name = name;
    }
    
    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        this.grades.Add(grade);
      }
      else
      {
        Console.WriteLine("Invalid Value")
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach (double grade in this.grades)
      {
        result.Low = Math.Min(grade, result.Low);
        result.High = Math.Max(grade, result.High);
        result.Average += grade;
      }

      result.Average /= this.grades.Count;

      return result;
    }

    // Fields.
    private List<double> grades;
    public string Name;
  }
}
