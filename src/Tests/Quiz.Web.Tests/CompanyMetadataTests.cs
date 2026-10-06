using System.Reflection;

namespace Quiz.Web.Tests;

public class CompanyMetadataTests
{
    [Theory]
    [InlineData("Quiz.Web")]
    [InlineData("Quiz.Web.Tests")]
    public void Assembly_declares_company_name(string assemblyName)
    {
        var assembly = Assembly.Load(assemblyName);
        var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

        Assert.Equal("BBT Software AG", company?.Company);
    }
}
