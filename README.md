# Quickstart: Reqnroll, BDD и приемочные тесты

Этот репозиторий — небольшая «песочница», чтобы пощупать Reqnroll, BDD и в целом подход к приемочным тестам. Тут минимальная бизнес‑логика и набор фич/степов, на которых удобно тренироваться: писать сценарии на Gherkin, мапить их на шаги и запускать тесты из IDE/CLI.

## Зачем это
- Понять, как описывать поведение через Gherkin‑сценарии (BDD).
- Увидеть связку: Feature → Step Definitions → сгенеренные магическим образом тесты (всегда бы так).
- Запустить приемочные тесты на Reqnroll и потрогать дебаг.

## Состав проекта
- `ReqnrollQuickstart.App` — условное SUT (бизнес‑логика), например `PriceCalculator`.
- `ReqnrollQuickstart.Specs` — приемочные тесты на Reqnroll + MSTest:
  - `Features/PriceCalculation.feature` — примеры сценариев на Gherkin.
  - `StepDefinitions/PriceCalculationStepDefinitions.cs` — шаги (Given/When/Then).

Стек: .NET `net9.0`, Reqnroll (`Reqnroll.MsTest`), MSTest, FluentAssertions.

## Быстрый старт
Требования: установлен .NET SDK 9 (или поменяйте `TargetFramework` на совместимый у себя локально).

Запуск всех тестов из корня репозитория:

```bash
dotnet test
```

Только проект со спецификациями:

```bash
dotnet test ReqnrollQuickstart.Specs
```

Из IDE (Rider/VS/VS Code) сценарии отображаются как обычные тесты — можно запускать/дебажить по одному сценарию.

## Как добавлять сценарии
1. Создайте `.feature` в `ReqnrollQuickstart.Specs/Features` и опишите сценарии на Gherkin.
2. Сгенерируйте/допишите шаги в `ReqnrollQuickstart.Specs/StepDefinitions` с атрибутами `[Given]`, `[When]`, `[Then]`.
3. В шагах обращайтесь к SUT из `ReqnrollQuickstart.App`.
4. Запускайте `dotnet test` или запускайте сценарии из IDE.

Полезные приёмы:
- Для таблиц в шагах используйте `Table` и преобразование во множество записей (см. пример в `PriceCalculationStepDefinitions.cs`).
- Для проверок используйте FluentAssertions (`.Should().Be(...)`).

## Полезные ссылки
- Quickstart по Reqnroll: https://go.reqnroll.net/quickstart
- Документация Reqnroll: https://docs.reqnroll.net/

Если что-то не запускается из‑за версии SDK — ~~помолитесь и~~ проверьте установленный .NET, либо снизьте `TargetFramework` до доступной версии в обоих проектах.
