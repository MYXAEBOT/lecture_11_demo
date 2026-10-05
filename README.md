# Lecture_11 решение задания

# Якимович Никита Андреевич, КБ-251.

## Архитектура

- `ACM.BL` содержит предметные классы и контракты репозиториев. Классы `Customer`, `Product`, `Order` и `OrderItem` проверяют свои данные, но не выполняют чтение и сохранение.
- `ACM.DAL` реализует контракты репозиториями `InMemory...Repository`. Они хранят копии объектов в памяти и назначают идентификаторы при первом сохранении.
- `ACM.DAL` зависит от `ACM.BL`; предметные классы не зависят от слоя доступа к данным.

Пример использования:

```csharp
using CMS.BusinessLayer;
using CMS.DataAccess;

var customers = new InMemoryCustomerRepository();
var customerId = customers.Save(new Customer
{
    FirstName = "Bilbo",
    LastName = "Baggins",
    EmailAddress = "bilbo@example.com"
});

var savedCustomer = customers.GetById(customerId);
```

Хранилище учебное: данные доступны только через тот же экземпляр репозитория и исчезают при завершении процесса.
