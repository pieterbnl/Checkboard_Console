// *****************************************************************************************
// Part 1. Make a simple console app. Make it say what you want.
// *****************************************************************************************

// Printing introductory console output
Console.WriteLine("**********************");
Console.WriteLine("Draw me a checkerboard");
Console.WriteLine("**********************");
Console.WriteLine();

// *****************************************************************************************
// Part 2. Make it accept user input and have it print out something based on that input.
// *****************************************************************************************

// Setting variables
string username = null;
string char1 = "X";
string char2 = "O";
int noOfRows = 5;
int noOfCols = 5;
string drawFast = "F";
bool swithChar = false;
bool randomColor = true;

/*// Receiving & checking user console input
Console.WriteLine("Before we start. What's your name?");
username = Console.ReadLine();

while (username == "")
{  // note: checking for "" rather than null, as Enter seems to be registered as a breakline character of sorts
    Console.WriteLine("Before we can continue, please enter your name.");
    username = Console.ReadLine();
}

// Applying received input to console output, providing a different output for some specific names
Console.WriteLine();
if (username == "Patrick")
{
    Console.WriteLine("Howdy " + username);
}
else if (username == "Niels")
{
    Console.WriteLine("Hi " + username + ". No snakes please.");
}
else
{
    Console.WriteLine("Hi there " + username);
}


// *****************************************************************************************
// Part 3: Make a checkerboard in the console, using nested for loops.
// *****************************************************************************************
*//* 
With, additionally:
- allow the user to select the characters for the checkerboard
- allow the user input the number of rows and columns
- add a coloring scheme to the output
- check for (in)valid input 

And as bonus:
- implement a selection menu
- refacture your code, taking in account SOLID principles *//*

Console.WriteLine();
Console.WriteLine("Before drawing our checkboard. Some questions.");
Console.WriteLine("What character do you want to use as character 1?");
char1 = Console.ReadLine();
Console.WriteLine("What character do you want to use as character 2?");
char2 = Console.ReadLine();
Console.WriteLine("Number of columns?");
noOfCols = int.Parse(Console.ReadLine());
Console.WriteLine("Number of rows?");
noOfRows = int.Parse(Console.ReadLine());

// Check if checkboard must be drawn fast or slow
// And as long user does not provide correct input, keep asking
while (drawFast != "F" && drawFast != "S")
{
    Console.WriteLine("Draw checkboard fast (F), or slow (S)");
    drawFast = Console.ReadLine();

    switch (drawFast)
    {
        case "F":
            drawFast = "F";
            break;
        case "S":
            drawFast = "S";
            break;
        default:
            drawFast = null;
            break;
    }
}
Console.WriteLine();*/

//drawFast = "F";
Console.WriteLine("Your input: ");
Console.WriteLine("Char1: " + char1);
Console.WriteLine("Char2: " + char2);
Console.WriteLine("Rows: " + noOfRows);
Console.WriteLine("Cols: " + noOfCols);
Console.WriteLine("Fast draw: " + drawFast);
Console.WriteLine("Random color: " + randomColor);

// Draw checkerboard character by character, by looping through rows and columns 
for (int i = 0; i < noOfRows; i++)
{
    for (int j = 0; j < noOfCols; j++) {

        // If random color is required, change console text color
        if (randomColor = true) {
            Random r = new Random();
            Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
            Console.BackgroundColor = (ConsoleColor)r.Next(0, 16);
        }

        // Switch character after each newly drawn character
        if (swithChar == false)
        {
            Console.Write(char1);
            swithChar = true;
        }
        else
        {
            Console.Write(char2);
            swithChar = false;
        }

        // Inititate a delay to 'draw' the checkerboard fast or slow
        if (drawFast == "S") { // slow draw
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        } 
        else // fast draw
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(1));
        }        
    }

    // Set colors back to normal
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;

    Console.WriteLine();

}