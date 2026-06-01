# Requirements Document

## Introduction

The application SHALL provide a user-facing interface language setting that controls the language of the launcher UI.

## Glossary

- **UI language**: The language used for launcher window titles, menu labels, button labels, tab labels, and message text.
- **Restart-required change**: A setting change that takes effect after the application restarts.

## Requirements

### Requirement 1: Language selection

**User Story:** AS a user, I want to choose the application UI language, so that I can use the launcher in a preferred language.

#### Acceptance Criteria

1. WHEN the user opens the settings window, THE application SHALL display a UI language selector.
2. THE UI language selector SHALL offer English and Simplified Chinese.
3. WHEN the application starts, THE application SHALL load the previously saved UI language.

### Requirement 2: Language persistence

**User Story:** AS a user, I want the application to remember my UI language choice, so that I do not need to configure it again after restart.

#### Acceptance Criteria

1. WHEN the user saves settings, THE application SHALL persist the selected UI language in local settings.
2. WHILE a saved UI language exists, THE application SHALL use the saved value on the next launch.
3. IF the saved UI language value is unsupported, THE application SHALL use English.

### Requirement 3: Language application scope

**User Story:** AS a user, I want the launcher interface to reflect the selected language, so that the visible UI is consistent.

#### Acceptance Criteria

1. WHEN the selected UI language is English, THE application SHALL display launcher UI text in English.
2. WHEN the selected UI language is Simplified Chinese, THE application SHALL display launcher UI text in Simplified Chinese.
3. WHEN the user changes the UI language and saves settings, THE application SHALL request a restart to apply the change.

### Requirement 4: Fallback behavior

**User Story:** AS a user, I want the launcher to remain usable when a translation is incomplete, so that the application always has a readable interface.

#### Acceptance Criteria

1. IF a translated UI string is missing, THE application SHALL display the English text for that string.
2. IF a language choice cannot be mapped to a translation set, THE application SHALL display English UI text.
