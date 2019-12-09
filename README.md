# PrincessConsuelaBananaHammock

## Documentation
* [Introduction to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
* [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio)

## Testing the API
Press **Ctrl+F5** or **F5** to run the app. Launch a browser and navigate to https://localhost:44330/

If you get a dialog box that asks if you should trust the IIS Express certificate, select **Yes**. In the **Security Warning** dialog that appears next, select **Yes**.

To confirm api is working, navigate to https://localhost:44330/api/agents, to view all agent items.

## Endpoints
API | Description | Request body | Response body
--- | --- | --- | ---
GET /api/agents | Get all agent items | None | List of agent items
GET /api/agents/{id} | Get an agent item by id | None | Agent item
POST /api/agents | Add a new agent item | Agent item | None
POST /api/agents/{id}/customer | Add a new customer item to an agent item | Customer item | None
PUT /api/agents/{id} | Update an agent item | Agent item | None
PUT /api/agents/{id}/customer | Update a customer item of an agent item | Customer item | None
DELETE /api/agents/{id} | Delete an agent item by id | None | None
DELETE /api/agents/{id}/customer/{customerId} | Delete a customer item of an agent item | None | None
