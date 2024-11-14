// Codility L3: Time Complexity 
// 2 - Permutation Missing Element

using System;

class MissingNum() {
    public int solution(int [] A) {
        int N = A.Length +1;
        int sum = N*(N+1)/2; // formula for the first N natural numbers
        int arraySum = 0;

        for (int i = 0; i < A.Length; i ++) {
            arraySum += A[i];
        }

        return (sum-arraySum);
    }
}

// Initialisation
int[] A = [4, 3, 5, 6, 2, 1, 8, 9]; // 7 is missing
MissingNum MissingNumber = new MissingNum();
Console.WriteLine(MissingNumber.solution(A));

/*
Explanation
We are given an unordered array that contains a list of numbers (from 1 to N+1) where 1 number is missing.
We need to find the missing number.

If the array is a list of incrementing numbers from 1 to N+1, then we can add them up to get 'arraySum'
If we add up the numbers from 1 to the length of the array (9), which can be done using the formula for first N natural numbers, we get 'sum'
We can find the difference between the two to get the missing number, as the missing number's value hasn't been added in 'arraySum'

We could replace the formula for the first N natural numbers with a for loop to count them up for the length of the array but it's less efficient
*/
