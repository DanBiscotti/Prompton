using System.Collections.Generic;

namespace Prompton.Steps;

public class Choice : Step
{
    public Dictionary<string, Step> Choices;
}
