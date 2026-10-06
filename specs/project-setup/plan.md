# Plan: Projektbasis einrichten

## Vorgehen

1. Mit den .NET-10-SDK-Vorlagen `src/Quiz.Web` als ASP.NET Core MVC-Webprojekt
   und `src/Tests/Quiz.Web.Tests` als xUnit-Testprojekt erstellen.
2. `src/Quiz.sln` anlegen und beide Projekte hinzufügen; das Testprojekt erhält
   einen Projektverweis auf `Quiz.Web`.
3. `src/Directory.Build.props` anlegen, um die Assembly-Firmenangabe
   `BBT Software AG` zentral für beide Projekte festzulegen.
4. Vorlageninhalte auf die für eine buildbare MVC-Anwendung und ein ausführbares
   Testprojekt nötigen Bestandteile beschränken. Noch keine Frage-Antwort-
   Funktion implementieren.

## Betroffene Komponenten

- `src/Quiz.sln`
- `src/Directory.Build.props`
- `src/Quiz.Web/`
- `src/Tests/Quiz.Web.Tests/`

## Testing

- `dotnet build src/Quiz.sln` muss beide Projekte erfolgreich bauen.
- `dotnet test src/Quiz.sln` muss erfolgreich laufen.
- `dotnet run --project src/Quiz.Web` muss die Web-Anwendung starten können.
- Die Firmenmetadaten beider erzeugten Assemblies müssen exakt `BBT Software AG`
  lauten.
