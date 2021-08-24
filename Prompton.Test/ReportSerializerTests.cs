using Prompton.Steps.StepResults;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test;

public class ReportSerializerTests
{
    ReportSerializer serializer;
    private static string nl = Environment.NewLine;
    private const string testName = "Test Main";
    private static DateOnly testDate = new DateOnly(2020, 02, 22);
    private static TimeOnly testTime = new TimeOnly(14, 10, 7);
    private static TimeSpan testDuration = new TimeSpan(1, 3, 43);
    private MainResult main;

    public ReportSerializerTests()
    {
        serializer = new ReportSerializer();
        main = GetMainResult();
    }

    public static MainResult GetMainResult() => new MainResult
    {
        Name = testName,
        StartDate = testDate,
        StartTime = testTime,
        Duration = testDuration,
        Result = new List<List<StepResult>>()
    };

    public static string GetMainExpectedString(MainResult main) => ""
        + $"!{typeof(MainResult).Name}{nl}"
        + $"{nameof(main.Name)}: {testName}{nl}"
        + $"{nameof(main.StartDate)}: 2020-02-22{nl}"
        + $"{nameof(main.StartTime)}: 14:10:07{nl}"
        + $"{nameof(main.Duration)}: 01:03:43{nl}"
        + $"{nameof(main.Result)}:";

    [Fact]
    public void MainResultSerializes()
    {
        var main = GetMainResult();
        var expected = GetMainExpectedString(main);
        expected += $" []{nl}";

        var result = serializer.Serialize(main);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChoiceResultSerializes()
    {
        var testPrompt2 = "Are you glad you took the quiz?";
        var testChoiceString2 = "No";
        var choice2 = new ChoiceResult { Prompt = testPrompt2, Choice = testChoiceString2 };
        var testPrompt = "Would you like to take the quiz?";
        var testChoiceString = "Yes";
        var choice = new ChoiceResult { Prompt = testPrompt, Choice = testChoiceString, Result = choice2 };

        var main = GetMainResult();
        var innerList = new List<StepResult> { choice };
        main.Result.Add(innerList);

        var expected = GetMainExpectedString(main) + $"{nl}";
        expected += $"- - !{typeof(ChoiceResult).Name}{nl}";
        expected += $"    {nameof(choice.Prompt)}: {testPrompt}{nl}";
        expected += $"    {nameof(choice.Choice)}: {testChoiceString}{nl}";
        expected += $"    {nameof(choice.Result)}: !{typeof(ChoiceResult).Name}{nl}";
        expected += $"      {nameof(choice2.Prompt)}: {testPrompt2}{nl}";
        expected += $"      {nameof(choice2.Choice)}: {testChoiceString2}{nl}";
        expected += $"      {nameof(choice.Result)}: {nl}";

        var result = serializer.Serialize(main);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void SeriesResultSerializes()
    {
        var testPrompt2 = "Test Series 2";
        var series2 = new SeriesResult { Prompt = testPrompt2, Result = new List<List<StepResult>>() };
        var testPrompt = "Test Series";
        var series = new SeriesResult { Prompt = testPrompt, Result = new List<List<StepResult>>() };

        var main = GetMainResult();
        var innerList = new List<StepResult> { series2, series2 };
        series.Result.Add(innerList);
        series.Result.Add(innerList);
        var innerList2 = new List<StepResult> { series };
        main.Result.Add(innerList2);

        var expected = GetMainExpectedString(main) + nl;
        expected += $"- - !{typeof(SeriesResult).Name}{nl}";
        expected += $"    {nameof(series.Prompt)}: {testPrompt}{nl}";
        expected += $"    {nameof(series.Result)}:{nl}";
        expected += $"    - - !{typeof(SeriesResult).Name}{nl}";
        expected += $"        {nameof(series2.Prompt)}: {testPrompt2}{nl}";
        expected += $"        {nameof(series2.Result)}: []{nl}";
        expected += $"      - !{typeof(SeriesResult).Name}{nl}";
        expected += $"        {nameof(series2.Prompt)}: {testPrompt2}{nl}";
        expected += $"        {nameof(series2.Result)}: []{nl}";
        expected += $"    - - !{typeof(SeriesResult).Name}{nl}";
        expected += $"        {nameof(series2.Prompt)}: {testPrompt2}{nl}";
        expected += $"        {nameof(series2.Result)}: []{nl}";
        expected += $"      - !{typeof(SeriesResult).Name}{nl}";
        expected += $"        {nameof(series2.Prompt)}: {testPrompt2}{nl}";
        expected += $"        {nameof(series2.Result)}: []{nl}";

        var result = serializer.Serialize(main);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TextResultSerializes()
    {
        var testPrompt = "Please input your name";
        var testResult = "Daniel";
        var text = new TextResult { Prompt = testPrompt, Result = testResult };

        var main = GetMainResult();
        var innerList = new List<StepResult> { text };
        main.Result.Add(innerList);

        var expected = GetMainExpectedString(main) + nl;
        expected += $"- - !{typeof(TextResult).Name}{nl}";
        expected += $"    {nameof(text.Prompt)}: {testPrompt}{nl}";
        expected += $"    {nameof(text.Result)}: {testResult}{nl}";

        var result = serializer.Serialize(main);

        Assert.Equal(expected, result);
    }
}
