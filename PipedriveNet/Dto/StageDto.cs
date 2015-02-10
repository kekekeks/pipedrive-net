using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class StageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PipelineId { get; set; }
        public string PipelineName { get; set; }
    }
}
