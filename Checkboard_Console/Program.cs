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
int noOfRows = 10;
int noOfCols = 10;
string drawFast = null;
bool swithChar = false;

// Receiving & checking user console input
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
/* 
With, additionally:
- allow the user to select the characters for the checkerboard
- allow the user input the number of rows and columns
- add a coloring scheme to the output
- check for (in)valid input 

And as bonus:
- implement a selection menu
- refacture your code, taking in account SOLID principles */

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
Console.WriteLine();

//drawFast = "F";
Console.WriteLine("Your input: ");
Console.WriteLine("Char1: " + char1);
Console.WriteLine("Char2: " + char2);
Console.WriteLine("Rows: " + noOfRows);
Console.WriteLine("Cols: " + noOfCols);
Console.WriteLine("Fast draw: " + drawFast);

for (int i = 0; i < noOfRows; i++)
{
    for (int j = 0; j < noOfCols; j++) {
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
    }
    Console.WriteLine();
}