# CosmosContainer

This project adds an interface IContainer<T> and a class wrapping a Microsoft.Azure.Cosmos.Container object. This can be used for dependency injecting multiple containers using a DI framework.

## Usage

```csharp
// variable 'container' is a previously created Microsoft.Azure.Cosmos.Container object
var personContainer = new Container<Person>(container);
builder.Services.AddSingleton<IContainer<Person>>(personContainer);
```