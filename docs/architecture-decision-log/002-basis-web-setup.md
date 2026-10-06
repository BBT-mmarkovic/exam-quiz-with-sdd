# 2. Basis Web-Setup

Datum: 2026-10-06

## Status

Angenommen

## Kontext

Zur Beantwortung der Fragen benötigt es eine grafische Benutzeroberfläche.
Die Anwendung sollte ohne Installation genutzt werden können.

## Entscheid

Die Anwendung soll als Web-Applikation bereitgestellt werden.
Die Web-Anwendung soll als ASP.NET MVC Razor-Page in .NET10 aufgesetzt
werden mit C# als Programmiersprache.

## Noch offen

Nachfolgende Themen sind nicht Bestandteil dieses ADRs und werden später in Folge-ADRs geklärt:

* Login / Anmeldung
* Speicherung der Daten
* Betriebsplattform der Anwendung

## Konsequenzen

* Die Anwendung wird aktuell nur auf der lokalen Entwicklungsumgebung ausgeführt
* Es findet noch kein Deployment auf eine andere Umgebung statt
