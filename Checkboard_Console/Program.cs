// *****************************************************************************************
// Part 1. Make a simple console app. Make it say what you want.
// *****************************************************************************************

// *****************************************************************************************
// Part 2. Make it accept user input and have it print out something based on that input.
// *****************************************************************************************

// *****************************************************************************************
// Part 3: Make a checkerboard in the console, using nested for loops.
// *****************************************************************************************
/* 
With, additionally:
- allow the user to select the characters for the checkerboard
- allow the user input the number of rows and columns
- add a coloring scheme to the output
- check for (in)valid input 

And as bonus:
- implement a selection menu
- refacture your code, taking in account SOLID principles */


// Setting variables
string username = null;             // for registering the user's name
string userMenuSelection = null;    // for registering the user's menu selections
string char1 = "X";                 // sets character 1 of the checkerboard
string char2 = "O";                 // sets character 2 of the checkerboard
int noOfRows = 5;                   // sets no. of rows of the checkerboard
int noOfCols = 5;                   // sets no. of colums of the checkerboard
string drawFast = "F";              // sets fast ("F) or slow ("S") drawing of the checkerboard
string randomColor = "N";          // sets if checkerboard must be drawn in random colors ("Y") or standard ("N")
bool switchChar = false;            // used for switching between drawing char1 or char2 when being drawn

// Start the program
InitiateProgram();

void InitiateProgram() {    

    // Draw program's header
    DrawHeader();

    // Get user's name
    GetUserName();    
           
    // Draw program's menu
    DrawMainMenu();    
}

void DrawHeader() {

    // Clear console and draw the program's header
    Console.Clear();
    Console.WriteLine("*********************************");
    Console.WriteLine("* NOT YOUR AVERAGE CHECKERBOARD *");
    Console.WriteLine("*********************************");
    Console.WriteLine();
}

void GetUserName() {
    
    // Check user's name    
    while (username == null) {  
        Console.WriteLine("Before we continue. What's your name?");
        username = Console.ReadLine().ToUpper();
    }
}

void GreetUser() {

    // Applying received name input to console output
    // Providing a different greeting depending on the name
    if (username == "PATRICK")
    {
        Console.Write("Howdy " + username + "!");
    }
    else if (username == "NIELS")
    {
        Console.Write("Hi " + username + "! No snakes here please.");
    }
    else
    {
        Console.Write("Hi there " + username + "!");
    }
}

void DrawMainMenu() {

    // (Re-)Draw main menu, while user does not provide an acceptable menu selection
    // Note use of short circuit-evaluation
    // Are brackets here according c# coding convention, or may they be left out?
    while ((userMenuSelection != "1") && (userMenuSelection != "2") && (userMenuSelection != "3")) {        
        DrawHeader();
        GreetUser();
        Console.WriteLine(" What do you want to do?");
        Console.WriteLine();
        Console.WriteLine("1. Configure my checkerboard");
        Console.WriteLine("2. Draw my checkerboard");
        Console.WriteLine("3. Exit");
        userMenuSelection = Console.ReadLine().ToUpper();
    }

    // Handle the user's menu selection
    switch (userMenuSelection)
    {
        case "1": // Configure checkerboard
            SetConfiguration();
            ConfirmConfiguration();
            userMenuSelection = null;
            DrawMainMenu();
            break;

        case "2": // Draw checkerboard
            DrawCheckerboard();
            userMenuSelection = null;
            DrawMainMenu();
            break;

        case "3": // Exit program                
            DrawHeader();
            Console.WriteLine("See you next time " + username + "! Exiting now...\r\n\n");
            Environment.Exit(0);
            break;
    }
}

