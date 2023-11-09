# Cash-It-Bank User Guide

Welcome to Cash-It-Bank, your go-to web application for a seamless and secure banking experience. This guide provides an overview of the app's functionalities and usage.

## Table of Contents

1. **Getting Started**
   - [Accessing the Application](#accessing-the-application)
   - [User Roles](#user-roles)

2. **Navigation**
   - [Home](#home)
   - [Accounts](#accounts)
   - [Profile](#profile)
   - [Registration](#registration)
   - [Role Management](#role-management)

3. **Viewing and Editing Accounts**
   - [Account Summary](#account-summary)
   - [Account Details](#account-details)
   - [Editing Account Information](#editing-account-information)

4. **Technical Details**
   - [Database Structure](#database-structure)
   - [Code Implementation](#code-implementation)

## Getting Started

### Accessing the Application

Visit the [Cash-It-Bank Website](https://banksystem.azurewebsites.net/) to access the application. If you're an admin, log in using the provided credentials. For other users, complete the registration process to create your account.

### User Roles

- **Admins:** Have access to all features, including role management.
- **Authenticated Users:** Can view their account details and perform necessary transactions.

## Navigation

### Home

The home page is the starting point, providing an overview for admins. Use the dropdown to filter accounts by type ('All', 'Chequing', or 'Savings').

### Accounts

View all accounts based on the selected type. Click on the detail link to access specific account information.

### Profile

For authenticated users, the profile page displays personal account details. Non-admin users are redirected here upon login.

### Registration

New users must register by selecting an account type and providing valid information.

### Role Management

Admin-exclusive access to assign roles to users.

## Viewing and Editing Accounts

### Account Summary

The Accounts/Index page displays a summary of accounts based on the chosen type. The title indicates the type of summary, and accounts are sorted by Last Name.

### Account Details

Access detailed information about a specific account by clicking on the detail link.

### Editing Account Information

Admins can edit Last Name, First Name, and Balance on the Accounts/Edit page. Ensure all enabled fields are not empty, and validation rules are followed.

## Technical Details

### Database Structure

Cash-It-Bank utilizes a Code First approach with an SQLite database located in the wwwroot folder. Primary and foreign keys are implemented following best practices.

### Code Implementation

The application leverages .NET Core components, including the Identity framework. View models and repositories enhance data retrieval and maintain a clean, organized codebase.
