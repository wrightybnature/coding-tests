// Colidility L3: Time complexity
// 1 - Frog Jump

using System;

class FrogJump() {

    public int solution(int x, int y, int d){
        return (int)Math.Ceiling(((double)(y-x))/d);
    }
}

// Initialisation
int x = 10;
int y = 50;
int d = 15;

var frogJump = new FrogJump();
Console.WriteLine(frogJump.solution(x, y, d));

/*
Explanation

y - x = 50 - 10 = 40        This is the difference between them, aka the amount we need from x to get to y
(double)(40 / 15)           Convert to double so we get decimal places when dividing
40.00 / 15.00 = 2.67        How many times 15 fits into 40 (how many  frog jumps we need)
Math.Ceiling(2.67) = 3.00   Rounds up to the nearest full number, because we can't split one frog jump so we need the full jump
return int(3.00) = 3               We need to return the value as an int as specified by the question
*/