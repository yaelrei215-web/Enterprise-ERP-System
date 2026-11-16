# Enterprise Event & Catering Management System (ERP)

An end-to-end desktop and server application designed for managing event halls, catering menus, customer orders, and resource scheduling. Built using **C#**, **.NET**, **WPF**, **WCF**, and **MS SQL Server**, following a clean **N-Tier Architecture**.

---

## Key Features

### Client-Side (WPF Desktop Application)
* **User Management & Authentication:** Registration, login validation, and role-based user profiles (`PLogin`, `PUser`, `UCUser`).
* **Event Hall Booking:** Browse available venues by city and date, view pricing and capacity details, and complete hall reservations (`PAllHallWithUC`, `PAvelibele`, `POrderHall`).
* **Catering & Menu Management:** Dynamic category filtering, meal selection, and an interactive shopping basket for multi-item catering orders (`PageCategory`, `PAllMealWithUC`, `shoppingBasket`).
* **Order Tracking:** Comprehensive view of customer order history and event status (`PMyOrder`, `PAllOrder`).

### Server-Side & Business Logic (WCF & N-Tier)
* **Data Access Layer (DAL):** Built with **Entity Framework (Database-First)** mapping relational entities (`Users`, `Halls`, `OrderHalls`, `Meals`, `Categories`, `Orders`, `DataOrders`, `Cities`).
* **Business Logic Layer (BL):** Encapsulates core domain rules, entity-to-DTO conversions, and smart order aggregation (e.g., automatically merging duplicate meal items in `DataOrderBL`).
* **Data Transfer Objects (DTO):** Decouples internal database entities from client-facing service contracts (`IService1`, `Service1`).

---

## Tech Stack

* **Languages:** C#, XAML, SQL
* **Frameworks & Libraries:** .NET Framework, WPF (Windows Presentation Foundation), WCF (Windows Communication Foundation), Entity Framework 6
* **Database:** Microsoft SQL Server
* **Architecture:** N-Tier Architecture (UI / Service Layer / BL / DAL / DTO)

---

## Project Structure

* **Client (`GUIYael`):** XAML views, User Controls (`UCHall`, `UCMeal`, `UCUser`), client-side validation (`Validation.cs`), and WCF service references.
* **Service Host (`HostYael`):** Console/application host (`Program.cs`) exposing the WCF endpoints.
* **Server (`ServerYaelReichenberg`):**
  * **BL:** `UserBL`, `HallBL`, `OrderHallBL`, `MealBL`, `CategoryBL`, `OrderBL`, `DataOrderBL`, `CityBL`
  * **DAL:** Entity Framework EDMX models and context (`DbYaelReichenbergEntities`)
  * **DTO:** Lightweight data models for client-server communication

---

## Author

**Yael Reichenberg**  
Computer Science Student | C#, .NET & SQL Developer  
[Yael Reichenberg](https://github.com)
