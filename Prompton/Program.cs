using Prompton.Models;
using Prompton;
using System.Collections.Generic;


// Deserialize & Validate
var main = new Main
{
    Id = "test-main",
    Name = "Test Routine",
    Prompt = "Welcome to the Test Routine"
};
var series = new Series
{
    Id = "test-series",
    Name = "Test Series",
    Prompt = "You are now in a series"
};
var choice = new Choice
{
    Id = "test-choice",
    Name = "Test Choice",
    Prompt = "Make a choice:",
    Choices = new() { "choice 1", "choice 2" }
};
main.Steps = new List<Step> { choice };
var dict = new Dictionary<string, Step>()
{
    { main.Id, main },
    { series.Id, series },
    { choice.Id, choice }
};


var deserializer = new MockDeserializer(dict, main);


App app = new App(deserializer);
app.Start();