void SetConfiguration() {

    // Redraw header and make clear to user that he's now configuring
    DrawHeader();
    Console.WriteLine("Configuring...");
    Console.WriteLine();
    
    // Ask user for configuration input (note: purposely not checks on input incorporated)
    Console.WriteLine("What character do you want to use as character 1?");
    char1 = Console.ReadLine().ToUpper();
    Console.WriteLine("What character do you want to use as character 2?");
    char2 = Console.ReadLine().ToUpper();
    Console.WriteLine("Number of columns?");
    noOfCols = int.Parse(Console.ReadLine().ToUpper()); 
    Console.WriteLine("Number of rows?");
    noOfRows = int.Parse(Console.ReadLine().ToUpper()); 

    // Check if checkboard must be drawn in random colors or not
    randomColor = null;
    while ((randomColor != "Y") && (randomColor != "N")) {
        Console.WriteLine("Draw checkboard in random colors (Y) or not (N)?");
        randomColor = Console.ReadLine().ToUpper();
    }
   
    // Check if checkboard must be drawn fast or slow
    drawFast = null;
    while ((drawFast != "F") && (drawFast != "S")) {        
        Console.WriteLine("Draw checkboard fast (F), or slow (S)");
        drawFast = Console.ReadLine().ToUpper();
    }
}

void ConfirmConfiguration()
{
    // Show configuration results
    DrawHeader();
    Console.WriteLine("Done! Configuration set as following: ");
    Console.WriteLine();
    Console.WriteLine("Char1: " + char1);
    Console.WriteLine("Char2: " + char2);
    Console.WriteLine("Rows: " + noOfRows);
    Console.WriteLine("Cols: " + noOfCols);
    Console.WriteLine("Fast draw: " + drawFast);
    Console.WriteLine("Random color: " + randomColor);
    Console.WriteLine();

    // Ask user for confirmation
    while ((userMenuSelection != "A") & (userMenuSelection != "R"))
    {
        Console.WriteLine("Press A to accept, or R to configure again");
        userMenuSelection = Console.ReadLine().ToUpper();
    }

    switch (userMenuSelection)
    {
        case "A": // returning to main menu           
            userMenuSelection = null;
            break;
        case "R": // re-do configuration
            userMenuSelection = null;
            SetConfiguration();
            break;
    }
}

// Draw checkerboard character by character, by looping through rows and columns 
void DrawCheckerboard () {

    // Redraw header and inform user that his checkerboard will now be drawn
    DrawHeader();
    Console.WriteLine("Drawing your checkerboard...");
    Console.WriteLine();

    // Loop through each column and line and draw required character
    for (int i = 0; i < noOfRows; i++) {
        for (int j = 0; j < noOfCols; j++) {

            // If random color is required, change console text color
            if (randomColor == "Y") {
                Random r = new Random();
                Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                Console.BackgroundColor = (ConsoleColor)r.Next(0, 16);
            }

            // Switch character after each newly drawn character
            if (switchChar == false)
            {
                Console.Write(char1);
                switchChar = true;
            }
            else
            {
                Console.Write(char2);
                switchChar = false;
            }

            /*// Alternative with use of modulu 
            if (j % 2 == 0) Console.Write(char1); else Console.Write(char2);

            // Alternative with use of modulu, as a single line ternary operator
            // CHECK
            //j % 2 == 0 ? Console.Write(char1) : Console.Write(char2);*/

            // Inititate a delay to 'draw' the checkerboard fast or slow
            if (drawFast == "S") { // slow draw
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            } else { // fast draw
                Thread.Sleep(TimeSpan.FromMilliseconds(5));
            }
        }
        Console.WriteLine();
    }

    // Set console colors back to normal
    Console.ResetColor();
    // Console.ForegroundColor = ConsoleColor.White;
    // Console.BackgroundColor = ConsoleColor.Black;

    // Pause to ask the user what he wants to do
    while ((userMenuSelection != "Q") & (userMenuSelection != "R")) {
        Console.WriteLine();
        Console.WriteLine("How do you like your great and fantastic personalized checkerboard?");        
        Console.WriteLine("Press R to redraw or Q to return to the main menu");
        userMenuSelection = Console.ReadLine().ToUpper();
    }

    switch (userMenuSelection) {
        case "Q": // returning to main menu
            //userMenuSelection = null;
            break;
        case "R": // redraw checkerboard
            userMenuSelection = null;
            DrawHeader();
            DrawCheckerboard();
            userMenuSelection = null;           
            break;
    }
}