
//////////////////////////////////////////////////////////////// HOW TO BUILD and RUN SOLUTION  ////////////////////////////////////////////////////////////


1.	Restore database .bak file or run database script to destination server.
2.	Replace the connection string settings for server in MyHealthPlus solution
3.	Run the MyHealthPlus.sln

////////////////////////////////////////////////////////////////////// FUNCTIONALITIES //////////////////////////////////////////////////////////////////////

1.	There are 3 users provided.
      a.	User (username/password: jdelacruz)
      b.	Doctor (username/password: Doctor)
      c.	Staff (username/password: Staff)
2.	User can only access the scheduling of appointment
      a.	Scheduling of appointment, you may select the time range available for the date so that there would not be any duplication of schedule on same time.
3.	Doctor access lands on doctors schedule module
      a.	This is automatically filtered by date today but can be changed and filtered into other days.
      b.	Doctors can update status and comment once the appointment status is still ‘scheduled’.
      c.	For other status, doctor cannot update the appointment, but can view the details.
      d.	Doctors can also access users page. Users page is used to update a user’s role. All users must register first before access can be updated.
4.	Staff access lands on the scheduling of appointment
      a.	Staffs can access scheduling of appointment, in case the staff needs a schedule from him/herself
      b.	Staffs can also access doctors schedule module which also has all the doctor access functionality available.
      c.	Staffs can also access users page.


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
