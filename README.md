# Lecture_11 решение задания

# Якимович Никита Андреевич, КБ-251.

## Архитектура

- `ACM.BL` содержит предметные классы и контракты репозиториев. Классы `Customer`, `Product`, `Order` и `OrderItem` проверяют свои данные, но не выполняют чтение и сохранение. Общие поля адреса выделены в `Address`.
- `ACM.DAL` реализует контракты репозиториями `InMemory...Repository`. Они хранят копии объектов в памяти и назначают идентификаторы при первом сохранении.
- `ACM.DAL` зависит от `ACM.BL`; предметные классы не зависят от слоя доступа к данным.
- Связи заказов представлены идентификаторами: `Order.CustomerId`, `OrderItem.OrderId` и `OrderItem.ProductId`.

Пример использования:

```csharp
using System;
using CMS.BusinessLayer;
using CMS.DataAccess;

var customers = new InMemoryCustomerRepository();
var customer = new Customer
{
    FirstName = "Bilbo",
    LastName = "Baggins",
    EmailAddress = "bilbo@example.com",
    HomeAddress = new Address { City = "Hobbiton" }
};

if (!customer.Validate())
{
    throw new InvalidOperationException("Customer data is invalid.");
}

var customerId = customers.Save(customer);

var savedCustomer = customers.GetById(customerId);
```

Хранилище учебное: данные доступны только через тот же экземпляр репозитория и исчезают при завершении процесса.
