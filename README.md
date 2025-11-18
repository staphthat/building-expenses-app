# Building Expenses Tracker (Aplikacija za Troškove Zgrade)

A web application designed to help building managers and tenants track monthly utility bills and maintenance expenses. Ideally used for calculating debts per apartment unit.

![App Screenshot](screenshot.png)

## Functionalities (Funkcionalnosti)

This project focuses on DOM manipulation and specific calculation logic tailored to building management.

* **Apartment Selection:** Users can select an apartment unit from a dropdown menu to load specific data.
* **Data Visualization:**
    * Fetches and displays bills dynamically using **JavaScript Fetch API**.
    * **Color Coded Status:** Automatically visualizes payment status (Green = Paid/Da, Red = Unpaid/Ne).
* **Financial Logic:**
    * **Debt Calculation:** Includes a specific algorithm to sum up unpaid bills for the selected apartment.
    * Real-time calculation displayed on the UI upon user request.
* **Responsive Design:** The interface adapts to different screen sizes (cards stack vertically on mobile devices using CSS Flexbox/Grid).

## Tech Stack

* **Backend:** C# .NET 8.0, Entity Framework Core
* **Frontend:** JavaScript (Vanilla), HTML5, CSS3
* **Database:** SQL Server
* **API:** RESTful API endpoints (GET, POST functionality implemented in controllers)

## Learning Outcomes

This project was built to practice:
1.  Connecting backend models with frontend UI.
2.  Handling logic for specific items (filtering bills by Apartment ID).
3.  Creating responsive layouts manually via CSS.