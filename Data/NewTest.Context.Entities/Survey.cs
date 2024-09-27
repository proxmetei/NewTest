namespace NewTest.Context.Entities
{
    public class Survey: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SurveyQuestionNumber> SurveyQuestionNumbers { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
