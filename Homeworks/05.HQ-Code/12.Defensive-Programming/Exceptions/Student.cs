using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName = null;
    private string lastName = null;
    private IList<Exam> exams = null;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First name cannot be null or white space!");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid last name!");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        private set
        {
            this.exams = value ?? new List<Exam>();
        }
    }

    public IList<ExamResult> CheckExams()
    {
        return this.Exams.Select(exam => exam.Check()).ToList();
    }

    public decimal CalcAverageExamResultInPercents()
    {
        return this.CheckExams().Average(res => res.CalcInPercents());
    }
}