/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Most frequent word is : {0}", commonWord);
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
        /// <summary> We are given an array of distinct and sorted integers, we need to find the index of the target(int, another input) in that array. If it is not present then return the index of that target
        /// if were present in the array. 
        /// 
        /// </summary> I have used binary search algorithm to solve this problem since asked to solve in O(log n) time complexity. 
        /// <param name="nums"></param> It is an array of distinct and sorted integers
        /// <param name="target"></param> It is an integer, of which we need to find the index for.
        /// <returns></returns> First, we divide the sorted array into two parts and find if the target is in first half or second half. Say, it is in first half, we again divide the first half into two parts and find where
        /// the target value matches the integer of that array. If it does not match then we will return the rught index in that array where the target value would go if present. Return value is a int (postion of that array).
        /// 

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int first = 0;
                int last = nums.Length - 1;

                while (first <= last)
                {
                    int mi = first + ((last - first) / 2);
                    int mv = nums[mi];
                    if (target == mv)  //searches whether target is equal to middle value or not
                    {
                        return mi;
                    }

                    else if (mv < target) // search whether the target lies in greater half of the array (greater than middle value)
                    {
                        first = mi + 1;
                    }
                    else // search whether the target lies in first half of the array (less than middle value)
                    {
                        last = mi - 1;
                    }

                }
                return first;
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

        /// <summary> We are provided with 2 inputs. 1) string paragraph and 2) a string array which holds only one word (which is called as banned word). Now, we should clean the string 'pargraph' and remove the 
        /// banned word in it and count the occurences of each word in the new 'paragraph' and return the word which has highest occurences.
        /// 
        /// </summary> I have used dictionary to solve this problem , as it eases to count the occurences of each word and store that in a key, value pair.
        /// <param name="paragraph"></param>
        /// <param name="banned"></param>
        /// <returns></returns> First, we should clean the input paragraph to remove special characters and covert it into lower case. Count the occurences of each word in the string and store that in a key value pair.
        /// if key !- banned then find the occurences of each word and return the key which has the maximum value.

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                string ss = Regex.Replace(paragraph.ToLower(), "[!,.-]", "");  //Used Regex to clean the input string (removed special characters and converted into lower case) 

                string[] s = ss.Split(' ');  // Stores all the strings in an array
                string c = "";
                var dict = new Dictionary<string, int>();  // declares a new dictionary.

                if (banned.Length == 0)
                {
                    return ss;  //if there is no banned word, then return the cleaned string ss
                }

                foreach (var ele in s)  
                {
                    if (dict.ContainsKey(ele)) // initially it does not goes into this condition. Later, searches if the dictionary contains the key (words in the array s). If it has then increments the value part by +1.
                    {
                        dict[ele]++;
                    }
                    else                       // if dictionary doesnot contain the key then it adds the word of that array and 1 as key.
                    {
                        dict.Add(ele, 1);
                    }
                }

                int max = 0;

                foreach (var keyval in dict)         
                {
                    if (keyval.Key != banned[0])   // find the occurences of each word except the banned word
                    {
                        max = Math.Max(max, keyval.Value);
                    }
                }



                foreach (var keyval in dict)
                {
                    if (keyval.Value == max)  // for the values of keys in dict. If value==max, then store that value in c.
                    {
                        c = keyval.Key;
                    }
                }
                return c; 
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
        /// <summary> We are provided with an Array of integers arr, and a lucky integer which is an integer. We have to find the frequency in the array equal to its value.
        /// 
        /// </summary>I have used dictionary to solve this problem , as it eases to count the occurences of each integer and store that in a key, value pair.
        /// <param name="arr"></param> Array of integers with size 'n'.
        /// <returns></returns> First, declared an empty dictionary dict and if that dict has no key as in number of the array then add that number as a key into a dictionary and count the occurences 
        /// of that number and store the value of that number in the value part of that key in the dictionary. If any key == value then it returns the value as output, If there is more than 1 match, then returns max value.

        public static int FindLucky(int[] arr)
        {
            try
            {
                var dict = new Dictionary<int, int>();
                foreach (var i in arr)
                {
                    if (dict.ContainsKey(i)) // searches if the dictionary contains the key (integers in the input array). If it has then increments the value part by +1.
                    {
                        dict[i]++;
                    }
                    else
                    {
                        dict.Add(i, 1); // if dictionary doesnot contain the key then it adds the integer of that array and 1 as key.
                    }

                    //Console.WriteLine(dict[i]);
                }

                int r = -1; 

                foreach (var i in dict)
                {
                    if (i.Key == i.Value) // searches for the key == value match
                    {
                        r = Math.Max(r, i.Value); // if it is, then find the maximum value of such matches and stors in variable r.
                    }
                }

                return r; // If there is a match then return the value stored in r, and returns -1 if there is no key == value match at all. 
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

        /// <summary> We are provided with 2 strings secret and guess. We need to find the bulls and cows from that. bulls = digits in the guess that are in the correct position.
        /// cows = digits in the guess that are in your secret number but are located in the wrong position.
        /// I have used an array chars of length 26 and with the help of that I stored 1 in the indices of the each character (1,8,0,7) of the string and solved for cows and bulls by using for loops and if statements
        /// </summary>
        /// <param name="secret"></param>  a string which looks like integer
        /// <param name="guess"></param>   a string which looks like integer
        /// <returns></returns> returns a string with values of bulls and cows in this format - 1A0B, 2A1B, etc... 

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int sl = secret.Length; // stors the length of string secret in variable sl.

                int gl = guess.Length; // stors the length of string guess in variable gl.

                int[] chars = new int[26]; // declares an empty array of size 26. {0,0,0,0,0,......}

                int cnt = 0;

                int cnt1 = 0;

                

                foreach (var ch in secret) // this loop stores the value as 1 in the array chars.  
                {
                    
                    chars[ch - '0']++;    // {1,1,0,0,0,0,0,1,1,0,0.....}  if the secret string = "1807" Stores the value as 1 at indices 0,1,7,8.

                }

                /*foreach(var i in chars)
                {
                    Console.WriteLine(i);
                }*/

                
                // this loop is to find the value of bulls

                for (int i = 0; i < sl; i++)    
                {
                    if (secret[i] == guess[i])  // searches for the straight match, if it is then increment the initial count value (0) and it is the value of bulls.
                    {
                        cnt+=1;
                        chars[secret[i] - '0']--;
                    }
                }

                /*foreach (var i in chars)
                {
                    Console.WriteLine(i);
                }*/

                //Console.WriteLine(chars[guess[2] - '0']);

                for (int i = 0; i < sl; i++)    // this loop is to find the value of cows.
                {
                    if (secret[i] != guess[i])        // if there is no match then it searches if the guess's each charcter (index) has the value of greater than 0 or not in chars array.
                    {
                        if (chars[guess[i] - '0'] > 0)
                        {
                            cnt1+=1;                // Counts the number of such instances and this value is equal to the number of cows.
                            chars[guess[i] - '0']--;
                        }
                    }
                }

                return cnt + "A" + cnt1 + "B";  // output format 1A0B.

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
        /// <summary> We are provided with a string, we need to partition the string into as many parts as possible so that each letter appears in at most one part.
        ///  I have used a dictionary to store the highest index of each character of a string and then used while loop condition for solving the logic 
        /// </summary>
        /// <param name="s"></param> s = string looks like 'abcadfjfndajfnlfe'
        /// <returns></returns> returns a list with the length of each partitions.

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                var dic = new Dictionary<char, int>(); // declared a new dictionary

                int l = s.Length; // l= length of the string

                int c = 0;

                var lst = new List<int>(); // created a new list to store the values and display the output in list format aas asked

                for (int i = 0; i < l; i++) // this loop creates a dictionary with unique character of the string and it's highest index in that string as the value.
                {
                    
                    if (dic.ContainsKey(s[i])) // if the dictionary contains the value, then replace the old index with new index as a key.
                    {
                        dic[s[i]] = i;
                    }
                    else
                    {
                        dic.Add(s[i], i); // if dictionary doesnot contain the key then it adds the integer of that array and 1 as key.
                    }
                }

                /*foreach (var kvp in dic)
                    {
                        Console.WriteLine(kvp.Key);
                        Console.WriteLine(kvp.Value);
                    }*/

                while (c < l)     // enters the loop while c (intially 0) < length of the string
                {
                    int min = c;             // intitally min is 0
                    int max = dic[s[c]];     // initally, max = index of first element of the string.

                    //Console.WriteLine(max);

                    while (c < max)   // enters the loop if c < max
                    {
                        int max2 = dic[s[c]];  // find for the partition. max2 holds the maximum index of the characters of the string in the first partition.
                        if (max2 > max)
                        {
                            max = max2;  
                        }

                        c++;  // increments each character of the partition to get the value of max2.
                    }

                    lst.Add(max - min + 1);
                    c++;
                }

                return lst;
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
        /// <summary>
        /// We are provided with 2 inputs, an array of widths for the 26 alphabets in an order, and a string s. A line has a maximum width length of 100, we need to calcualte the number of lines and the 
        /// length of the widths of the last line.
        /// I have found the index of alphabets and substituted in the array of widths and found the sum of each line (sum<100) and solved for the line count, sum of last line widths.
        /// </summary>
        /// <param name="widths"></param> array of length 26 with the integers having the widths of alphabets
        /// <param name="s"></param> string s. 
        /// <returns></returns> returns the list [count, sum].
        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int sum = 0;        // intitalizing all the variables that will be used below.

                int count = 1;
                
                int index = -1;

                int sl = s.Length;

                int wastesum = 0;

                for (int i = 0; i < sl; i++)
                {
                    index = s[i] - 'a';     // using the logic ('d'-'a' = 3), we will get indices of the widths to sum in order according to the given string
                    //Console.WriteLine(s[i]-'a');
                    wastesum = sum;       // this is wastesum is not used but it stores the sum of each line.
                    sum += widths[index];   // it sums up the widths of each character
                    if (sum <= 100)       // if sum does not exceed 100 then conitnue adding
                    {
                        continue;
                    }
                    else                 // if sum > 100, then increase the line count, and make sum as that character width and starting adding up from then.
                    {
                        count+=1;
                        sum = widths[index];
                    }

                }
                //Console.WriteLine(sum);
                
                List<int> fin = new List<int>();
                
                fin.Add(count);
                fin.Add(sum);
                
                
                return fin;
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
        /// <summary>
        /// We are provided with a string which only have paranthesis in it. We need to determin whether the given string is valid or not by comparing with the given constraints.
        /// I have used a switch - case statement to solve the logic.
        /// </summary>
        /// <param name="bulls_string10"></param> it is a string which looks like '()[]{]', '({[]})', etc....
        /// <returns></returns> returns a boolen value .. true or false.
        
        public static bool IsValid(string bulls_string10)
        {
            try
            {
               
                    int index = 0;

                    if (bulls_string10.Length < 2)  // if the length of the string is 0 or 1 then it does not looks like symmetric at all first .. so the return value is false
                    {
                        return false;
                    }

                    while (bulls_string10.Length > 0 && index < bulls_string10.Length)  // enters the loop if string legth is not zero and index < string length
                    {
                        if (")]}".Contains(bulls_string10[index]))  // enters the loop if the s[i] contains ")}]" closing braces
                        {
                            if (index == 0)
                            {
                                return false; // it returns false if index =0 because, the string cannot look like this }{, ][, ){, )(, etc..
                            }

                            char open = ' ';  // empty character declaration

                            switch (bulls_string10[index])  // switch case for each character .. if opens closes with '}' then open with '{'
                            {
                                case ')':
                                    open = '(';
                                    break;
                                case ']':
                                    open = '[';
                                    break;
                                case '}':
                                    open = '{';
                                    break;
                            }

                            if (bulls_string10[index - 1] == open)  //.. if close ==open then remove the pair and make reduce index by 2 valeus as a braces pair got removed
                            {

                                bulls_string10 = bulls_string10.Remove(index - 1, 2);
                                index = index - 2;

                            }
                            else                                   //.. if close !=open then return false again .. for the return value to be true, close==open
                            {
                                return false;
                            }

                        }
                        index++;
                    }
                    return bulls_string10.Length == 0; // returns boolean, for the value to be true .. the length of the final string should be 0.

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
        /// <summary>
        /// We are provided with an array of words, we need to find the morse code of each word with the help of the given morse code array of each character.
        /// I have used a dictionary to refer the morse code of each alphabet in a key value pair. And a used a simple for loop to get the morse code of each word and stored them in a list.
        /// </summary>
        /// <param name="words"></param> array of words.
        /// <returns></returns> returns the count of unique morse codes of the array words.

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                List<string> morsecode = new List<string>(); // declared a string to store the morse code of each word of the array words.

                var dict = new Dictionary<char, string>() // declared an array according to the question. Although it took some time to create the dictionary, the solution will be quite simple after this.
            {
                {'a',".-"},
                {'b',"-..."},
                {'c',"-.-."},
                {'d',"-.."},
                {'e',"."},
                {'f',"..-."},
                {'g',"--."},
                {'h',"...."},
                {'i',".."},
                {'j',".---"},
                {'k',"-.-"},
                {'l',".-.."},
                {'m',"--"},
                {'n',"-."},
                {'o',"---"},
                {'p',".--."},
                {'q',"--.-"},
                {'r',".-."},
                {'s',"..."},
                {'t',"-"},
                {'u',"..-"},
                {'v',"...-"},
                {'w',".--"},
                {'x',"-..-"},
                {'y',"-.--"},
                {'z',"--.."},
            };


                foreach (string element in words) //  for rach word in the array words
                {
                    string a = "";
                    foreach (char ele in element) // for each character of the each word of the array words.
                    {
                        a += dict[ele];  // adds the morse code of each character of individual word by referring to the dictioanry dict.
                    }

                    if (!morsecode.Contains(a)) // this condition statement is to store the unique morsecodes of the array words
                    {
                        morsecode.Add(a);
                    }
                }

                return morsecode.Count; // returns the count of unique morse codes.

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
                //write your code here.
                return 0;
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
                int wl1 = word1.Length;

                int wl2 = word2.Length;

                int[,] fin = new int[wl1 + 1, wl2 + 1];

                return fin[0, 0];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

