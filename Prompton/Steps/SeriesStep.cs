﻿using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class SeriesStep : Step
{
    [YamlMember(Alias = "steps")]
    public List<Step> Steps { get; set; }
    [YamlMember(Alias = "repeats")]
    public int  Repeats { get; set; } = 1;
}