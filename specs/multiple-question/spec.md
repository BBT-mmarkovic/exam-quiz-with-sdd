# Feature: Mehrere Fragen nacheinander beantworten

## Ziel

Ein Webbenutzer beantwortet nacheinander alle konfigurierten Fragen und erhält
am Schluss seinen Punktestand. Die Benutzeroberfläche verwendet Deutsch
(Schweiz, `de-CH`).

## User Story

Als Webbenutzer möchte ich mehrere Fragen nacheinander beantworten, damit ich
mein Wissen prüfen und anschliessend mein Ergebnis sehen kann.

## Abgrenzung

- Inklusiv: eine konfigurierbare Anzahl Fragen mit je vier Antwortoptionen,
  serverseitige Prüfung, Laden der Fragen aus einer Konfigurationsdatei,
  automatischer Wechsel zur nächsten Frage ohne Zwischenrückmeldung und eine
  Ergebnisübersicht mit Punktestand.
- Exklusiv: zufällige Reihenfolge, Benutzerverwaltung,
  Bearbeiten oder Verwalten der Fragen zur Laufzeit, Datenbank, dauerhafte
  Speicherung, Fortsetzen nach Neuladen und serverseitige Session.

## Fragenkonfiguration

- Die Fragen, Antwortoptionen und jeweils richtige Antwort werden aus einer
  Konfigurationsdatei geladen und nicht in Controller-, View- oder
  JavaScript-Code hinterlegt. Die Anzahl der Fragen wird durch die Einträge in
  dieser Datei bestimmt; es gibt kein fixes Fragenlimit.
- Die Konfiguration wird serverseitig eingelesen; richtige Antworten werden
  nicht an den Browser ausgeliefert, bevor eine Antwort geprüft wird.
- Die Konfigurationsdatei enthält mindestens eine Frage in der festgelegten
  Reihenfolge. Jede Frage hat genau vier eindeutige Optionen und genau eine
  richtige Antwort, die einer dieser Optionen entspricht.

## Fragen

Die initiale Konfigurationsdatei enthält folgende vier Fragen. Weitere Fragen
können durch Konfiguration ergänzt werden, ohne die Anwendungscode-Logik zu
ändern.

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
- Vor dem Fragetext werden ein Fortschrittsbalken und der Status „Frag x von y“
  angezeigt. `x` ist die Nummer der aktuell angezeigten Frage und `y` die
  Gesamtzahl der konfigurierten Fragen; der Fortschrittsbalken zeigt den
  entsprechenden Quizfortschritt.
- Zu jedem Zeitpunkt wird höchstens eine Frage mit genau ihren vier Optionen
  angezeigt.
- Pro Frage kann höchstens eine Option ausgewählt werden. Der Button
  „Antworten“ wird erst aktiviert, wenn eine Option ausgewählt ist.
- Die Auswahl allein zeigt keine Rückmeldung.
- Beim Bestätigen wird die Antwort serverseitig geprüft. Eine richtige Antwort
  zählt einen Punkt; eine falsche Antwort zählt null Punkte.
- Nach der Prüfung erscheint ohne Zwischenrückmeldung automatisch die nächste
  Frage. Während der Anfrage kann keine weitere Antwort abgegeben werden.
- Fragen erscheinen in der Reihenfolge, in der sie in der Konfigurationsdatei
  definiert sind.
- Nach der Antwort auf die letzte konfigurierte Frage wird keine weitere Frage
  angezeigt. Stattdessen erscheint die Überschrift „Dein Ergebnis“ und der
  Punktestand exakt im Format „x von n richtig“, wobei `x` die Anzahl richtiger
  Antworten und `n` die Gesamtzahl der konfigurierten Fragen ist. Der
  Fortschrittsbalken und der Fragestatus sind auf der Ergebnisseite nicht
  sichtbar.
- Die richtige Antwort wird nicht vor der Prüfung im HTML oder JavaScript
  offengelegt.
- Die Frageninhalte und richtigen Antworten werden zur Laufzeit aus der
  Konfigurationsdatei gelesen, nicht aus fest im Anwendungscode hinterlegten
  Werten.
- Die Anzahl der Fragen ist nicht im Anwendungscode limitiert und entspricht
  der Anzahl der gültigen Fragen in der Konfigurationsdatei.
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
