using System;

public class ExamResult
{
    private int grade = 0;
    private int minGrade = 0;
    private int maxGrade = 0;
    private string comments = null;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < this.minGrade || value > this.maxGrade)
            {
                throw new ArgumentOutOfRangeException("Grade");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Min grade");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value < this.minGrade)
            {
                throw new ArgumentOutOfRangeException("Max grade");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Comments is null or empty!");
            }

            this.comments = value;
        }
    }

    public decimal CalcInPercents()
    {
        return ((decimal)this.Grade - this.MinGrade) / (this.MaxGrade - this.MinGrade + 1);
    }
}