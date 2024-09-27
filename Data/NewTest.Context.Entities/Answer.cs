namespace NewTest.Context.Entities
{
    public class Answer: BaseEntity
    {
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
