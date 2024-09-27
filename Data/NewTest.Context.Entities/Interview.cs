namespace NewTest.Context.Entities
{
    public class Interview: BaseEntity
    {
        public string PersonName { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
