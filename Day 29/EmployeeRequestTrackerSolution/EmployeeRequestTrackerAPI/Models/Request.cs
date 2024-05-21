using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "Open";
        public int RequestRaisedBy { get; set; }
        [ForeignKey("RequestRaisedBy")]
        public Employee RaisedByEmployee { get; set; }
        public int? RequestClosedBy { get; set; }
        [ForeignKey("RequestClosedBy")]
        public Employee? RequestClosedByEmployee { get; set; }

        //public override string ToString()
        //{
        //    return $"Request Number: {RequestNumber}\n" +
        //        $"Request Message: {RequestMessage}\n" +
        //        $"Request Date: {RequestDate}\n" +
        //        $"Closed Date: {ClosedDate}\n" +
        //        $"Request Status: {RequestStatus}\n" +
        //        $"Raised By Employee Id: {RequestRaisedBy}\n" +
        //        $"Closed By Employee Id: {RequestClosedBy}";
        //}
    }
}
