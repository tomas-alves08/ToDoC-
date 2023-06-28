# ToDoC#

This is a C# .NET Web API project that aim to create end points that will allow React front end user commands to update a SQL database using Entity Framework.

This Web API was not deployed so can only be used when running in a localhost.

The Web API has 5 end-points as can be seen using Swagger on URL https://localhost:7207/swagger/index.html

First End Point: 
  Method: GET
  URL: https://localhost:7207/api/TodoApi
  Body: None
  Response:
    [
        {
      "id": 26,
      "item": "26string",
      "description": "string",
      "dueDate": "2023-06-28T13:22:58.009",
      "dateComplete": "2023-06-28T00:00:00",
      "createDate": "0001-01-01T00:00:00",
      "updateDate": "0001-01-01T00:00:00",
      "isCompleted": true
    }
  ]

Second End Point: 
  Method: POST
  URL: https://localhost:7207/api/TodoApi
  Body: 
    {
    "item": "string",
    "description": "string",
    "dueDate": "2023-06-28T13:09:53.622Z"
    }
  Response:
    {
      "item": "string",
      "description": "string",
      "dueDate": "2023-06-28T13:13:50.425Z"
    }

Third End Point: 
  Method: GET
  URL: https://localhost:7207/api/TodoApi/id:int?id={id}
  Body: 
    {
    "id": int,
    }
  Response:
    {
      "id": 0,
      "item": "string",
      "description": "string",
      "dueDate": "2023-06-28T13:17:46.455Z",
      "dateComplete": "2023-06-28T13:17:46.455Z",
      "createDate": "0001-01-01T00:00:00",
      "updateDate": "0001-01-01T00:00:00",
      "isCompleted": true
    }

 Forth End Point: 
  Method: DELETE
  URL: https://localhost:7207/api/TodoApi/id:int?id={id}
  Body: 
    {
    "id": int,
    }
  Response: None

 Fifth End Point: 
   Method: PUT
   URL: https://localhost:7207/api/TodoApi/id:int?id={id}
   Body: 
     {
       "id": 0,
       "item": "string",
       "description": "string",
       "dueDate": "2023-06-28T13:20:37.229Z",
       "dateComplete": "2023-06-28T13:20:37.229Z",
       "isCompleted": true
     }
   Response: None
