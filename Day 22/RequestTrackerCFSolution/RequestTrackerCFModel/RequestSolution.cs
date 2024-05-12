using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFModel
{
    public class RequestSolution
    {
        [Key]
        public int SolutionId { get; set; }
        public int RequestId { get; set; }
        public Request RequestRaised { get; set; }
        public string SolutionDescription { get; set; }
        public int SolvedBy { get; set; }
        public Employee SolvedByEmployee { get; set; }
        public DateTime SolvedDate { get; set; }
        public bool IsSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }
        public ICollection<SolutionFeedback> Feedbacks { get; set; }
        public override string ToString()
        {
            return $"Solution ID: {SolutionId}\n" +
                $"Request ID: {RequestId}\n" +
                $"Solution Description: {SolutionDescription}\n" +
                $"Solved By Employee ID: {SolvedBy}\n" +
                $"Solved Date: {SolvedDate}\n" +
                $"Is Solved: {IsSolved}\n" +
                $"Request Raiser Comment: {RequestRaiserComment ?? "No Comments Yet...."}\n";
        }
    }
}
