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

    // Draw the program's header
    DrawHeader();

    // Get the user's name
    GetUserName();
    
    // Draw the program's main menu
    DrawMainMenu();

    // Handle user main menu selection
    while (userMenuSelection != "3")
    {
        switch (userMenuSelection)
        {
            case "1": // Configure checkerboard
                ConfigureProgram();
                userMenuSelection = null;
                DrawHeader();
                DrawMainMenu();
                break;

            case "2": // Draw checkerboard
                DrawCheckerboard();
                userMenuSelection = null;
                DrawHeader();
                DrawMainMenu();
                break;

            case "3": // Exit program
                DrawHeader();
                Console.WriteLine("See you next time " + username + "! Exiting...");
                Console.WriteLine();
                Environment.Exit(0);
                break;
        }
    }
}

void DrawHeader() {
    
    // Clear the console
    Console.Clear();

    // Draw program header
    Console.WriteLine("*********************************");
    Console.WriteLine("* NOT YOUR AVERAGE CHECKERBOARD *");
    Console.WriteLine("*********************************");
    Console.WriteLine();
}

void GetUserName() {
    // Check for the user's name
    while ((username == null) || (username == "")) {  // note: checking for "" as well, as Enter seems to be registered as a breakline character of sorts
        Console.WriteLine("Before we continue. What's your name?");
        username = Console.ReadLine().ToUpper();
    }

    // Applying received input to console output, providing a different greeting depending on the provided name
    DrawHeader();
    if (username == "Patrick") {
        Console.Write("Howdy " + username + "!");
    }
    else if (username == "Niels") {
        Console.Write("Hi " + username + "! No snakes here please.");
    }
    else {
        Console.Write("Hi there " + username + "!");
    }    
}

void DrawMainMenu() {
    while ((userMenuSelection != "1") & (userMenuSelection != "2") & (userMenuSelection != "3")) {
        Console.WriteLine(" What do you want to do?");
        Console.WriteLine();
        Console.WriteLine("1. Configure my checkerboard");
        Console.WriteLine("2. Draw my checkerboard");
        Console.WriteLine("3. Exit");
        userMenuSelection = Console.ReadLine().ToUpper();
    }
}

void ConfigureProgram() {
    DrawHeader();
    Console.WriteLine("Configuring...");
    Console.WriteLine();
    
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
    while ((userMenuSelection != "A") & (userMenuSelection != "R")) {
        Console.WriteLine("Press A to accept, or R to configure again");
        userMenuSelection = Console.ReadLine().ToUpper();
    }

    switch (userMenuSelection) {
        case "A": // returning to main menu           
            userMenuSelection = null;
            break;
        case "R": // re-do configuration
            userMenuSelection = null;
            ConfigureProgram();
            break;
    }
}

// Draw checkerboard character by character, by looping through rows and columns 
void DrawCheckerboard () {

    DrawHeader();
    Console.WriteLine("Drawing your checkerboard...");
    Console.WriteLine();

    for (int i = 0; i < noOfRows; i++) {
        for (int j = 0; j < noOfCols; j++) {

            // If random color is required, change console text color
            if (randomColor == "Y") {
                Random r = new Random();
                Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                Console.BackgroundColor = (ConsoleColor)r.Next(0, 16);
            }

            // Switch character after each newly drawn character
            if (switchChar == false) {
                Console.Write(char1);
                switchChar = true;
            } else {
                Console.Write(char2);
                switchChar = false;
            }

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