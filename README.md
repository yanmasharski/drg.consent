# DRG Consent

Consent abstraction layer. Defines the contract for CMP (Consent Management Platform) integrations.

## Assemblies

| Assembly | Contains |
|---|---|
| `DRG.Consent` | `IConsentPlatform`, `ConsentState` |
| `DRG.Consent.Runtime` | `ConsentPlatformProxy`, `EditorConsentPlatform` |

## Key types

- **`IConsentPlatform`** — `state`, `TryShowConsentDialog(Action<bool>)`, `TryShowConsentDialogAsync()`.
- **`ConsentState`** — `Unknown` / `Accepted` / `Declined` / `NotApplicable`.
- **`ConsentPlatformProxy`** — wraps a list of `IConsentPlatform` providers and delegates to the first one that can show a dialog.
- **`EditorConsentPlatform`** — in-Editor stub, always returns `Accepted`.

## Provider packages

| Package | CMP |
|---|---|
| `com.drg.consent.applovin` | Applovin MAX CMP |
| `com.drg.consent.google` | Google UMP |

## Dependencies

- `com.drg.core`

## Install

```
https://github.com/yanmasharski/drg.consent.git#0.9.0
```
