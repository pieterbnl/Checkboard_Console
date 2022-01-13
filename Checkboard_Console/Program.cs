// *****************************************************************************************
// Part 1. Make a simple console app. Make it say what you want.
// *****************************************************************************************

// Printing some initial console output
Console.WriteLine("**********************");
Console.WriteLine("Draw me a checkerboard");
Console.WriteLine("**********************");
Console.WriteLine();

// *****************************************************************************************
// Part 2. Make it accept user input and have it print out something based on that input.
// *****************************************************************************************

// Setting some variables
string username = null;

// Receiving and checking user console input
Console.WriteLine("Before we start. What's your name?");
username = Console.ReadLine();

while (username == ""){  // note: checking for "" rather than null, as Enter seems to be registered as a breakline input
    Console.WriteLine("Before we can continue, please enter your name.");        
    username = Console.ReadLine();
}

// Applying the received input in console output
// And providing a different output for some specific names
Console.WriteLine();
if (username == "Patrick")
{
    Console.WriteLine("Howdy " + username);
} else if (username == "Niels")
{
    Console.WriteLine("Hi " + username + ". No snakes please.");
} else
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
