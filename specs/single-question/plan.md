# Plan: Eine Frage beantworten

## Vorgehen

- Die Startansicht wird zur einzelnen, fest definierten Frage mit vier
  Radiobuttons und einem anfangs deaktivierten Button „Antworten“.
- Die ausgewählte Option wird per asynchroner POST-Anfrage an eine MVC-Action
  gesendet. Nur der Controller kennt und prüft die richtige Antwort; sie wird
  nicht im HTML oder im JavaScript hinterlegt.
- Die Action verarbeitet die Auswahl stateless und liefert das Prüfergebnis
  zurück. Es werden keine Antworten gespeichert und keine serverseitige Session
  oder Antwortcookies verwendet. Das für den CSRF-Schutz nötige Antiforgery-
  Cookie enthält keinen Antwortzustand.
- JavaScript zeigt das Ergebnis an, hebt Ottawa als richtige Antwort hervor und
  deaktiviert nach der Antwort alle Optionen und den Button. Die Meldung lautet
  exakt wie in der Spezifikation. Ein Neuladen führt einen neuen GET-Aufruf aus
  und stellt den Anfangszustand wieder her.
- Das gemeinsame Layout wird auf Deutsch (Schweiz, `de-CH`) gesetzt, damit auch
  die sichtbaren Navigationselemente und der Dokumentkontext zur Spezifikation
  passen.

## Betroffene Komponenten

- `src/Quiz.Web/Views/Home/Index.cshtml`
- `src/Quiz.Web/Views/Shared/_Layout.cshtml`
- `src/Quiz.Web/Controllers/HomeController.cs`
- `src/Quiz.Web/wwwroot/js/site.js`
- `src/Quiz.Web/wwwroot/css/site.css`
- `src/Tests/Quiz.Web.Tests/` für Tests der serverseitigen Antwortprüfung

## Testing

- `dotnet build src/Quiz.sln` und `dotnet test src/Quiz.sln` müssen erfolgreich
  laufen.
- Controller-Tests prüfen, dass Ottawa als richtig, jede andere gültige Option
  als falsch und eine ungültige Auswahl als fehlerhafte Anfrage behandelt wird.
- Im Browser den Anfangszustand prüfen: vier Optionen, keine Auswahl oder
  Rückmeldung, deaktivierter Button.
- Auswahl prüfen: höchstens eine Option ist ausgewählt, der Button wird
  aktiviert und vor der Bestätigung erscheint keine Rückmeldung.
- Beide Ergebnisse prüfen: Ottawa ergibt serverseitig bestätigt exakt
  „✅ richtig“; jede andere Option ergibt exakt „❌ leider falsch“. Ottawa ist
  jeweils hervorgehoben und alle Bedienelemente sind danach deaktiviert.
- Seite neu laden und prüfen, dass Auswahl, Rückmeldung und Hervorhebung
  zurückgesetzt sind.
- Prüfen, dass im initialen HTML und JavaScript kein Antwortschlüssel oder
  Ergebniszustand enthalten ist; der Controller liefert die richtige Antwort
  erst mit dem Prüfergebnis zurück. Keine Antwort wird in Cookies,
  Browser-Speicher oder einer serverseitigen Session abgelegt. Die sichtbare
  Oberfläche verwendet `de-CH`.
