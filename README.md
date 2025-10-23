**Pet Adoption Centre NZ**

Project Overview 

I have created a web-based application for easy Pet Adoption. Information regarding Pets and their status is logged in this web-site. To have a easy and user friendly interface, I have used Entity Framework Core MVC.

Repository Contents

 - Different Standards code is developed
 - Recorded on the challenges encountered and the process of resolving these issues.

Hardware Requirement

 - Windows 10 running Visual Studio 2022.NET 8.0 or above

Operating Guidelines

1. Replicate Repository
2. To set up database, run the "update-database" command in Package Manager Console in Visual Studio to apply migration to the Visual Studio SQL Server database.
3. Next, in Visual Studio we Build the solution. This enables the application to be launced.
4. The functionality of web application is developed for customers/admin to manage the Pet adoption process.
5. Users can assign pets to specific breeds and shelters upon creation and then choose to adopt them out or leave them for the next person who signs up an account with us.
6. Next is creating new records; Navigate Pet and click "Create New" to create a new pet or "Adopt" from the given list and pet status will automatically change.
7. Navigate to Breeds and click "Create New", this is optional, to allow a new breed into the shelters.
8. Same steps to be followed for the other two tables, Location and Shelters.


Note: As of now, Foreign Key ID fields will be changed in future to string fields, preferable dropdown, for better user experience

With the IDs if they are ceded in the database it will result in a foreign key constraint error. 

Due to a foreign key constraint error please only use these BreedIDs in Pets as well as these ShelterIDs
1 = Shit Tzu
3 = Dalmation
4 = German Shepard
5 = Labrador
6 = Poodle
7 = Pug
8 = Reaper
10 = Wissle
12 = Labe
13 = K9
16 = Corgi
17 = Labe
18 = Labe

1	= Happy Tails Shelter
2	= Paws and Claws Rescue
3	= Furry Friends Haven
5	= Wagging Tails Rescue
7	= Loving Arms Rescue
8	= Forever Home Shelter
9	= New Beginnings Rescue
10	= Airing Hearts ShelterMq
17	= kdok
22	= Atuls st Shelter
26	= Caring Hearts Shelter M
27	= msmlq
28	= msmlq
29	= msm1
32	= Caring Hearts Shelter M
33	= Atuls 1st Shelter


In Shelter when entering locationID due to the same error please only use these IDs
1 = Central City
2 = NorthSide
3 = East End
5 = Westfield


Shelter ID = Shelter Name = Location ID
1	= Happy Tails Shelter	= 1
2	= Paws and Claws Rescue	= 2
3	= Furry Friends Haven	= 2
5	= Wagging Tails Rescue	= 5
7	= Loving Arms Rescue	= 3
8	= Forever Home Shelter	= 2
9	= New Beginnings Rescue	= 1
10	= Airing Hearts ShelterMq	= 5
17	= kdok	= 5
22	= Atuls st Shelter	= 1
26	= Caring Hearts Shelter M	= 1
27	= msmlq	= 1
28	= msmlq	= 1
29	= msm1	= 1
32	= Caring Hearts Shelter M	= 1
33	= Atuls 1st Shelter	= 1

In 


Test Account 

uswr: lm@gmail.com
Password: Avcol@2028
