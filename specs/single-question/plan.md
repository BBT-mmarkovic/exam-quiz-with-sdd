# Plan: Eine Frage beantworten

## Vorgehen

- Die Startansicht wird zur einzelnen, fest definierten Frage mit vier
  Radiobuttons und einem anfangs deaktivierten Button „Antworten“.
- Die Auswahl, Prüfung und Rückmeldung werden ausschliesslich im Browser mit
  JavaScript umgesetzt. Es gibt keine Formularübermittlung, Speicherung oder
  Server-Session; ein Neuladen stellt den Anfangszustand wieder her.
- Nach der Bestätigung werden alle Optionen und der Button deaktiviert. Ottawa
  wird unabhängig von der Auswahl als richtige Antwort hervorgehoben und die
  Rückmeldung zeigt exakt den in der Spezifikation genannten Text.
- Das gemeinsame Layout wird auf Deutsch (Schweiz, `de-CH`) gesetzt, damit auch
  die sichtbaren Navigationselemente und der Dokumentkontext zur Spezifikation
  passen.

## Betroffene Komponenten

- `src/Quiz.Web/Views/Home/Index.cshtml`
- `src/Quiz.Web/Views/Shared/_Layout.cshtml`
- `src/Quiz.Web/wwwroot/js/site.js`
- `src/Quiz.Web/wwwroot/css/site.css`

## Testing

- `dotnet build src/Quiz.sln` und `dotnet test src/Quiz.sln` müssen erfolgreich
  laufen.
- Im Browser den Anfangszustand prüfen: vier Optionen, keine Auswahl oder
  Rückmeldung, deaktivierter Button.
- Auswahl prüfen: höchstens eine Option ist ausgewählt, der Button wird
  aktiviert und vor der Bestätigung erscheint keine Rückmeldung.
- Beide Ergebnisse prüfen: Ottawa ergibt exakt „✅ richtig“; jede andere Option
  ergibt exakt „❌ leider falsch“. Ottawa ist jeweils hervorgehoben und alle
  Bedienelemente sind danach deaktiviert.
- Seite neu laden und prüfen, dass Auswahl, Rückmeldung und Hervorhebung
  zurückgesetzt sind.
- Prüfen, dass keine Antwort in Cookies, Browser-Speicher oder einer
  serverseitigen Session abgelegt wird und die sichtbare Oberfläche `de-CH`
  verwendet.
