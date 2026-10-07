# Plan: Mehrere Fragen nacheinander beantworten

## Vorgehen

- Fragen und richtige Antworten werden aus `src/Quiz.Web/questionnaire.json`
  geladen und erscheinen in der dort definierten Reihenfolge. Es gibt kein
  fixes Fragenlimit; die Quizlänge ergibt sich aus der Anzahl der gültigen
  Fragen in dieser Datei.
- Stark typisierte Konfigurationsmodelle und eine Validierung beim
  Anwendungsstart stellen sicher, dass die JSON-Datei mindestens eine Frage
  enthält und jede Frage genau vier eindeutige Optionen sowie genau eine
  richtige Antwort aus diesen Optionen hat. Eine fehlende oder ungültige Datei
  lässt den Start mit einem expliziten Fehler scheitern.
- Ein zuständiger Quiz-Service liest die Fragen, liefert für die Anzeige nur
  Fragetext und Optionen und prüft übermittelte Antworten serverseitig. Die
  korrekte Antwort wird dabei nie an die Anzeige-View ausgegeben.
- Der Controller rendert anfangs nur Frage 1 samt initialem Fortschrittswert
  und Status „Frag 1 von n“ und stellt eine geschützte
  Antwort-Action bereit. Diese prüft Frageindex und Auswahl, liefert bei
  Erfolg die nächste Frage ohne Lösungsschlüssel oder bei Abschluss das
  Prüfergebnis zurück. Ungültige Indizes oder Optionen werden als fehlerhafte
  Anfrage behandelt.
- JavaScript hält den aktuellen Index und Punktestand ausschliesslich im
  Arbeitsspeicher der Seite. Es sendet pro Schritt die ausgewählte Option an
  den Controller, zählt das vom Server zurückgegebene Ergebnis, aktualisiert
  den Fortschrittsbalken und Status „Frag x von n“ und zeigt ohne
  Zwischenrückmeldung die nächste Frage. Nach der letzten Antwort blendet es
  Fortschritt und Fragen aus und zeigt die Überschrift „Dein Ergebnis“ samt
  Punktestand; Neuladen setzt den Ablauf zurück.
- Es werden weder Quizfortschritt noch Antworten serverseitig gespeichert oder
  in Cookies, `localStorage` oder `sessionStorage` abgelegt.

## Betroffene Komponenten

- `src/Quiz.Web/questionnaire.json` für Fragen und richtige Antworten
- `src/Quiz.Web/Quiz.Web.csproj` damit die JSON-Datei in Build- und
  Veröffentlichungsoutput übernommen wird
- `src/Quiz.Web/Program.cs` für Konfigurationsbindung, Validierung und
  Quiz-Service-Registrierung
- `src/Quiz.Web/Models/` für Konfigurations- und Anzeige-/Antwortmodelle
- `src/Quiz.Web/Services/` für das Laden und Prüfen der Fragen
- `src/Quiz.Web/Controllers/HomeController.cs`
- `src/Quiz.Web/Views/Home/Index.cshtml`
- `src/Quiz.Web/wwwroot/js/site.js`
- `src/Quiz.Web/wwwroot/css/site.css`
- `src/Tests/Quiz.Web.Tests/` für Quiz-Service-, Controller- und
  Konfigurationsvalidierungstests sowie die Fortschritts- und Ergebnisanzeige
- `specs/README.md` für den Feature-Status

## Testing

- Service- und Controller-Tests decken richtige und falsche gültige Antworten,
  ungültige Frageindizes und ungültige Optionen ab.
- Konfigurationstests decken fehlende/ungültige oder leere JSON-Datei,
  wechselnde Anzahl von Fragen, falsche Anzahl oder doppelte Antwortoptionen
  sowie eine richtige Antwort ausserhalb der Optionsliste ab.
- `dotnet build src/Quiz.sln` und `dotnet test src/Quiz.sln` müssen erfolgreich
  laufen.
- Die Anwendung mit gültiger `questionnaire.json` starten und im Browser prüfen,
  dass der Start „Frag 1 von n“ mit passendem Fortschrittsbalken zeigt und
  jede automatisch geladene Frage Status und Balken korrekt aktualisiert.
- Nach der letzten Antwort prüfen, dass Fortschrittsanzeige und Fragen
  verschwinden, „Dein Ergebnis“ erscheint und das Ergebnis exakt „x von n
  richtig“ lautet, wobei `n` der Anzahl der Fragen in der Datei entspricht.
- Im Browser prüfen, dass die richtigen Antworten nicht vor der Prüfung
  ausgeliefert werden und Neuladen den Anfangszustand wiederherstellt.
- Die Anwendung zusätzlich mit fehlender oder ungültiger Fragenkonfiguration
  starten und prüfen, dass der Konfigurationsfehler explizit gemeldet wird.
