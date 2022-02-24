using System.Collections.Generic;

namespace OT.VVAExport.Models
{
    public class VVASlide
    {
        public string BlockId { get; set; }
        public string Header { get; set; }
        public string Duration { get; set; }
        public IEnumerable<VVAExercise> Exercises { get; set; }
    }
}