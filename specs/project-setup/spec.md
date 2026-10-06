# Feature: Projektbasis einrichten

## Ziel

Eine minimale, buildbare Code-Basis für Exam Quiz bereitstellen, auf der
nachfolgende Features entwickelt und getestet werden können.

## User Story

Als Entwickler möchte ich eine Solution mit einer Web-Anwendung und einem
zugehörigen Testprojekt haben, damit ich die Anwendung strukturiert entwickeln
und automatisiert testen kann.

## Abgrenzung

- Inklusiv: .NET-10-Solution, ASP.NET Core MVC-Webprojekt mit Razor Views,
  zugehöriges Testprojekt und Firmenmetadaten.
- Exklusiv: Umsetzung der Frage-Antwort-Funktion, persistente Datenhaltung,
  Anmeldung, Deployment und CI/CD.

## Projektstruktur

```text
src/
├── Quiz.sln
├── Quiz.Web/
└── Tests/
    └── Quiz.Web.Tests/
```

Die Web-Anwendung verwendet C# und ASP.NET Core MVC mit Razor Views. Die
Projektbasis folgt dem angenommenen ADR 2 und den Projektvorgaben.

## Akzeptanzkriterien

- Die Solution `src/Quiz.sln` ist vorhanden und enthält das Webprojekt sowie
  das Testprojekt.
- Das Webprojekt liegt unter `src/Quiz.Web`, verwendet .NET 10 und ist eine
  ASP.NET-Core-MVC-Anwendung mit Razor Views.
- Das Testprojekt liegt unter `src/Tests/Quiz.Web.Tests`, verwendet .NET 10, xUnit und
  referenziert das Webprojekt.
- Beide Projekte bauen erfolgreich über `src/Quiz.sln`.
- Das Testprojekt lässt sich über die Solution mit `dotnet test` ausführen.
- Die Assembly-Firmenangabe beider Projekte lautet exakt `BBT Software AG`.
- Die Projektbasis enthält keine Implementierung der Frage-Antwort-Funktion.

## Offene Fragen

Keine.
