namespace NewTest.Context.Entities
{
    public class Question: BaseEntity
    {
        public string Text { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<SurveyQuestionNumber> SurveyQuestionNumbers { get; set; }
    }
}
