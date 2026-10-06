# Feature: Mehrere Fragen nacheinander beantworten

## Ziel

Ein Webbenutzer beantwortet vier Fragen nacheinander und erhält am Schluss
seinen Punktestand. Die Benutzeroberfläche verwendet Deutsch (Schweiz, `de-CH`).

## User Story

Als Webbenutzer möchte ich mehrere Fragen nacheinander beantworten, damit ich
mein Wissen prüfen und anschliessend mein Ergebnis sehen kann.

## Abgrenzung

- Inklusiv: vier feste Fragen mit je vier Antwortoptionen, serverseitige Prüfung,
  Laden der Fragen aus einer Konfigurationsdatei, automatischer Wechsel zur
  nächsten Frage ohne Zwischenrückmeldung und eine Ergebnisübersicht mit
  Punktestand.
- Exklusiv: zufällige Reihenfolge, weitere Fragen, Benutzerverwaltung,
  Bearbeiten oder Verwalten der Fragen zur Laufzeit, Datenbank, dauerhafte
  Speicherung, Fortsetzen nach Neuladen und serverseitige Session.

## Fragenkonfiguration

- Die vier Fragen, Antwortoptionen und jeweils richtige Antwort werden aus einer
  Konfigurationsdatei geladen und nicht in Controller-, View- oder
  JavaScript-Code hinterlegt.
- Die Konfiguration wird serverseitig eingelesen; richtige Antworten werden
  nicht an den Browser ausgeliefert, bevor eine Antwort geprüft wird.
- Die Konfigurationsdatei enthält alle vier Fragen in der festgelegten
  Reihenfolge. Jede Frage hat genau vier eindeutige Optionen und genau eine
  richtige Antwort, die einer dieser Optionen entspricht.

## Fragen

Die Konfigurationsdatei enthält folgende Inhalte:

### Frage 1

Wie lautet die Hauptstadt von Kanada?

- Toronto
- Ottawa
- Montreal
- Vancouver

Richtige Antwort: **Ottawa**.

### Frage 2

Welches der folgenden Länder oder Gebiete ist flächenmässig am grössten?

- Argentinien
- Kasachstan
- Demokratische Republik Kongo
- Grönland (Dänemark)

Richtige Antwort: **Kasachstan**.

### Frage 3

Welcher dieser Flüsse ist am längsten?

- Gelber Fluss
- Yangtze
- Kongo
- Amazonas

Richtige Antwort: **Amazonas**.

### Frage 4

Welche Teilchen bewegen sich bei einem Blitz hauptsächlich?

- Elektronen
- Protonen
- Photonen
- Neutronen

Richtige Antwort: **Elektronen**.

## Akzeptanzkriterien

- Zu Beginn wird nur Frage 1 mit ihren vier Optionen angezeigt. Keine Antwort
  ist ausgewählt; es gibt keine Rückmeldung und der Button „Antworten“ ist
  deaktiviert.
- Zu jedem Zeitpunkt wird höchstens eine Frage mit genau ihren vier Optionen
  angezeigt.
- Pro Frage kann höchstens eine Option ausgewählt werden. Der Button
  „Antworten“ wird erst aktiviert, wenn eine Option ausgewählt ist.
- Die Auswahl allein zeigt keine Rückmeldung.
- Beim Bestätigen wird die Antwort serverseitig geprüft. Eine richtige Antwort
  zählt einen Punkt; eine falsche Antwort zählt null Punkte.
- Nach der Prüfung erscheint ohne Zwischenrückmeldung automatisch die nächste
  Frage. Während der Anfrage kann keine weitere Antwort abgegeben werden.
- Fragen erscheinen in der festgelegten Reihenfolge 1 bis 4.
- Nach der Antwort auf Frage 4 wird keine weitere Frage angezeigt. Stattdessen
  erscheint der Punktestand exakt im Format „x von 4 richtig“, wobei `x` die
  Anzahl richtiger Antworten ist.
- Die richtige Antwort wird nicht vor der Prüfung im HTML oder JavaScript
  offengelegt.
- Die Frageninhalte und richtigen Antworten werden zur Laufzeit aus der
  Konfigurationsdatei gelesen, nicht aus fest im Anwendungscode hinterlegten
  Werten.
- Fehlt die Konfigurationsdatei oder ist sie ungültig, startet die Anwendung
  nicht mit stillschweigend ersetzten oder unvollständigen Fragen, sondern
  meldet den Konfigurationsfehler explizit.
- Der aktuelle Quizfortschritt und Punktestand werden nur flüchtig im
  Browser-Arbeitsspeicher gehalten. Sie werden weder dauerhaft noch in Cookies,
  Browser-Speicher oder einer serverseitigen Session gespeichert.
- Nach Aktualisierung der Seite beginnt das Quiz wieder bei Frage 1 mit
  Punktestand null.
- Alle sichtbaren Bedienelemente und Meldungen verwenden Deutsch (Schweiz).

## Offene Fragen

Keine.
