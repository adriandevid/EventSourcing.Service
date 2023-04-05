
# EventSourcing api for example

Api rest using event sourcing.


## Configurations

#### Generate database
* Add-Migration {migration_name}
* Update-Database

## Routers

#### Create new user

```http
  POST /create
```

| Parameter   | Type       | Description                           |
| :---------- | :--------- | :---------------------------------- |
| `name` | `string` | **Required**. name of user |

| Parameter   | Type       | Description                           |
| :---------- | :--------- | :---------------------------------- |
| `password` | `string` | **Required**. password of user |

#### Update user

```http
  PUT /update
```
| Parameter   | Type       | Description                           |
| :---------- | :--------- | :---------------------------------- |
| `name` | `string` | **Required**. name of user |

| Parameter   | Type       | Description                           |
| :---------- | :--------- | :---------------------------------- |
| `password` | `string` | **Required**. password of user |
