# WebDevBackend

# Event API Documentation

The Event API allows users to manage events and perform CRUD (Create, Read, Update, Delete) operations on events.

## Base URL

```
/api/v3/app/events
```

## API Endpoints

### Get Single Event

Retrieves the details of a single event based on the provided ID.

```
GET /api/v3/app/events/{id}
```

#### Request Parameters

- `id` (integer, required): The ID of the event to retrieve.

#### Response

- 200 OK: Returns the details of the requested event.
- 404 Not Found: If the event with the specified ID does not exist.

### Get Latest Events

Retrieves a list of the latest events.

```
GET /api/v3/app/events?type=latest&limit={limit}&page={page}
```

#### Query Parameters

- `type` (string, optional): The type of events to retrieve. Default value is "latest".
- `limit` (integer, optional): The maximum number of events to return per page. Default value is 5.
- `page` (integer, optional): The page number of the events to retrieve. Default value is 1.

#### Response

- 200 OK: Returns a list of the latest events based on the provided parameters.

### Add Event

Creates a new event.

```
POST /api/v3/app/events
```

#### Request Body

The request should include form data with the following properties:

- `name` (string, required): The name of the event.
- `tagline` (string, optional): The tagline for the event.
- `schedule` (date-time, required): The date and time of the event.
- `description` (string, optional): The description of the event.
- `image` (file, optional): An image file for the event.
- `moderator` (string, optional): The user who is going to host the event.
- `category` (string, optional): The category of the event.
- `subCategory` (string, optional): The subcategory of the event.
- `rigorRank` (integer, optional): An integer value representing the rigor rank of the event.
- `attendees` (array of integers, optional): An array of user IDs attending the event.

#### Response

- 200 OK: Returns the details of the created event.

### Update Event

Updates an existing event.

```
PUT /api/v3/app/events
```

#### Request Body

The request should include form data with the following properties:

- `id` (integer, required): The ID of the event to update.
- `name` (string, optional): The updated name of the event.
- `tagline` (string, optional): The updated tagline for the event.
- `schedule` (date-time, optional): The updated date and time of the event.
- `description` (string, optional): The updated description of the event.
- `image` (file, optional): An updated image file for the event.
- `moderator` (string, optional): The updated user who is going to host the event.
- `category` (string, optional): The updated category of the event.
- `subCategory` (string, optional): The updated subcategory of the event.
- `rigorRank` (integer, optional): An updated integer value representing the rigor rank of the event.
- `attendees` (array of integers, optional): An updated array of user IDs attending the event.

#### Response

- 200 OK: Returns the details of the

 updated event.
- 404 Not Found: If the event with the specified ID does not exist.

### Delete Event

Deletes an existing event.

```
DELETE /api/v3/app/events/{id}
```

#### Request Parameters

- `id` (integer, required): The ID of the event to delete.

#### Response

- 200 OK: Returns the details of the deleted event.
- 404 Not Found: If the event with the specified ID does not exist.


## Event CRUD functionalities

### Base URL: `/api/v3/app/events`

### Get Single Event
- Retrieves the details of a specific event identified by its ID.

**Request:**
```http
GET /api/v3/app/events/{id}
```

**Response:**
```json
Status: 200 OK
Content-Type: application/json

{
  "data": {
    "id": 1,
    "name": "Event 1",
    "tagline": "Join us for Event 1",
    "schedule": "2023-05-25T10:00:00Z",
    "description": "This is Event 1 description",
    "image": null,
    "moderator": "John Doe",
    "category": "EventCategoryOne",
    "subCategory": "EventSubCategoryThree",
    "rigorRank": 3,
    "attendees": [123, 456, 789]
  }
}
```

### Get Latest Events
- Retrieves the latest events based on the provided parameters.
- Parameters:
  - `type` (optional, default: "latest"): Type of events to retrieve ("latest", "upcoming", "popular", etc.)
  - `limit` (optional, default: 5): Maximum number of events to retrieve
  - `page` (optional, default: 1): Page number for pagination

