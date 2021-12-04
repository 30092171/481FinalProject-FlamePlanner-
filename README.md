# 481FinalProject-FlamePlanner-
flame planner project

CPSC 481 Final Project Fall 2021
University of Calgary
Group 20:
	Nick Zhao  	(30092171)
	Austin Shawaga  (30086103)
	Jason Nguyen	(30085909)
	Abhay Sharma	(30095410)
	Xingyu Zhu	(30095123)


Compilation:
	Open the solution "481FinalProject-FlamePlanner-.sln" in VS Code
	Click the Start FlamePlanner button in the top of the screen once the project is loaded

Dependency issue:
	Should you have an issue with the "MaterialDesignColors" dependency unzip the submitted zip file "MaterialDesignColors.zip"
	into the dirrectory C:\Users\%user%\.nuget\packages\
	You might have to create the '.nuget' and 'packages' folders.

------------------
Code Limitations

These are what fields can be entered for each screen.
	Map Screen:
		Location Search: When 'go' is clicked, automatically goes to smaller, more detailed map (9 Ave SW)
		Event Search:
			"Stampede"
			"Wine Tasting"
			"Eau Claire"
	Event Screen:
		Search:
			"wine"
			"calgary flames"
		Date:
			2021/09/12 - 2021/09/18 (This range will trigger the screen to switch)

List of Clickable Events
	Eric Nam Before We Begin World Tour
	Calgary Stampede Highlight Party
	Halloween Thriller
	Calgary Flames Game
	CAVS vs PACIFIC
	Boxing Bootcamp
	Wine Tasting Event
	Cocktail Class
	Chef's Table Dinner
	Wine U: Premium Wines!
	Yonex Canada Open
	Glass Fusion 101
	Startup Job Fair Online
	Tim & The Glory Boys

Things it can't do:
	Schedule Event over two or more days (this must be done by creating two seperate events)
	Itinerary only acts over 4 weeks Sep 5 until Oct 2. Assume the current date is Sep 5 2021.
	If you schedule an event outside of the date range, you will not see the event displayed intuitvely.
	Can't load itinerary from main screen due to the project not requiring persistant accounts across compilations
	If you click on an event/map icon that is not populated simply nothing will happen.

No fatal errors are known at this time, nothing you do should crash the system.
	
	
	
	