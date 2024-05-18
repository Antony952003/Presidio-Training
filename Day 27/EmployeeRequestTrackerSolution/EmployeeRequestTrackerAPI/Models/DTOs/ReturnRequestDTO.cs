namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class ReturnRequestDTO
    {
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; }
        public string RequestStatus { get; set; }
        public int RequestRaisedBy { get; set; }
        public int? RequestClosedBy { get; set; }
    }
}
