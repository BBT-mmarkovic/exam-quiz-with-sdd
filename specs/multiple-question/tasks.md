# Tasks: Mehrere Fragen nacheinander beantworten

1. [ ] Unit-Tests für Konfigurationsvalidierung, Frage-Reihenfolge,
   Antwortoptionen, richtige/falsche Antworten und ungültige Eingaben schreiben.
2. [ ] Stark typisierte Konfigurationsmodelle und Validierung für mindestens
   eine Frage mit genau vier eindeutigen Optionen und einer gültigen richtigen
   Antwort implementieren; ungültige Konfiguration muss den Anwendungsstart
   sichtbar fehlschlagen lassen.
3. [ ] `questionnaire.json` mit den initialen Fragen erstellen und so
   konfigurieren, dass sie im Build- und Veröffentlichungsoutput enthalten ist.
4. [ ] Quiz-Service erstellen, der Fragen in Konfigurationsreihenfolge liefert,
   richtige Antworten serverseitig prüft und niemals Lösungsschlüssel an die
   Anzeige ausgibt.
5. [ ] Controller auf den Quiz-Service umstellen und eine geschützte
   Antwort-Action für gültige Auswahl und Frageindex ergänzen.
6. [ ] Razor-Ansicht auf die initiale Frage mit vier Optionen, deaktiviertem
   Antwortbutton und dynamischen Elementen für weitere Fragen und Ergebnis
   umstellen.
7. [ ] JavaScript für Antwortübermittlung, automatische Weiterschaltung ohne
   Zwischenfeedback und Ergebnisanzeige „x von n richtig“ ergänzen; Fortschritt
   nur im Seitenspeicher halten.
8. [ ] Build, Tests, Browserablauf, Neustartverhalten und Fehler bei fehlender
   oder ungültiger Konfiguration prüfen.
