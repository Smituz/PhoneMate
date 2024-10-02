# PhoneMate
# PhoneMate

**PhoneMate** is a user-friendly ASP.NET Core MVC application developed to manage and organize your phone contacts efficiently. The application allows users to add, edit, delete, and search contacts with ease. It was built by me and my friend [Saif Huseni](https://github.com/saifhuseni) using .NET Core MVC and Microsoft Visual Studio.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Screenshots](#screenshots)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Contributors](#contributors)


## Overview
**PhoneMate** simplifies contact management by providing a streamlined interface to keep track of phone contacts. It leverages the power of ASP.NET Core MVC for backend logic and Entity Framework for database interactions, ensuring a smooth experience for users to maintain their contact lists.

## Features
- Add new contacts with details such as name, phone number, email, address, Instagram ID, X ID etc.
- Edit or delete existing contacts.
- Search contacts by Name.
- Differentiate and group your contacts by putting them in a group of your choice at the time of contact creation.
- Data stored securely in an integrated SQL Server database.
  
## Screenshots
Here are a few glimpses of the *PhoneMate* application:

### Home Page
![image](https://github.com/user-attachments/assets/edde1b43-be70-447f-9f49-459730ac0626)

### Add New Contact
![image](https://github.com/user-attachments/assets/7928ce26-f1cb-473f-a2dd-6ea5b99e33ee)

### My Groups Page
![image](https://github.com/user-attachments/assets/3f9ebd2e-2509-4a9c-8baf-e3a527a77424)


## Prerequisites
To run the *PhoneMate* application on your local machine, you will need to have the following installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [.NET Core SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [ADO.NET](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-overview)
  
## Setup Instructions
Follow these steps to get *PhoneMate* up and running on your machine:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/PhoneMate.git
    cd PhoneMate
    ```

2. **Open the solution in Visual Studio**:
    - Open `PhoneMate.sln` in Visual Studio.

3. **Configure Database Connection**:
    - Update the `appsettings.json` file with your SQL Server credentials:
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server_name;Database=PhoneMateDB;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
      ```

4. **Run Migrations**:
    - Run the following command in the Package Manager Console to apply migrations and set up the database:
      ```bash
      Update-Database
      ```

5. **Run the Application**:
    - Press `F5` in Visual Studio or run the project using the terminal:
      ```bash
      dotnet run
      ```

6. **Access the Application**:
    - Navigate to `http://localhost:5000` in your web browser to use the app.

## Contributors
- **[Smit Bhansali](https://github.com/Smituz/)** - Developer
- **[Saif Huseni](https://github.com/saifhuseni)** - Developer
