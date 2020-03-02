using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        //public void AddLetterGrade(char letter)
        //{
        //    if(letter == 'A')
        //    {
        //        AddGrade(90);
        //    }
        //    else if(letter == 'B')
        //    {
        //        AddGrade(80);
        //    }
        //    else
        //    {
        //        AddGrade(50);
        //    }
        //}

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                default:
                    AddGrade(50);
                    break;
            }
        }


        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            //for each looping construct example

            //foreach (var grade in grades)
            //{
            //    result.Low = Math.Min(grade, result.Low);
            //    result.High = Math.Max(grade, result.High);
            //    result.Average += grade;
            //}

            //Do While looping construct example with protective IF

            //var index = 0;
            //if (grades.Count == 0)
            //{
            //    do
            //    {
            //        result.Low = Math.Min(grades[index], result.Low);
            //        result.High = Math.Max(grades[index], result.High);
            //        result.Average += grades[index];
            //        index += 1;
            //    } while (index < grades.Count);
            //};

            //While looping construct 

            //while (index < grades.count)
            //{
            //    result.Low = Math.Min(grades[index], result.Low);
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //};

            //For looping construct (with a break statement added)

            for (var index = 0; index < grades.Count; index += 1)
            {
                if(grades[index] == 42.1)
                {
                    break; //breaks out of for loop, continue iterates next loop pass, goto jumps to a named tag value
                }
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }


            result.Average /= grades.Count;

            //switch as a pattern matching tool

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }


        private List<double> grades;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                
            }
        }
        private string name;
    }
}