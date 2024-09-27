namespace NewTest.Context.Entities
{
    public class Result: BaseEntity
    {
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public int InterviewId { get; set; }
        public virtual Interview Interview { get; set; }
    }
}
