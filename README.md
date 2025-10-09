# Personal Tracker

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=xaml&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

A **WPF desktop application** for managing personal financial transactions, including user registration, deposits, and withdrawals using a visa card system.

## 📋 Overview

Personal Tracker is a financial management system that allows users to:
- Register new accounts with email and password
- Perform deposit operations
- Perform withdrawal operations
- Manage visa card information linked to user accounts

## 🛠️ Technologies Used

- **Framework:** .NET WPF (Windows Presentation Foundation)
- **Language:** C#
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **UI:** XAML

## 📁 Project Structure

```
Personal_Tracker/
├── Model/
│   ├── PersonalTrackerDB.cs    # Database context
│   ├── Users.cs                # User entity model
│   └── Visa.cs                 # Visa card entity model
├── Views/
│   ├── Add_New_User.xaml       # User registration UI
│   ├── Add_New_User.xaml.cs    # User registration logic
│   ├── Transactions.xaml       # Transaction operations UI
│   └── Transactions.xaml.cs    # Transaction operations logic

```

## 🗄️ Database Schema

### Users Table
- **Id** (int, Primary Key, Identity)
- **Name** (string, max 80 characters, required)
- **Email** (string, max 80 characters, required)
- **Balance** (decimal(18,2), required)

### Visa Table
- **Code** (int, Primary Key, Identity)
- **Password** (int, required)
- **User_id** (int, Foreign Key)

### Relationships
- **One-to-Many:** One User can have multiple Visa cards
- **Cascade Delete:** Deleting a user will automatically delete all associated visa cards

## ⚙️ Setup Instructions

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework / .NET 6.0+
- SQL Server (LocalDB or full instance)

### Installation Steps

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd Personal_Tracker
   ```

2. **Update connection string:**
   Open `PersonalTrackerDB.cs` and modify the connection string if needed:
   ```csharp
   optionsBuilder.UseSqlServer("Server=localhost;Database=PersonalTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;");
   ```

3. **Create the database:**
   Open Package Manager Console in Visual Studio and run:
   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```
   
   **Note:** The migration files are already included in the project under `Migrations/` folder, so you can directly run `Update-Database` if the migration exists.

4. **Build and run the application:**
   Press `F5` or click the Start button in Visual Studio.

## 💡 Features

### User Registration
- Create new user accounts with username, email, and password
- Initial balance of **5000** is assigned to new users
- Automatic visa card creation linked to the user account
- Validation to prevent duplicate usernames or emails

### Transactions

#### Withdraw
- Requires User ID, Visa Code, Password, and withdrawal amount
- Validates sufficient balance before processing
- Updates user balance in real-time

#### Deposit
- Requires User ID, Visa Code, Password, and deposit amount
- Adds funds to user account
- Validates all input fields

## 🎨 UI Features

- **Modern dark theme** with custom styling
- **Rounded borders** and custom button designs
- **Responsive layout** with minimum window size constraints
- **Color scheme:** Teal green (#066351) accent on dark background (#2a2e34)

## 🔒 Security Notes

⚠️ **Important:** This is a demonstration project. For production use, consider:
- Implementing proper password hashing (currently storing as integers)
- Adding encryption for sensitive data
- Implementing proper authentication and authorization
- Using secure connection strings (not hardcoded)
- Adding input sanitization to prevent SQL injection
- Implementing proper error logging

## 📝 Usage Example

1. **Register a new user:**
   - Open "Add New User" window
   - Enter username, email, and numeric password
   - Click "Add" button
   - Note the generated User ID from the database

2. **Deposit funds:**
   - Open "Transactions" window
   - Enter User ID, Visa Code, Password in the right panel
   - Enter deposit amount
   - Click "Deposit"

3. **Withdraw funds:**
   - Enter User ID, Visa Code, Password in the left panel
   - Enter withdrawal amount
   - Click "Withdraw"

## 🐛 Known Issues

- Password must be numeric (integer type)
- Visa code validation is not fully implemented in transaction operations
- No session management or user authentication flow
- Limited error handling for database connection issues

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is for educational purposes.

## 👨‍💻 Eng-ahmed-dev1
# Personal Tracker ![Dev](https://img.shields.io/badge/Developer-devAhmed-blue)
Developed as a personal finance tracking application using WPF and Entity Framework Core.
---

**Note:** Make sure SQL Server is running before launching the application.
