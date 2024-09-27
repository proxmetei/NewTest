namespace NewTest.Context.Seeder;

using NewTest.Context.Entities;

public class DemoHelper
{
    public IEnumerable<Survey> GetSurveys = new List<Survey>
    {
        new Survey()
        {
            Name = "First Survey",
            SurveyQuestionNumbers = new List<SurveyQuestionNumber>()
            {
                new SurveyQuestionNumber()
                {
                    Question = new Question
                    {
                        Text = "First Question",
                        Answers = new List<Answer>()
                        {
                            new Answer ()
                            {
                                Text = "First Answer"
                            },
                            new Answer ()
                            {
                                Text = "Second Answer"
                            }
                        }
                    },
                    Number = 1
                },
                new SurveyQuestionNumber()
                {
                    Question = new Question
                    {
                        Text = "Second Question",
                        Answers = new List<Answer>()
                        {
                            new Answer ()
                            {
                                Text = "First Answer1"
                            },
                            new Answer ()
                            {
                                Text = "Second Answer1"
                            },
                            new Answer ()
                            {
                                Text = "Third Answer1"
                            }
                        }
                    },
                    Number = 2
                }
            }
        },
    };
    public IEnumerable<Interview> GetInterviews = new List<Interview>
    {
        new Interview()
        {
            PersonName = "First Person"
        },
        new Interview()
        {
            PersonName = "Second Person"
        },
    };
}