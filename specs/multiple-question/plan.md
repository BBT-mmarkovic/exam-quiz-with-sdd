# Plan: Mehrere Fragen nacheinander beantworten

## Vorgehen

- Fragen und richtige Antworten werden in einem Abschnitt `Questions` in
  `src/Quiz.Web/appsettings.json` gepflegt. Der Abschnitt enthält die vier
  Fragen in der gewünschten Reihenfolge.
- Stark typisierte Konfigurationsmodelle und eine Validierung beim
  Anwendungsstart stellen sicher, dass genau vier Fragen mit je vier
  eindeutigen Optionen und genau einer gültigen richtigen Antwort geladen
  werden. Fehlende oder ungültige Konfiguration lässt den Start mit einem
  expliziten Fehler scheitern.
- Ein zuständiger Quiz-Service liest die Fragen, liefert für die Anzeige nur
  Fragetext und Optionen und prüft übermittelte Antworten serverseitig. Die
  korrekte Antwort wird dabei nie an die Anzeige-View ausgegeben.
- Der Controller rendert anfangs nur Frage 1 und stellt eine geschützte
  Antwort-Action bereit. Diese prüft Frageindex und Auswahl, liefert bei
  Erfolg die nächste Frage ohne Lösungsschlüssel oder bei Abschluss das
  Prüfergebnis zurück. Ungültige Indizes oder Optionen werden als fehlerhafte
  Anfrage behandelt.
- JavaScript hält den aktuellen Index und Punktestand ausschliesslich im
  Arbeitsspeicher der Seite. Es sendet pro Schritt die ausgewählte Option an
  den Controller, zählt das vom Server zurückgegebene Ergebnis und zeigt ohne
  Zwischenrückmeldung die nächste Frage. Nach der vierten Antwort zeigt es den
  Punktestand; Neuladen setzt den Ablauf zurück.
- Es werden weder Quizfortschritt noch Antworten serverseitig gespeichert oder
  in Cookies, `localStorage` oder `sessionStorage` abgelegt.

## Betroffene Komponenten

- `src/Quiz.Web/appsettings.json` für Fragen und richtige Antworten
- `src/Quiz.Web/Program.cs` für Konfigurationsbindung, Validierung und
  Quiz-Service-Registrierung
- `src/Quiz.Web/Models/` für Konfigurations- und Anzeige-/Antwortmodelle
- `src/Quiz.Web/Services/` für das Laden und Prüfen der Fragen
- `src/Quiz.Web/Controllers/HomeController.cs`
- `src/Quiz.Web/Views/Home/Index.cshtml`
- `src/Quiz.Web/wwwroot/js/site.js`
- `src/Tests/Quiz.Web.Tests/` für Quiz-Service-, Controller- und
  Konfigurationsvalidierungstests
- `specs/README.md` für den Feature-Status

## Testing

- Service- und Controller-Tests decken alle vier richtigen Antworten,
  falsche gültige Antworten, ungültige Frageindizes und ungültige Optionen ab.
- Konfigurationstests decken fehlende/ungültige Anzahl Fragen, falsche Anzahl
  oder doppelte Antwortoptionen sowie eine richtige Antwort ausserhalb der
  Optionsliste ab.
- `dotnet build src/Quiz.sln` und `dotnet test src/Quiz.sln` müssen erfolgreich
  laufen.
- Die Anwendung mit gültiger Konfiguration starten und im Browser prüfen, dass
  nur eine Frage gleichzeitig erscheint, Auswahl den Antwortbutton aktiviert,
  jede Antwort automatisch zur nächsten Frage führt und das Endergebnis exakt
  „x von 4 richtig“ lautet.
- Im Browser prüfen, dass die richtigen Antworten nicht vor der Prüfung
  ausgeliefert werden und Neuladen den Anfangszustand wiederherstellt.
- Die Anwendung zusätzlich mit fehlender oder ungültiger Fragenkonfiguration
  starten und prüfen, dass der Konfigurationsfehler explizit gemeldet wird.
