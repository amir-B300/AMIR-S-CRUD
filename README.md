**Basic CRUD Application Using C# and Windows Forms**
**Overview**

This is a simple CRUD (Create, Read, Update, Delete) application built using C# and Windows Forms with Microsoft SQL Server as the database. The application provides a user-friendly interface to perform CRUD operations on user data, including email, name, username, and password.
**Demo Video**

**Features**
•	Create: Add new user records to the database.
•	Read: Display existing records in a DataGridView.
•	Update: Modify the details of an existing user.
•	Delete: Remove a user from the database.
**Tools and Technologies**
•	Programming Language: C#
•	Framework: .NET Framework (Windows Forms)
•	Database: Microsoft SQL Server
•	IDE: Visual Studio
**Getting Started**
**Prerequisites**
•	Visual Studio (with Windows Forms support)
•	Microsoft SQL Server
**Database Setup**
1.	Create a new SQL Server database.
2.	Use the provided SQL script to create the necessary tables:
**sql**
Copy code
CREATE TABLE crud (
    id INT PRIMARY KEY IDENTITY,
    EMAIL NVARCHAR(100),
    NAME NVARCHAR(100),
    USERNAME NVARCHAR(100),
    PASSWORD NVARCHAR(100)
);
3.	Update the connection string in the code to match your SQL Server instance:
csharp
Copy code
SqlConnection con = new SqlConnection("Data Source=YOUR_SERVER_NAME;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
**Installation and Running**
1.	Clone the repository:
bash
Copy code
git clone https://github.com/yourusername/your-repo-name.git
2.	Open the project in Visual Studio.
3.	Configure your database connection in the project (as mentioned above).
4.	Build and run the project.
**Code Breakdown**
1. Create Operation
The application allows users to create new records by entering values into text fields for email, name, username, and password. The button2_Click method is responsible for inserting the new record into the SQL Server database.
2. Read Operation
The button3_Click method retrieves all records from the crud table and displays them in a DataGridView for easy viewing. The UI toggles between showing the form inputs and displaying the data grid.
3. Update Operation
Users can modify existing records by selecting a user ID and editing the respective fields. The button4_Click method is used to update the record in the database.
4. Delete Operation
The button5_Click method allows the user to delete a record by specifying the ID of the record to be removed.
**Event Handling**
Each button in the application (Create, Read, Update, Delete) has its own event handler to execute the respective CRUD operations. For instance, when the "Create" button is clicked, the button2_Click method is executed to insert a new record into the database.
**Screenshots**
*Main Form*
![image](https://github.com/user-attachments/assets/f37c3aa8-610c-452a-aa90-0ed225a57f5d)

Form with buttons for Create, Read, Update, and Delete operations.
**DataGridView**
*DataGridView displaying all records.*
*Error Handling*
The application handles common errors such as:
•	Database connection errors.
•	Input validation (ensuring no fields are left empty).
•	Non-existent records during update or delete operations.
**Future Improvements**
•	Search Functionality: Add a search bar to filter records in the DataGridView.
•	Validation: Improve form validation for stronger input checks.
•	UI Enhancements: Improve the user interface design for better user experience.
