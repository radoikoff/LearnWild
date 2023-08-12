# LearnWild
A simple learning web application project part of SoftUni ASP.NET Advanced course Jun 2023.

## Overview
Visitors can open a catalog of courses, some free some paid. They can search courses by diffrent criteria. 

When user is logged in as **Student**, they can apply for a free course or can add a paid course to their shopping cart. Once enrolled for a course they can see course details, topics and download resources.

**Teachers** can create courses, topics, resources. Can manage enrolled students, assign them scores and marks. Teachers can also apply for courses of other teachers.

The application supports three types of roles: <kbd>Student</kbd>, <kbd>Teacher</kbd> and <kbd>Admin</kbd> .

### Setup
Just make sure you execute all DB migration on the database, then run the application.

### Predefined users
- username: **kenobi@learn.com**, pass: **123456**, role: **Teacher**
- username: **vader@learn.com**, pass: **123456**, role: **Teacher**
- username: **student@learn.com**, pass: **123456**, role: **Student**

Newly registered users are **Students** by default.
