# Spec-driven workflow

Copy `_template` to `specs/<feature-name>/` for each small feature.

## Feature-Übersicht

| Feature | Status | Abhängigkeiten |
| --- | --- | --- |
| `project-setup` | Abgeschlossen | — |
| `single-question` | Abgeschlossen | `project-setup` |
| `multiple-question` | Tasks bereit zur Abstimmung | `single-question` |

1. Specify: fill in `spec.md` and resolve open questions.
2. Plan: fill in `plan.md` and agree on the approach before coding.
3. Break down: fill in the checklist in `tasks.md`.
4. Implement: complete the tasks and keep code, tests, and specification aligned.
5. Verify: check acceptance criteria, run relevant checks, review, and commit.
