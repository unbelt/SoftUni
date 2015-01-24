﻿using System;

public class CSharpExam : Exam
{
    private const int MinGrade = 0;
    private const int MaxGrade = 100;
    private int score = 0;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (this.Score < MinGrade || this.Score > MaxGrade)
            {
                throw new ArgumentOutOfRangeException("Score");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinGrade, MaxGrade, "Exam results calculated by score.");
    }
}