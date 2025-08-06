# Library Management System Project

## 📌 Project Overview

The **Library Management System** is a comprehensive web-based application designed to streamline and manage various library operations such as managing books, book categories, users, members, and announcements. Through this system, users can register via the **Register** page and are redirected to the panel upon successful registration. 

There are three types of users in the system:
- **Admin**
- **Moderator**
- **Regular User**

While Admins and Moderators have access to the full system, Regular Users are limited to a subset of functionalities.

With this management panel, you can issue and return books, monitor user activities, track book transactions, and observe book registration logs in the database. For instance, when a user logs into the system, a log entry like "User XXX has logged in" is added to the user activity records.

## 🔄 Stock Management via Triggers

A **Trigger** structure has been used to automatically manage book stock levels. When a book is borrowed, the stock decreases; when it is returned, the stock updates accordingly — all managed automatically at the database level.

## 💻 Technologies Used

- **ASP.NET MVC**
- **MS SQL Server**
- **Entity Framework (Code First)**
- **Generic Repository Pattern**
- **HTML / CSS / JavaScript**
- **AJAX**
- **Bootstrap**
- **SweetAlert**
- **FluentValidation**
- **SQL Triggers**

## 🚀 Highlighted Features

-  Full CRUD operations on books, users, announcements, and categories
-  Role-based access control with Admin, Moderator, and User levels
-  Entity Framework Code First for database operations
-  "Forgot Password" functionality with secure password update
-  AJAX-based dynamic announcement management
-  SweetAlert integration for user-friendly notifications
-  Book category search functionality
-  Pagination support for managing large datasets
-  Ability to assign and manage user roles from the admin panel
-  Bulk deletion support on the announcements page
-  Full visibility into:
  - User login activities
  - Book issue/return actions
  - Book registration logs
- Export user and book activity logs to Excel for external analysis  
- Print-friendly views for logs and reports 
- FluentValidation for cleaner and more robust form validation

---

This project is a great example of combining front-end interactivity with a secure and well-structured back-end. It demonstrates how a modern library system can be built using ASP.NET MVC, while integrating clean design and powerful server-side logic.

## Images of Project

### Home Page
<img width="1755" height="1383" alt="image" src="https://github.com/user-attachments/assets/876e7958-db09-4bd6-88b6-c45450b2cc9d" />

### Books Page
<img width="1755" height="2091" alt="image" src="https://github.com/user-attachments/assets/3af42849-2a0b-4f9d-ade5-8919000c35c6" />

### About Us Page
<img width="1755" height="1581" alt="image" src="https://github.com/user-attachments/assets/2f87dc80-4643-4ce9-825c-3ab92aa3c17e" />

### Contacts Page
<img width="1755" height="1025" alt="image" src="https://github.com/user-attachments/assets/99dc5644-290a-46a1-958a-60be19764dd8" />

### Database Diagram
<img width="1581" height="930" alt="image" src="https://github.com/user-attachments/assets/2982ffa3-4c5f-4041-a524-190d49978114" />

### Login Page
<img width="1908" height="972" alt="image" src="https://github.com/user-attachments/assets/bc841bf0-6293-474e-8576-5ad37e586536" />

### Forgot Password Page
<img width="1892" height="823" alt="image" src="https://github.com/user-attachments/assets/3e91073d-94f5-414c-bbd5-b1278751a7b5" />

### Signup Page
<img width="1904" height="1038" alt="image" src="https://github.com/user-attachments/assets/28de9981-a7b9-4371-b200-e6450d18f7c0" />

### Dashboard Page
<img width="2428" height="1887" alt="image" src="https://github.com/user-attachments/assets/c901be46-82be-4574-b984-9c1dd9c62e72" />

### Book Genre Page
<img width="1884" height="910" alt="image" src="https://github.com/user-attachments/assets/ac5d591c-1fef-4069-82fa-6cc311c9a422" />

### Books Page
<img width="1876" height="999" alt="image" src="https://github.com/user-attachments/assets/58ef7a63-8aa5-4744-9635-6d80f0efea60" />

### Book Detail Page
<img width="1892" height="987" alt="image" src="https://github.com/user-attachments/assets/76afa3ab-1f5d-436b-ba5f-e683c37d0e7c" />

### Borrow Book Page
<img width="1889" height="855" alt="image" src="https://github.com/user-attachments/assets/65175158-ab46-4290-ac85-1aa13f8a6cf2" />

### Excel and Print View
<img width="1055" height="284" alt="image" src="https://github.com/user-attachments/assets/435dd419-d55a-4fc6-97b7-d01c239f9cfc" /> <img width="993" height="382" alt="image" src="https://github.com/user-attachments/assets/c4a4a2e0-ada0-4761-8ed9-1b0588776395" />

### Announcements Page- Updating Announcements
<img width="1899" height="707" alt="image" src="https://github.com/user-attachments/assets/88af5919-ef39-4971-841b-af3af7743aa6" />

### Announcements Page- Deleting Multiple Records
<img width="1895" height="934" alt="image" src="https://github.com/user-attachments/assets/8af5baac-566d-46dc-98f8-608f2459338d" />

### Users Page
<img width="1886" height="1020" alt="image" src="https://github.com/user-attachments/assets/4c854f1d-35ba-412e-9b5a-2e68373a1538" />

### Add Users - Validation
<img width="1890" height="1043" alt="image" src="https://github.com/user-attachments/assets/a2ff29c9-7bef-4ff7-b1d1-e10c765b38ed" />

### Members Page
<img width="1890" height="836" alt="image" src="https://github.com/user-attachments/assets/84e1f78d-7fe3-4d15-a2a2-35d8042139ea" />

### User Logging
<img width="964" height="255" alt="image" src="https://github.com/user-attachments/assets/4d92dfc3-38a1-4415-a774-aa34da55b83b" />

### Borrow Book Logging
<img width="1127" height="137" alt="image" src="https://github.com/user-attachments/assets/698fd3fd-86f0-46aa-ba11-3cc928ecb377" />









