
/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)  
        {
            try
            {


                var b = 0;                  //initializing b
                var t = nums.Length - 1; //initiaizing t
                while (t - b >= 0)        //looping for number greater than 0
                {
                    var middle = (b + t) / 2;           //initializing the middle of the numbers given as middle

                    if (nums[middle] == target)             //looping to find the target and returing the index
                        return middle;
                    else if (nums[middle] > target)
                        t = middle - 1;
                    else if (nums[middle] < target)
                        b = middle + 1;

                }
                return b;

            }
            catch (Exception)
            {
                throw;
            }
        }

            /*

            Question 2

            Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
            The words in paragraph are case-insensitive and the answer should be returned in lowercase.
            Example 1:
            Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
            Output: "ball"
            Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
            Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
            Example 2:
            Input: paragraph = "a.", banned = []
            Output: "a"
            */

            public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                char[] delimiterChars = { ' ', ',', '.', ':', '?', ';', '"', ';' };   //Initializing all the delimiter characters in an array
                string[] line = paragraph.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);  //removing all the delimiters and empyt spaces from the given string
                Dictionary<string, int> dict = new Dictionary<string, int>();
                HashSet<string> bann = new HashSet<string>();
                string final = ""; //Initializing an empty string final
                foreach (var a in banned)  //Looping for array banned and adding the words to hash set
                {
                    bann.Add(a);
                }
                foreach (var a in line) 
                {
                    string bulls = a.ToLower();
                    if (bann.Contains(bulls))   //Checking if the bulls string has any banned words
                    {
                        continue;
                    }
                    dict.TryAdd(bulls, 0);
                    dict[bulls]++;
                }
                int count = 0;  //Initializing the count as 0
                foreach (var kv in dict)   //Checking which word has maximum count in the bulls string array
                {
                    if (kv.Value > count)
                    {
                        count = kv.Value;
                        final = kv.Key;
                    }
                }

                return final;
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                int sum = 0;   //Initializing sum as 0
                for (int i = arr.Length - 1; i >= 0; i--)  //Looping to check all the integers of the array, starting from last as we need to find the highesht integera
                {
                    sum++;
                    if (i == 0 || arr[i] != arr[i - 1])         //Checking the value of integer is same as integer one below
                    {
                        if (sum == arr[i])                      //Check if the integer has freqency same as its value
                        {
                            return sum;
                        }
                        sum = 0;
                    }
                }
                return -1;
                
                //return 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int count = 0, remaining = 0;
                var list = new List<char>(secret.ToCharArray());
                for (int i = 0; i < secret.Length; i++)     //Looping till the length of the secret
                {
                    if (secret[i] == guess[i])
                    {
                        count += 1;                         //Counting the number of digits that are in right position
                        list.Remove(secret[i]);
                    }

                }
                for (int i = 0; i < secret.Length; i++)     //Looping till the length of the secret
                {
                    if (secret[i] == guess[i])              //Ignoring the digits that are in right position
                        continue;
                    if (list.Contains(guess[i]))
                    {
                        list.Remove(guess[i]);
                        remaining += 1;                     //Counting the digits that are in secret number but incorrectly placed

                    }


                }
                return count + "A" + remaining + "B";           //Printing the final output
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                var total_length = new int[26];

                for (int x = 0; x < s.Length; x++)   // Looping till the length of the string 
                {
                    total_length[s[x] - 'a'] = x;    //to check last place where a given character is used
                }

                var list = new List<int>();
                int partition_start = 0, partition_end = 0;  //Initializing the partitio_start, partition_end 
                for (int x = 0; x < s.Length; x++)
                {
                    partition_end = Math.Max(partition_end, total_length[s[x] - 'a']);
                    if (partition_end != x)
                    {
                        continue;
                    }
                    list.Add(partition_end - partition_start + 1);  //Finding the length of each parition
                    partition_start = x + 1;
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int pixel_width = 0, number=1;
                for (int i = 0; i < s.Length; i++)   //looping till the length of the given string
                {
                    int a = widths[s[i] - 'a'];
                    pixel_width += a;                //calculating the width of the last line in pixel
                    if (pixel_width > 100)     
                    {
                        pixel_width = a;
                        number += 1;                //Calculating the number of lines
                    }

                }
                var k = new List<int>() { number, pixel_width };
                return k;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                if (bulls_string10.Length < 1 || bulls_string10.Length > 10000)   //checking for constraint 1 <= bulls_string .length <= 104
                {
                    return false;
                }

                char[] delimiters = { '(', '{', '[' };      //initializing all paranthesis in delimiters
                Dictionary<char, char> d = new Dictionary<char, char>();
                List<char> Final = new List<char>();
                d.Add('{', '}');  //adding opening and closing paranthesis to dictionary
                d.Add('(', ')');
                d.Add('[', ']');

                foreach (char x in bulls_string10)
                {
                    if (!delimiters.Contains(x))      //check if delimeters contains the bulls_string10
                    {
                        if (Final.Count != 0)       
                        {
                            int count = Final.Count;    //Initializing the count as final count
                            char i = Final[count - 1];
                            Final.RemoveAt(count - 1);  
                            if (x != d[i])  //check if x not equivalent to ith value
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;           
                        }
                    }
                    else
                    {
                         Final.Add(x);
                    }

                }
                if (Final.Count == 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] Morse_Code = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                Dictionary<String, int> d = new Dictionary<String, int>();


                for (int i1 = 0; i1 < words.Length; i1++)  //looping till the length of the words
                {
                    string word = words[i1];
                    string i = "";                      //initializing an empty string i
                    foreach (Char c in word)                //Check for all the characters in the given words
                    {
                        i = i+ Morse_Code[c - 'a'];
                    }
                    if (d.ContainsKey(i))       
                    {
                        d[i] = d[i] + 1;              //Calculating the different transformations
                    }
                    else
                    {
                        d[i] = 1;
                    }
                }

                    return d.Count;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                int n = grid.Length, b1, b2; // initializing the length as n and boundaries of grid as a and b
                int size = (int)Math.Sqrt(n);
                int final = -1;
                b1 = grid[0, 0];         
                b2 = (size * size) - 1;             // finding the highest value of grid
                
                while (b1 <= b2)                
                {
                    int half = (b1 + b2) / 2;
                    bool ispath = false;        

                    int[] a = new int[2] { -0, -1 };   // initializing all the four possible directions
                    int[] b = new int[2] { 1, 0 };
                    int[] c = new int[2] { 0, 1 };
                    int[] ds = new int[2] { -1, 0 };
                    int[][] dir = new int[][] { a, b, c, ds };  //saving all four directions in an array

                    Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();  // declaring a tuple queue 
                    q.Enqueue(Tuple.Create(0, 0));        
                    bool[][] v = new bool[size][];    
                    
                    for (int i = 0; i < size; i++)
                        v[i] = new bool[size];
                    v[0][0] = true;       
                    int flag = 0;          // initializing the flag 

                    while (q.Count > 0) //looping till matrix has any value
                    {          
                        
                        for (int i = 0; i < q.Count; i++)   //looping till it has any value in queue
                        {      
                            var pnt = q.Dequeue();       
                            int X = pnt.Item1;          
                            int Y = pnt.Item2;

                            if (X == size - 1 && Y == size - 1)  //check if we reach the end by changing flag to 1
                            {  
                                ispath = true;
                                flag = 1;
                                break;
                            }
                            foreach (var d in dir)  //loop for all values in the queue
                            {   
                                int X1 = X + d[0];
                                int Y1 = Y + d[1];
                                if (X1 >= 0 && X1 < size && Y1 >= 0 && Y1 < size && !v[X1][Y1] && grid[X1, Y1] <= half)
                                {  
                                    q.Enqueue(Tuple.Create(X1, Y1));  
                                    v[X1][Y1] = true;     
                                }
                            }
                        }
                        if (flag == 1)     
                            break;
                    }
                    if (flag == 0)            // if no path is found
                        ispath = false;

                    if (ispath)
                    {   
                        final = half;           // store the current depth in result
                        b2 = half - 1;         // checking for minimum path
                    }
                    else            
                        b1 = half + 1;        
                }
                return final;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int a = word1.Length, b = word2.Length;

                int[,] dis = new int[a + 1, b + 1];
                if (a == 0)     //if the first string is empty then return the size of the second string
                    return b;

                if (b == 0)        //if the second string is empty then return the size of the first string
                    return a;

                for (int i = 0; i <= a; i++)
                {
                    dis[i, 0] = i;
                }

                for (int i = 1; i <= b; i++)
                {
                    dis[0, i] = i;
                }

                for (int i = 1; i <= word1.Length; i++)     //looping till the length of the first word
                {
                    for (int j = 1; j <= word2.Length; j++)     //looping till the length of the second word
                    {
                        if (word1[i - 1] == word2[j - 1])       //if the characters of strings are same then check remianing string
                            dis[i, j] = dis[i - 1, j - 1];
                        else
                            dis[i, j] = Math.Min(dis[i - 1, j - 1], Math.Min(dis[i - 1, j], dis[i, j - 1])) + 1;
                    }
                }

                return dis[word1.Length, word2.Length];


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}