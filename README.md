# Web API Demo - Shirts Management

This is a simple ASP.NET Core Web API that provides CRUD operations for managing shirts.

## Base URL

The API is hosted on **Azure** and can be accessed at:

```
https://webapidemoapp.azurewebsites.net/api/shirts/
```

## API Endpoints

### 1. Get All Shirts
**Endpoint:** `GET /api/shirts`

**Description:** Fetches the list of all shirts.

**Response:**
```json
[
    {
        "shirtId": 1,
        "brand": "My Brand1",
        "color": "Blue",
        "gender": "Men",
        "price": 500,
        "size": 10
    }
]
```

---

### 2. Get Shirt by ID
**Endpoint:** `GET /api/shirts/{id}`

**Description:** Fetches a specific shirt by its ID.

**Example Request:**
```
GET /api/shirts/1
```

**Success Response:**
```json
{
    "shirtId": 1,
    "brand": "My Brand1",
    "color": "Blue",
    "gender": "Men",
    "price": 500,
    "size": 10
}
```

**Errors:**
- `400 Bad Request` if ID is invalid.
- `404 Not Found` if shirt does not exist.

---

### 3. Create a New Shirt
**Endpoint:** `POST /api/shirts`

**Description:** Adds a new shirt to the collection.

**Request Body:**
```json
{
    "brand": "New Brand",
    "color": "Green",
    "gender": "Women",
    "price": 600,
    "size": 12
}
```

**Success Response:**
- `201 Created`
- Location header points to `GET /api/shirts/{id}`

**Errors:**
- `400 Bad Request` if required fields are missing.

---

### 4. Update a Shirt
**Endpoint:** `PUT /api/shirts/{id}`

**Description:** Updates an existing shirt.

**Request Body:**
```json
{
    "shirtId": 1,
    "brand": "Updated Brand",
    "color": "Black",
    "gender": "Men",
    "price": 700,
    "size": 14
}
```

**Success Response:**
- `204 No Content`

**Errors:**
- `400 Bad Request` if ID is invalid.
- `404 Not Found` if the shirt does not exist.

---

### 5. Delete a Shirt
**Endpoint:** `DELETE /api/shirts/{id}`

**Description:** Removes a shirt by ID.

**Example Request:**
```
DELETE /api/shirts/1
```

**Success Response:**
```json
{
    "shirtId": 1,
    "brand": "My Brand1",
    "color": "Blue",
    "gender": "Men",
    "price": 500,
    "size": 10
}
```

**Errors:**
- `400 Bad Request` if ID is invalid.
- `404 Not Found` if the shirt does not exist.

---

## Validation and Filters
This API includes various filters for validation and error handling:
- **`Shirt_ValidateShirtIdFilter`**: Ensures the provided ID exists.
- **`Shirt_ValidateCreateShirtFilter`**: Validates required fields for creation.
- **`Shirt_ValidateUpdateShirtFilter`**: Ensures valid updates.
- **`Shirt_HandleUpdateExceptionFilter`**: Handles exceptions during updates.

## How to Run Locally
1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/WebAPIDemo.git
    cd WebAPIDemo
    ```
2. Install dependencies:
    ```sh
    dotnet restore
    ```
3. Build and run:
    ```sh
    dotnet run
    ```
4. Access API at:
    ```
    https://localhost:5001/api/shirts
    ```

## Technologies Used
- **ASP.NET Core 9**
- **Entity Framework Core** (for data handling)
- **Filters** for validation and exception handling


