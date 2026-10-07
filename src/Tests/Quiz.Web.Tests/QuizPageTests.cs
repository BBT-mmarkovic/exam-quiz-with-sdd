using Microsoft.AspNetCore.Mvc.Testing;

namespace Quiz.Web.Tests;

public class QuizPageTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public QuizPageTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Initial_page_displays_accessible_progress_before_the_question_and_result_heading()
    {
        var response = await _client.GetAsync("/");
        var html = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        Assert.Contains("Frag 1 von 4", html);
        Assert.Contains("id=\"question-status\"", html);
        Assert.Contains("aria-live=\"polite\"", html);
        Assert.Contains("id=\"question-progress\" value=\"1\" max=\"4\"", html);
        Assert.Contains("max=\"4\"", html);
        Assert.Contains("Dein Ergebnis", html);
        Assert.True(html.IndexOf("<progress", StringComparison.Ordinal) < html.IndexOf("<h1", StringComparison.Ordinal));
    }
}
