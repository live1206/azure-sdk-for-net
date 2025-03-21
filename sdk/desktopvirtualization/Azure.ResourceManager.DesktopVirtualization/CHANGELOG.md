# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Fix an issue that the `SessionHostData` can't handle empty `resourceId`.

## 1.3.0 (2024-09-10)

### Features Added

- Upgraded api-version tag from 'package-2023-09' to 'package-2024-04'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/ec07fc78c6c25b68107f8ff419d137ffecced005/specification/desktopvirtualization/resource-manager/readme.md.
    - App Attach Package Support
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Added experimental Bicep serialization.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.42.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.13.0

## 1.2.1 (2023-11-27)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0 (2023-10-26)

### Features Added

- Private Link Support
- Scaling Plan Personal Schedules

### Breaking Changes

- Scaling Parameter "rampDownCapacityThresholdPct" minimum value changed from 0 to 1.

### Other Changes

- Upgraded API version to 2023-09-05

## 1.1.0 (2023-05-12)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded API version to 2022-09-09
- Upgraded dependent `Azure.Core` to `1.32.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.6.0`.

## 1.0.1 (2023-02-15)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-26)

This release is the first stable release of the Desktop Virtualization Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `DesktopVirtualization` prefix to all single / simple model names.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Optimized the name of some models and functions.
- Replaced the model `ResourceModelWithAllowedPropertySetIdentity` with `Azure.ResourceManager.Models.ManagedServiceIdentit`.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-07-06)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