**Request:**
```http
GET /api/v3/app/events?type=latest&limit=5&page=1
```

**Response:**
```json
Status: 200 OK
Content-Type: application/json

{
  "data": [
    {
      "id": 1,
      "name": "Event 1",
      "tagline": "Join us for Event 1",
      "schedule": "2023-05-25T10:00:00Z",
      "description": "This is Event 1 description",
      "image": null,
      "moderator": "John Doe",
      "category": "EventCategoryOne",
      "subCategory": "EventSubCategoryThree",
      "rigorRank": 3,
      "attendees": [123, 456, 789]
    },
    {
      "id": 2,
      "name": "Event 2",
      "tagline": "Join us for Event 2",
      "schedule": "2023-05-26T10:00:00Z",
      "description": "This is Event 2 description",
      "image": null,
      "moderator": "Jane Smith",
      "category": "EventCategoryTwo",
      "subCategory": "EventSubCategoryTwo",
      "rigorRank": 2,
      "attendees": [456, 789]
    },
    ...
  ]
}
```

### Add Event
- Creates a new event based on the provided data.

**Request:**
```http
POST /api/v3/app/events
Content-Type: multipart/form-data

name=Event%203&tagline=Join%20us%20for%20Event%203&schedule=2023-05-27T10%3A00%3A00Z&description=This%20is%20Event%203%20description&moderator=John%20Doe&category=EventCategoryTwo&subCategory=EventSubCategoryTwo&rigorRank=3
```

**Response:**
```json
Status: 200 OK
Content-Type: application/json

{
  "data": [
    {
      "id": 1,
      "name": "Event 1",
      "tagline": "Join us for Event 1",
      "schedule": "2023-05-25T10:00:00Z",
      "description": "This is Event 1 description",
      "image": null,
      "moderator": "John Doe",
      "category": "EventCategoryOne",
      "subCategory": "EventSubCategoryThree",
      "rigorRank": 3,
      "attendees": [123, 456, 789]
    },
    {
      "id": 2,
      "name": "Event 2",
      "tagline": "Join us for Event 2",
      "schedule": "2023-05-26T10:00:00Z",
      "description": "This is Event 2 description",
      "image": null,
      "moderator": "Jane Smith",
      "category": "EventCategoryTwo",
      "subCategory": "EventSubCategoryTwo",
      "rigorRank": 2,
      "attendees": [456, 789]
    },
    ...
  ]
}
```

### Update Event
- Updates the details of an existing event based on the provided data.

**Request:**
```http
PUT /api/v3/app/events
Content-Type: multipart/form-data

id=1&name=Updated%20Event%201&tagline=Join%20us%20for%20Updated%20Event%201&schedule=2023-05-25T12%3A00%3A00Z&description=This%20is%20the%20updated%20description%20for%20Event%201&moderator=John%20Doe&category=EventCategoryOne&subCategory=EventSubCategoryThree&rigorRank=4
```

**Response:**
```json
Status: 200 OK
Content-Type: application/json

{
  "data": {
    "id": 1,
    "name": "Updated Event 1",
    "tagline": "Join us for Updated Event 1",
    "schedule": "2023-05-25T12:00:00Z",
    "description": "This is the updated description for Event 1",
    "image": null,
    "moderator": "John Doe",
    "category": "EventCategoryOne",
    "subCategory": "EventSubCategoryThree",
    "rigorRank": 4,
    "attendees": [123, 456, 789]
  }
}
```

### Delete Event
- Deletes an existing event identified by its ID.

**Request:**
```http
DELETE /api/v3/app/events/{id}
```

**Response:**
```json
Status: 200 OK
Content-Type: application/json

{
  "data": {
    "id": 1,
    "name": "Event 1",
    "tagline": "Join us for Event 1",
    "schedule": "2023-05-25T10:00:00Z",
    "description": "This is Event 1 description",
    "image": null,
    "moderator": "John Doe",
    "category": "EventCategoryOne",
    "subCategory": "EventSubCategoryThree",
    "rigorRank": 3,
    "attendees": [123, 456, 789]
  }
}
```
