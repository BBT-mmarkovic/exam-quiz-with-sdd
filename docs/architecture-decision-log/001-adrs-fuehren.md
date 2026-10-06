# 1. Architecture Decisions Records (ADRs) führen

Datum: 2026-10-06

## Status

Angenommen

## Kontext

Über die gesamte Entwicklungs- und Betriebsphase eines Softwareprojektes werden wichtige Entscheide mit
weit reichenden Folgen getroffen. Um die Entscheide für alle Stakeholder nachvollziehbar und verfügbar
zu machen, sollen diese als "Architecture Decisions Records" (ADRs) festgehalten werden. ADRs umfassen
nicht nur die Softwarearchitektur eines Projektes, sondern auch weitere technische Aspekte, welche
wichtige Konsequenzen mit sich ziehen, wie z.B. das Hosting, die Entwicklungs- und Build-Umgebung oder
die Datenhaltung.

## Entscheid

Wichtige, technische Entscheide werden als **Architecture Decisions Records** (ADRs) festgehalten.

## Konsequenzen

* Jeder wichtige, technischer Entscheid wird als ADR nachvollziehbar festgehalten.
* Bestehende ADRs werden nicht nachträglich verändert. Bei neuen Erkenntnissen, mit einer technischen
  Änderung wird ein neuer ADR angelegt, welcher auf den alten ADR verweist.
* Alle wichtigen Informationen, die zu einem ADR gehören, müssen statisch im ADR hinterlegt sein. Verweise
  auf externe Quellen (wie Jira, Azure DevOps, Miro, OneNote etc.) sind erlaubt, sofern der ADR auch
  ohne deren Verfügbarkeit nachvollziehbar bleibt.

## Weiterführende Informationen

Weitere Informationen zu ADRs kann man unter anderem auf dem Blog-Post [Documenting Architecture Decisions],
in der Videolektion [Managing Architecture Decisions] von Mark Richards und auf GitHub unter [ADR Tools]
finden.

[Documenting Architecture Decisions]: http://thinkrelevance.com/blog/2011/11/15/documenting-architecture-decisions
[ADR Tools]: https://github.com/npryce/adr-tools
[Managing Architecture Decisions]: https://www.developertoarchitect.com/lessons/lesson141.html
