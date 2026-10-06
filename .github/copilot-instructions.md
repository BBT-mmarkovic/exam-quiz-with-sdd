# Copilot Instructions

## Project Overview

Exam Quiz is an exam-preparation application built using Spec Driven Development.
Use C# and ASP.NET Core MVC with Razor views; avoid legacy ASP.NET MVC 5.

## Spec-first workflow

- Define feature requirements and testable acceptance criteria in `specs/` before implementation.
- Ask about unclear requirements; do not invent product behavior.
- Agree on an implementation plan before coding. Keep specifications and behavior aligned.
- Review the relevant ADRs in `docs/architecture-decision-log/` and follow their accepted decisions.
- Record important technical decisions in a new ADR; do not modify existing ADRs to reflect later decisions.
- In German specifications and UI text, use proper umlauts (ä, ö, ü), not ae, oe, ue.
  Follow Swiss German spelling: use ss instead of ß.

## Development guidelines

- Keep controllers thin, use dedicated view models, and keep business logic out of views.
- Prefer simple solutions and standard ASP.NET Core patterns over unnecessary abstractions.
- Use server-side validation, accessible markup, and standard security protections.
- Never commit secrets; use development user secrets or environment variables.
- Test acceptance criteria and important edge cases. Build and run relevant tests after code changes.
- Report checks accurately, including anything that could not be run.

## Code Style

- Use consistent naming conventions
- Prefer specific patterns over others
- Follow established project conventions

## Testing

- Use automated tests to verify feature behavior and edge cases.
- Write tests before implementation when following the spec-first workflow.
- Ensure tests are isolated, repeatable, and cover both typical and edge cases.
- Use meaningful test names that clearly describe the scenario being tested.
