/*
Minimum Absolute difference in an array
Codility Lesson 3, Q3: Tape Equilibrium
*/

function solution(A){
    const totalSum = A.reduce((a,b) => a + b, 0); // using the reduce function to add together all elements in array A
    leftSum = 0;
    rightSum = 0;

    minDifference = Number.MAX_VALUE;

    for (P = 1 ; P < A.length ; P++){ // loop through all possible P (split) points, after first element and inc before the last element
        leftSum += A[P-1]; // add together sum of prev elements before split
        rightSum = totalSum - leftSum; // add together sum of following elements after split

        absDifference = Math.abs(leftSum - rightSum); // calc absolute delta between left and right splits
        minDifference = Math.min(minDifference, absDifference); // update the minimum 
    }
    
    return minDifference;
}

//test initialisation
const A = [3, 1, 2, 4, 3];

console.log(solution(A));