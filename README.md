# Notification Service

## Overview
This is a notification service API that allows sending notifications via different channels (email, SMS, push). The service is built using .NET 6, and follows principles like Clean Architecture, SOLID principles, and Dependency Injection. It also integrates FluentValidation for input validation and Entity Framework Core for data storage.

## Architecture

- **Clean Architecture**: The solution follows the principles of Clean Architecture, where the core domain logic is decoupled from infrastructure, API, and other concerns.
- **SOLID Principles**: The code is designed based on SOLID principles to ensure maintainability and extensibility.
- **FluentValidation**: Input validation is handled using FluentValidation to ensure the consistency and integrity of the input data.
- **Entity Framework Core**: The application uses EF Core to manage the persistence layer, with support for SQLite (or In-Memory DB for testing).

## Design Decisions
- **Notification Channels**: The system supports multiple notification channels like Email, SMS, and Push notifications. This is made possible by the Factory Design Pattern, which dynamically creates the appropriate sender.
- **Database**: For persistence, an SQLite database is used to store notification logs.
- **Logging**: Logs are captured via middleware, and error handling is centralized to improve maintainability and traceability.

## How to Run the Project

1. **Clone the repository**:
   ```bash
   git clone https://github.com/julyahovhannisyan/NotificationService.git
