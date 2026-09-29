### N-Tier API

- Tier means layer, and n means numbers. An N-Tier API splits the work into different layers, that each do one job, and only talk to the layer next to them. 

Controller(Presentation) -> Services(Business) -> Repository(Data access) -> Database

## Controller

- Speaks HTTP, Takes the request, asks the service, and picks the status code

## Services 

- Holds the rules AKA business Logic

## Repository

- Stores and Fetches Data: get, add, update, and delete. (The only class that uses AppDbContext)
