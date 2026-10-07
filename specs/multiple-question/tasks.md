# Tasks: Mehrere Fragen nacheinander beantworten

1. [ ] UI-Prüfung für Fortschrittsstatus, Balkenaktualisierung und
   Ergebnisüberschrift ergänzen.
2. [x] Unit-Tests für Konfigurationsvalidierung, Frage-Reihenfolge,
   Antwortoptionen, richtige/falsche Antworten und ungültige Eingaben schreiben.
3. [x] Stark typisierte Konfigurationsmodelle und Validierung für mindestens
   eine Frage mit genau vier eindeutigen Optionen und einer gültigen richtigen
   Antwort implementieren; ungültige Konfiguration muss den Anwendungsstart
   sichtbar fehlschlagen lassen.
4. [x] `questionnaire.json` mit den initialen Fragen erstellen und so
   konfigurieren, dass sie im Build- und Veröffentlichungsoutput enthalten ist.
5. [x] Quiz-Service erstellen, der Fragen in Konfigurationsreihenfolge liefert,
   richtige Antworten serverseitig prüft und niemals Lösungsschlüssel an die
   Anzeige ausgibt.
6. [x] Controller auf den Quiz-Service umstellen und eine geschützte
   Antwort-Action für gültige Auswahl und Frageindex ergänzen.
7. [ ] Razor-Ansicht um barrierefreien Fortschrittsbalken mit dem Status „Frag
   x von n“ vor dem Fragetext und Ergebnisüberschrift „Dein Ergebnis“ ergänzen.
8. [ ] JavaScript/CSS für Fortschrittsaktualisierung je Frage sowie das
   Ausblenden der Fortschrittsanzeige auf der Ergebnisseite ergänzen.
9. [ ] Build, Tests, Browserablauf, Neustartverhalten und Fehler bei fehlender
   oder ungültiger Konfiguration prüfen.
