# Assignment-MENTORMATE
Application that checks meeting rooms’ schedules and finds open time slots that can be booked for meetings.
Assignment 1



Assignment 2 
Application that checks meeting rooms’ schedules and finds open time slots that can be booked for meetings.
Create an application that checks meeting rooms’ schedules and finds open time slots that can
be booked for meetings. The application should return all available slots for a given date that the
user can choose from.
The application should read the schedules of the rooms from a file. The file contains the
schedules, as well as information about the rooms. The following information is available for
each room:


**Application should**
* [x] The date for which to check for time slots.
* [x] Number of participants.
* [X] Meeting duration
* [x] The application should read the schedules of the rooms from a file. The file contains the
schedules, as well as information about the rooms. The following information is available for
each room:


**Guide how to set up the application**
Setting up the connectionstring



In order to use code-based migration, you need to execute the following commands in the Package Manager Console in Visual Studio:
Enable-Migrations: Enables the migration in your project by creating a Configuration class. 

Update-Database: Executes the last migration file created by the Add-Migration command and applies changes to the database schema.


**PostCategories**

"rooms/register-multiple"

This web method will push multiple categories roomName, capacity, availableFrom, availableTo, schedule in to the database.
It will not check any user license details.

Example:https://f.hubspotusercontent00.net/hubfs/211554/%5BBG%5D%20.NET%20Internship%20Tasks%20(2021)/Room%20Scheduled_JSON%20file.pdf



**GetCategories**

"rooms/availability"

This web method will return all the open time slots that can be booked for meetings.



Example:
{
    "CheckRoomDate": "2021-10-15",
    "Capacity": 8
}

