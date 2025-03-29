# Employee Management System (EMS)

## Overview
The Employee Management System (EMS) is a C# console-based application designed to manage employee records, departments, performance reviews, and generate reports. It provides a user-friendly, menu-driven interface for HR and management to efficiently handle employee-related operations.

## Features
- **Employee Management**: Add, promote, transfer, terminate, and view employees (active, top, or terminated).
- **Department Management**: Create departments, assign department heads, and list departments with their employees.
- **Performance & Promotions**: Assign performance ratings and promote employees based on ratings.
- **Reports & Analytics**:
  - All departments with their heads.
  - Employees by department.
  - All active employees.
  - Top performers (rated above Average).
  - Terminated employees.
- **User Interface**: Console-based with color-coded outputs and input validation.

## Prerequisites
- .NET Framework or .NET Core (compatible with the C# version used in the project; recommended .NET 6.0 or later).
- A C# IDE (e.g., Visual Studio, Visual Studio Code with C# extension).
- Git (optional, for cloning the repository).

## Installation
### Clone the Repository
```bash
git clone https://github.com/nadasae/EmployeeManagementSystem.git
```

### Navigate to the Project Directory
```bash
cd EmployeeManagementSystem
```

### Open in IDE
- Open the `.sln` file (if provided) in Visual Studio.
- Alternatively, open the folder in VS Code.

### Build the Project
- **In Visual Studio**: Click `Build > Build Solution`.
- **In terminal (VS Code)**: Run:
  ```bash
  dotnet build
  ```

### Run the Application
- **In Visual Studio**: Press `F5` or click `Start`.
- **In terminal**: Run:
  ```bash
  dotnet run
  ```

## Usage
### Launch the Program
The application starts with the Main Menu.

### Navigate Menus
#### Main Menu:
1. Department Operations
2. Employee Operations
3. Generate Report
4. Exit

#### Department Operations:
- Add departments, assign heads, and view department details.

#### Employee Operations:
- Add, promote, transfer, terminate employees, and view lists.

### Input Handling
- Enter numbers or text as prompted.
- Type `CANCEL` (case-insensitive) to abort any operation.

### Reports
- Select `Generate Report` to view a comprehensive overview of the company’s data.

## Example
```
Enter your choice: 2
EMPLOYEE OPERATIONS
1. Add Employee
Enter Employee Name: John Doe
Enter Employee Age: 30
Enter Employee Salary: 60000
Enter Employee Department: IT
Choose The Position Level: 3 (senior)
Employee added successfully!
```

## Project Structure
- **Core Classes**: `Company`, `Department`, `Employee`, `PerformanceReview`.
- **Enums**: `PositionLevel`, `Rating`.
- **Utility Classes**: `ReadFromUser`, `CompanyOperations`.
- **Menus**: `MainMenu`, `EmployeeMenu`, `DepartmentMenu`.
- **Operations**: `EmployeeOperations`, `DepartmentOperations`.
- **Entry Point**: `Program.cs`.

## Contributing
We welcome contributions! To contribute:
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature
   ```
3. Make your changes and commit:
   ```bash
   git commit -m "Add your message"
   ```
4. Push to your branch:
   ```bash
   git push origin feature/your-feature
   ```
5. Open a Pull Request.

Please ensure your code follows the project’s coding standards (OOP principles, meaningful naming, exception handling).

## Team
- **Mostafa Ahmed Mohamed Rasheedy** (Team Leader)
- **Abdelrahman Ahmed Eltairy Ali**
- **Nada Saeed Beshary Mohamed**
- **Mina Ashraf Moawad Suliman**

## License
This project is open-source and available under the [Insert License Here]. (Note: Add a LICENSE file if you choose a specific license.)

## Acknowledgments
- Built with C# and the .NET ecosystem.
- Developed collaboratively using GitHub for version control.

