# Feature: Eine Frage beantworten

## Ziel

Ein Webbenutzer beantwortet eine einzelne Frage und erhält direkt eine Rückmeldung.
Die Benutzeroberfläche verwendet Deutsch (Schweiz, `de-CH`).

## User Story

Als Webbenutzer möchte ich eine Antwort auswählen und bestätigen, um zu erfahren,
ob meine Antwort richtig ist.

## Abgrenzung

- Inklusiv: eine feste Frage, vier Antwortoptionen, genau eine richtige Antwort,
  Auswahl per Radiobutton, Bestätigung mit "Antworten" und Rückmeldung.
- Exklusiv: weitere Fragen, Punktestand, Speicherung von Antworten,
  Benutzerverwaltung und Sessionverwaltung.

## Frage und Oberfläche

Wie lautet die Hauptstadt von Kanada?

- ( ) Toronto
- ( ) Ottawa
- ( ) Montreal
- ( ) Vancouver

Button: **Antworten**

Richtige Antwort: **Ottawa**.

## Akzeptanzkriterien

- Beim ersten Laden erscheinen die Frage, alle vier Optionen und der Button
  "Antworten". Keine Option ist ausgewählt; es gibt keine Rückmeldung oder
  Hervorhebung der richtigen Antwort. Der Button ist deaktiviert.
- Es kann höchstens eine Option gleichzeitig ausgewählt werden.
- Sobald eine Option ausgewählt ist, wird der Button "Antworten" aktiviert.
- Die Auswahl allein zeigt noch keine Rückmeldung.
- Wenn Ottawa ausgewählt und "Antworten" gedrückt wird, wird Ottawa als richtige
  Antwort hervorgehoben und die Rückmeldung lautet exakt "✅ richtig".
- Wenn eine andere Option ausgewählt und "Antworten" gedrückt wird, wird Ottawa
  als richtige Antwort hervorgehoben und die Rückmeldung lautet exakt
  "❌ leider falsch".
- Nach der Bestätigung sind alle Antwortoptionen und der Button deaktiviert.
  Die gewählte Antwort bleibt sichtbar; eine erneute Antwort ist erst nach
  Aktualisierung der Seite möglich.
- Beim Aktualisieren der Seite wird der Anfangszustand wiederhergestellt:
  keine Auswahl, keine Rückmeldung und keine Hervorhebung.
- Antworten werden weder dauerhaft noch in Cookies, Browser-Speicher oder einer
  serverseitigen Session gespeichert.
- Alle sichtbaren Bedienelemente und Meldungen verwenden Deutsch (Schweiz).

## Offene Fragen

Keine.
