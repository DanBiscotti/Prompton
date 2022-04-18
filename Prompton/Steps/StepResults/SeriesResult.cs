using System.Collections.Generic;

namespace Prompton.Steps.StepResults;

public class SeriesResult : StepResult
{
    public string Prompt { get; set; }
    public List<List<StepResult>> Result { get; set; }
}
