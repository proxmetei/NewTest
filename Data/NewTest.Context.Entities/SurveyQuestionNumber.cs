namespace NewTest.Context.Entities
{
    public class SurveyQuestionNumber
    {
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int Number { get; set; }
    }
}
