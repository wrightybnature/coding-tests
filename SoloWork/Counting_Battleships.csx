/* 
This code counts the number of battleships in a given bollean array.

Originally, the array was given as strings containing either "#" if a ship was present in a cell or "." if the cell was empty
To optimise parsing through the array, this was converted into a boolean array

There are 3 ships that can be found: patrol boats, submarines and destroyers.
1: Patrol boats - one cell
2: Submarines - two cells oriented horizontally or vertically
3: Destroyers - three cells either in a row horizontally/vertically, or, arranged in an L shape
*/

using System;

// convert to bool 2d array makes life a ton easier
bool[,] board = ConvertStringBoardTo2D();

int numP = 0;
int numS = 0;
int numD = 0;

// check all squares on the board for potential ships
for (int x = 0; x < board.GetLength(0); x++)
{
    for (int y = 0; y < board.GetLength(1); y++) // for every y in x - for every row in every column
    {
        int numShipTiles = 0;
        GetShipType(ref numShipTiles, x, y);

        // if statements to check which type of ship we have detected
        if (numShipTiles == 1)
        {
            numP++;
        }
        if (numShipTiles == 2)
        {
            numS++;
        }
        if (numShipTiles == 3)
        {
            numD++;
        }
    }
}

int total = numP + numS + numD;
Console.WriteLine("Total number of ships: " + total);
Console.WriteLine($"Patrol Boats: {numP}, Submarines: {numS}, Destroyers: {numD}");

void GetShipType(ref int validNumCoords, int coordX, int coordY)
{
    if (!InBounds(coordX, coordY))
    {
        return;
    }
    // if this coord is a ship then
    if (board[coordX, coordY] == true)
    {
        validNumCoords++; // increment valid counter

        // we've checked this tile already, set it to false to prevent
        // the next coordinate check from catching this ship again
        board[coordX, coordY] = false;

        // check neighbours recursively by calling the function again
        GetShipType(ref validNumCoords, coordX - 1, coordY); // left
        GetShipType(ref validNumCoords, coordX + 1, coordY); // right
        GetShipType(ref validNumCoords, coordX, coordY - 1); // above
        GetShipType(ref validNumCoords, coordX, coordY + 1); // below
    }

}
bool InBounds(int x, int y) // method to check that ship is in bounds of array
{
    if (x < 0 || y < 0)
    {
        return false;
    }
    if (x > board.GetLength(0) - 1 || y > board.GetLength(1) - 1)
    {
        return false;
    }
    return true;
}

bool[,] ConvertStringBoardTo2D()
{
    // example board
    return new bool[,]
    {
        { false, false, false, false, false, false, false,  true, false, false },
        { false,  true, false, false,  true,  true, false,  true, false, false },
        { false, false,  true, false,  true, false, false, false,  true, false },
        { false,  true, false, false, false, false, false,  true, false, false },
        { false,  true, false,  true,  true,  true, false,  true, false, false },
        { false,  true, false, false, false, false, false, false, false, false },
        {  true, false, false, false,  true,  true, false,  true,  true, false },
        { false, false, false, false, false,  true, false, false, false, false },
        { false, false, false, false, false, false, false,  true,  true, false },
        {  true, false,  true,  true, false, false, false, false,  true, false }
    };
}
