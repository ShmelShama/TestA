# TestAssignment
Выполненное тестовое задание на позицию Младший Backend программист ООО Роболайн Софтлайн

Задача: Создать простой веб-сервис, который предоставляет RESTful API для управления
товарами и категориями товаров.

Используемые сущности:

Категория товара (ProductCategory):

Id (int) — уникальный идентификатор категории;

Name (string) — название категории;

Description (string) — описание категории (необязательно).

Товар (Product):

Id (int) — уникальный идентификатор товара;

Name (string) — название товара;

Description (string) — описание товара;

Price (decimal) — цена товара;

CategoryId (int) — идентификатор категории, к которой относится товар.

## Packages

| Package   | URL/CLI                                     |
| -------- | ---------------------------------------- | 
| **.NET SDK 8.0.10**    |https://dotnet.microsoft.com/ru-ru/download/dotnet/8.0                           |
| **Automapper**   |dotnet add package AutoMapper --version 13.0.1                             | 
| **EntityFrameworkCore.Sqlite**    | dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.10   | 
| **Swagger**  | dotnet add package Swashbuckle.AspNetCore --version 6.6.2                         | 

## Build

Сохраните проект на ПК и перейдите к нему.

**dotnet restore** - команда для востановления пакетов

**dotnet build** - сборка проекта

**dotnet run** - запуск проекта

Проект будет запущен локально на `"http://localhost:5033"`

При запуске проекта в Visual Studio будет запущен браузер со Swagger `http://localhost:5033/swagger/index.html`

В качестве БД используется **SQLite**. БД будет создана автоматически в корне проекта при первом обращении по API


## Api docs
### Product
| Method   | URL                                      | Description                              |
| -------- | ---------------------------------------- | ---------------------------------------- |
| `GET`    | `/api/Product`                             | Получить список всех продуктов                    |
| `POST`   | `/api/Product`                             | Добавить новый продукт                       |
| `GET`    | `/api/Product/{id}`                          | Получить продукт с указанным Id                       |
| `PUT`  | `/api/Product/{id}`                          | Обновить данные в продукте               |
| `DELETE`    | `/api/Product/{id}` | Удалить продукт |
| `GET` | `/api/Product/{id}/category`| Получить категорию продукта                   |

**Request data**
```javascript
{
  "name": "string",
  "description": "string",
  "price": 0,
  "categoryId": 0
}
```

**Response data**
```javascript
{
    "id": 0,
    "name": "string",
    "description": "string",
    "price": 0,
    "categoryId": 0
}
```

### ProductCategory
| Method   | URL                                      | Description                              |
| -------- | ---------------------------------------- | ---------------------------------------- |
| `GET`    | `/api/ProductCategory`                             | Получить список всех категорий                    |
| `POST`   | `/api/ProductCategory`                             | Добавить новую категорию                      |
| `GET`    | `/api/ProductCategory/{id}`                          | Получить категорию с указанным Id                       |
| `PUT`  | `/api/ProductCategory/{id}`                          | Обновить данные в категории              |
| `DELETE`    | `/api/ProductCategory/{id}` | Удалить категорию (будут также удалены продукты в категории) |
| `GET` | `/api/ProductCategory/{id}/products`| Получить продукты данной категории                 |

**Request data**
```javascript
{
  "name": "string",
  "description": "string"
}
```

**Response data**
```javascript
{
    "id": 0,
    "name": "string",
    "description": "string"
}
```
