// Codility L1: Iterations
// 1 - Binary Gap 

using System;

class Solution() {
    public int solution(int N) {
        bool started = false;
        int length = 0;
        int maxLength = 0;

        string binary = Convert.ToString(N, 2);
        char[] binaryList = binary.ToCharArray();

        foreach (char c in binaryList) {
            if (c == '1') { // condition 1: we find the first 1 in the array, otherwise ignores all 0s
                if (started == true) { // if started is already true
                    maxLength = Math.Max(maxLength, length); // check the current length against the maxLength found so far and set it to the biggest value
                }
                
                started = true; // we set started to true because we found 1
                length = 0; // set or reset counter back to 0
            }
            else if (started) { // condition 2: we already started counting, so started = true
                length ++; // so we want to count how many 0s are in the array
            }
        }
    
        return maxLength;
    }
}

int N = 9;

Solution binaryGap = new Solution();
Console.WriteLine("Biggest binary gap found: " + binaryGap.solution(N));
