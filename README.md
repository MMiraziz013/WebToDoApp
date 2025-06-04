# Web To-Do App

## Overview
The Web To-Do App is a simple yet effective task management application built using ASP.NET MVC and Entity Framework Core with SQLite as the database. This application allows users to create, read, update, and delete tasks effortlessly. It's designed to help users manage their daily tasks efficiently, keeping their to-do lists organized and accessible.

## Features
- **Task Management**: Add, edit, and delete tasks.
- **Task Details**: View task details such as description and due date.
- **Data Storage**: Uses SQLite to store tasks, ensuring a lightweight and easy-to-manage database solution.
- **Responsive Design**: Built with a user-friendly interface to enhance user experience.

## Technologies Used
- **ASP.NET MVC**: For creating the web application and handling HTTP requests.
- **Entity Framework Core**: For interacting with the SQLite database.
- **SQLite**: A lightweight database engine used for data storage.
- **HTML/CSS**: For designing the user interface.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- [SQLite](https://www.sqlite.org/download.html) installed to manage the database.
- A web browser (e.g., Chrome, Firefox).

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/MMiraziz013/WebToDoApp.git
2. Navigate to the project directory
   ```bash
   cd WebToDoApp
3. Restore NuGet Packages:
   ```bash
   dotnet restore
4. Run the application
   ```bash
   dotnet run

## Accessing the Application
Open your web browser and navigate to https://localhost:7191/ to access the To-Do List application.

## Database
The application uses SQLite for data storage. 
The database file is created automatically when the application runs for the first time, storing all your tasks.
You can manage the database schema and data using Entity Framework migrations.

## Contribution
Feel free to fork the repository, create a new branch, and submit a pull request if you wish to contribute to the project.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
