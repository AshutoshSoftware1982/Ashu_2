namespace WebApplication1.Model
{
    public class StyleCalendarModel
    {
        public DateTime Calendar { get; set; }
        public string TaskCode { get; set; }
        public string Seq { get; set; }
        public string Duration { get; set; }
        public DateTime EstimateComDate { get; set; }
        public DateTime EarliestProjectedDate { get; set; }
        public string Comment { get; set; }
        public DateTime ActualComDate { get; set; }
        public string CompleteBy { get; set; }
        public DateTime TaskDueDate { get; set; }
        public string ResponsiblePerson { get; set; }

    }
}
