using System;
using System.Collections.Generic;

public class SimpleMathExam : Exam
{
    private readonly SortedDictionary<int, KeyValuePair<int, string>> marks =
        new SortedDictionary<int, KeyValuePair<int, string>>
    {
        { 0, new KeyValuePair<int, string>(2, "Bad result: nothing done.") },
        { 1, new KeyValuePair<int, string>(4, "Average result: something done.") },
        { 2, new KeyValuePair<int, string>(6, "Excelent result: everything done.") }
    };

    private int problemsSolved = 0;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0 || value > 2)
            {
                throw new ArgumentOutOfRangeException("Problem solved must be between 0 and 2!");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        var mark = this.marks[this.problemsSolved];

        return new ExamResult(mark.Key, 2, 6, mark.Value);
    }
}