# 🎓 **ITI Final Project**

## 📋 **Overview**  
The ITI Final Project is a web application designed to manage various administrative tasks, including handling **Student** 👩‍🎓, **Department** 🏢, and **Course** 📚 data. The system allows admins to easily manage records, while students can view and update their information. Built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**, this project provides a user-friendly interface for educational administration.

## 🔑 **Key Features**

### 🔐 **User Registration & Authentication**  
- Users can register, log in, and manage their accounts securely.  
- The system supports role-based authentication for **students** 👨‍🎓 and **admins** 👨‍💻.

### 📝 **Course Management**  
- Admins can create, update, and delete course records.  
- Students can view available courses and their associated details.

### 🏫 **Department Management**  
- Admins can manage departments, including creating, updating, and deleting department records.  
- Students can view department information.

### 👩‍🏫 **Student Management**  
- Students can view their details, update their information, and manage their courses.  
- Admins can perform CRUD operations on student records.

### 🚨 **Error Handling & Logging**  
- Custom exception filters to handle errors globally across the application.  
- Logging features to track and monitor application activity.

### 📱 **Responsive Design**  
- The application is responsive, built with **Bootstrap** for an optimized user experience across devices.

## 💻 **Technologies Used**

- **ASP.NET Core MVC**: Web framework for building the application.  
- **Entity Framework Core**: ORM for database operations.  
- **SQL Server**: Backend database for storing application data.  
- **ASP.NET Identity**: Secure user authentication and authorization.  
- **Bootstrap**: Responsive front-end design framework.  
- **jQuery**: For dynamic content and interactions.

## 🎭 **Custom Action Filters**

- **Exception Filter**: Catches and handles exceptions across the application to provide a user-friendly error response.  
- **Logging Filter**: Records key events and actions within the application, ensuring easy monitoring and debugging.

## ✅ **Data Validation**  
- Custom validation attributes ensure that user inputs are consistent and meet the required format before being processed by the system.  
- **MyValidationAttribute**: Ensures that user-provided data (such as email 📧 or username) is valid according to custom rules.

## 📡 **Data Access Layer**  
- A repository pattern is used for accessing and manipulating data, ensuring that the application follows best practices for data management.  
- **Repository Interface & Implementation**: Provides a clean and maintainable way to interact with the database.

## 🎨 **Views and UI**  
- Rich user interface built with **Razor Pages** for dynamic content rendering.  
- **CRUD Operations** for **Student**, **Course**, **Department** entities with user-friendly forms.  
- Data validation shown directly on the frontend to improve the user experience and avoid unnecessary backend validation errors.

## 🔄 **Error Pages & Redirects**  
- **Error.cshtml**: Custom error page for handling and displaying meaningful error messages.  
- Redirect users to the appropriate pages after performing CRUD operations or when invalid actions are detected.

## 🚀 **Future Enhancements**  
- **User Profile Customization**: Allow students and admins to personalize their accounts and profile pages.  
- **Advanced Search & Filter Options**: Implement search features for students, courses, and departments with filtering capabilities to streamline management.
