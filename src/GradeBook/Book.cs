using System;
using System.Collections.Generic;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);
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
        if(GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      // else
      // {
      //   throw new ArgumentException($"Invalid {nameof(grade)}");
      // }
    }

    public void AddGrade(char letter)
    {
      switch (letter)
      {
          case 'A':
            AddGrade(90);
            break;

          case 'B':
            AddGrade(80);
            break;

          case 'C':
            AddGrade(70);
            break;

          case 'D':
            AddGrade(60);
            break;

          default:
            AddGrade(0);
            break;
      }
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      if (this.grades.Count == 0)
      {
          return result;
      }

      // foreach (double grade in this.grades)
      for (int index = 0; index < this.grades.Count; index += 1)
      {
        result.Low = Math.Min(this.grades[index], result.Low);
        result.High = Math.Max(this.grades[index], result.High);
        result.Average += this.grades[index];
      }
  
      result.Average /= this.grades.Count;

      switch (result.Average)
      {
          case var d when d >= 90.0:
            result.Letter = 'A';
            break;

          case var d when d >= 80.0:
            result.Letter = 'B';
            break;

          case var d when d >= 70.0:
            result.Letter = 'C';
            break;

          case var d when d >= 60.0:
            result.Letter = 'D';
            break;

          default:
            result.Letter = 'F';
            break;
      }

      return result;
    }

    // Fields.
    private List<double> grades;

    public event GradeAddedDelegate GradeAdded;

    // Properties.
    // Long hand syntax
    public string Name
    {
        get; set;
        // private set;
    }

    // Short hand syntax
    // readonly string CATEGORY = "Science";
    // const field is a static member and it can't be accessed via an object reference,
    // const can obly be accessed by using the type name (the class name)
    public const string CATEGORY = "Science";
  }
}
