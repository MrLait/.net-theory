using System;
using PatternStrategy = SOLID._2.OpenClosedPrinciple.GoodPractice.PatternStrategy;
using PatternTemplateMethod = SOLID._2.OpenClosedPrinciple.GoodPractice.PatternTemplateMethod;
using BadPractice = SOLID._3.LiskovSubstitutionPrinciple.BadPractice;

using SOLID._5.DependencyInversionPrinciple.GoodPractice.Models;
using SOLID._1.SingleResponsibilityPrinciple.GroupedByMethod.GoodPractice;
using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;
using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Data.SqlTypes;
using System.Reflection;
using System.Collections.Concurrent;

namespace SOLID
{
    class Program
    {



    static void Do(string t) => Console.WriteLine(t);

        static void Main(string[] args)
        {
            var test = new DataProviderService();
            var test2 = test.GetValue(0, 2);


            var dictionary1 = new Dictionary<MyKey, string>();

            var key1 = new MyKey("FirstKey");
            var key2 = new MyKey("SecondKey");
            var key3 = new MyKey(null);
            var key4 = new MyKey(null);
            MyKey myKey = null;

            // Эти ключи разные, но их GetHashCode() возвращает одинаковое значение
            dictionary1[key1] = "Value for first key";
            dictionary1[key2] = "Value for second key";
            dictionary1[key3] = "null key";
            dictionary1[key4] = "null key4";
            dictionary1[myKey] = "null";

            foreach (var kv in dictionary1)
            {
                Console.WriteLine($"{kv.Key}");
            }

            var r33 = NumEquivDominoPairs(new int[][]
            {
                new int[] {1, 1 },
                new int[] {1, 2 },
                new int[] {1, 2 },
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {2, 2 },

            });

            DuplicateZeros(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 });
            var r32 = HeightChecker(new int[] { 1, 1, 4, 2, 1, 3 });
            var r31 = RemoveDuplicates("abbaca");
            var r30 = LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1 });
            var r29 = AllCellsDistOrder(3, 2, 1, 1);
            var r28 = RemoveOuterParentheses("()()");
            var r27 = PrefixesDivBy5(new int[] { 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0 });
            var r26 = AddToArrayForm(new int[] { 2, 7, 4 }, 181);
            var r25 = IsLongPressedName("pyplrz", "ppyypllr");

            var root1 = new TreeNode(3, new TreeNode(5, new TreeNode(6), new TreeNode(2, new TreeNode(7), new TreeNode(4))), new TreeNode(1, new TreeNode(9), new TreeNode(8)));
            var root2 = new TreeNode(3, new TreeNode(5, new TreeNode(6), new TreeNode(7)), new TreeNode(1, new TreeNode(4), new TreeNode(2, null, new TreeNode(9, null, new TreeNode(8)))));

            var r23 = LeafSimilar(root1, root2);
            var r22 = BuddyStrings("ab", "ba");
            var r21 = MostCommonWord("Bob. hIt, baLl", new string[] { "bob", "hit" });
            var r20 = RotateString("bbbacddceeb", "ceebbbbacdd");
            var r19 = IsToeplitzMatrix(new int[][]
                {
                    new int[] {36,59,71,15,26,82,87},
                    new int[] {56,36,59,71,15,26,82},
                    new int[] {15,0 ,36,59,71,15,26},
                });
            var r18 = MinCostClimbingStairs(new int[] { 0, 1, 2, 2 });
            var r17 = CountSymmetricIntegers(1, 100);
            var r16 = MaxSum(new int[] { 84, 91, 18, 59, 27, 9, 81, 33, 17, 58 });
            var r15 = MissingInteger(new int[] { 46, 8, 2, 4, 1, 4, 10, 2, 4, 10, 2, 5, 7, 3, 1 });
            var r14 = MinimumPushes("abyefcxumqzht");
            var r13 = SumOfEncryptedInt(new int[] { 109 });
            var r12 = DuplicateNumbersXOR(new int[] { 1, 2, 1, 3 });
            var result1 = CountCompleteDayPairs(new int[] { 12, 12, 30, 24, 24 });
            var r11 = RepeatedSubstringPattern("aabaaba");
            var r10 = FindDisappearedNumbers(new int[] { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 });
            var r9 = CountSegments("    ");
            var r8 = AddStrings("456", "77");
            var r7 = ThirdMax(new int[] { -2147483648, -2147483648, -2147483648, -2147483648, 1, 1, 1 });
            var r6 = CanConstructV1("s", "aab");
            var r5 = Intersection(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
            var r4 = ReverseVowels("leetcode");
            //var s1 = new char[] { 'h', 'e', 'l', 'l', 'o' };
            var s1 = new char[] { 'h', 'e', 'l', 'l', 'o', 'H' };
            ReverseString(s1);
            var r3 = IsPowerOfThree(1);
            var r2 = MaximumLength("aaaaa");
            var r1 = LargestPerimeter(new int[] { 1, 12, 1, 2, 5, 50, 3 });
            //var r1 = LargestPerimeter(new int[] { 1, 12, 1, 2, 5, 50, 3 });
            var str = 667488958374553;
            //var strTwo = "a b c d e f";
            var strTwo = "a A b ";
            //var strTwo = "hello world one";
            //var strTwo = "hello world one";
            var r = StringChallengeTwo(strTwo);

            var nums = new int[] { 2, 10, 9 };
            var at = IncremovableSubarrayCount(nums);

            var list1 = new List<int> { 1, 2 };
            var data = list1.Where(x => x == 1);

            list1.Add(1);
            var count = data.Count();
            list1.Add(1);
            count = data.Count();


            Hashtable openWith = new Hashtable();
            // Add some elements to the hash table. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add(1, 1);

            foreach (var key in openWith.Values)
            {
                var t = key.GetType();
            }
            HashSet<int> evenNumbers = new HashSet<int>();
            evenNumbers.Add(1);
            evenNumbers.Add(1);



            var result = new List<int>();
            //var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));
            var root = new TreeNode(4, new TreeNode(2, new TreeNode(1, null, null), new TreeNode(3, null, null)), new TreeNode(6, null, null));
            var letters = new char[] { 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n' };
            var target = 'e';
            var s = SummaryRanges(new int[] { 0, 2, 3, 4, 6, 8, 9 });
            var i = NextGreatestLetter(letters, target);
            var re = Math.Max(1, Math.Max(2, 3));
            //return letters[i + 1];
            IsIsomorphic("bbbaaaba", "aaabbbba");
            //var nums = new int[] { 3, 1, 6, 2, 4, 5, 9, 8, 7 };
            var numsTwo = new int[] { 3, 0, 6, 0, 4, 5, 9, 0, 0 };
            var numsThree = new int[] { 0, 1, 0, 3, 12 };
            var numsFour = new int[] { 0, 0, 1 };
            var numsFive = new int[] { -1, 0, 3, 5, 9, 12 };
            EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            var iS = IsSubsequence("b", "abc");
            var index = BinarySearchRecursive(numsFive, 2, 0);
            MoveZeroes(numsTwo);
            MergeSort(nums);
            BubleSort(nums);

            var value = int.MaxValue;
            var delta = int.MaxValue;
            InOrder(root, ref value, ref delta);
            var dict = new Dictionary<int, int>();
            SingleResponsibilityOne();
            SingleResponsibilityTwo();
            OpenClosedPrinciplePatternStrategy();
            OpenClosedPrinciplePatternTemplatesMethod();
            LiskovSubstitutionPrincipleBadPractice();
            //LiskovSubstitutionPrincipleBadPracticePrecoonditions();
            LiskovSubstitutionPrincipleBadPracticePostconditions();
        }
        public static int NumEquivDominoPairs(int[][] dominoes)
        {
            var dominoPairs = new Dictionary<(int, int), int>();
            var result = 0;

            foreach (var domino in dominoes)
            {
                // Упорядочим домино так, чтобы (min, max) всегда шло в словарь
                var key = domino[0] < domino[1] ? (domino[0], domino[1]) : (domino[1], domino[0]);

                if (dominoPairs.ContainsKey(key))
                {
                    // Считаем количество пар
                    result += dominoPairs[key];
                    dominoPairs[key]++;
                }
                else
                {
                    dominoPairs[key] = 1;
                }
            }

            return result;
        }


        public static void DuplicateZeros(int[] arr)
        {
            int zeros = 0;
            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                if (arr[i] == 0)
                {
                    zeros++;
                }
            }

            for (int i = length - 1; i >= 0; i--)
            {
                if (i + zeros < length)
                {
                    arr[i + zeros] = arr[i];
                }

                if (arr[i] == 0)
                {
                    zeros--;

                    if (i + zeros < length)
                    {
                        arr[i + zeros] = 0;
                    }
                }
            }

        }
        public static int HeightChecker(int[] heights)
        {
            var sortedByheight = new int[heights.Length];
            var result = 0;

            heights.CopyTo(sortedByheight, 0);

            Array.Sort(sortedByheight);

            for (int i = 0; i < heights.Length; i++)
            {
                if (sortedByheight[i] != heights[i])
                    result++;
            }

            return result;
        }
        public static string RemoveDuplicates(string s)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count > 0 && stack.Peek() == s[i])
                    stack.Pop();
                else
                    stack.Push(s[i]);
            }
            var joinedString = string.Join("", stack).ToArray();

            Array.Reverse(joinedString);
            return new string(joinedString);
        }
        public static int LastStoneWeight(int[] stones)
        {
            var (max1, max1Index, max2, max2Index) = (0, 0, 0, 0);
            var list = new List<int>(stones);

            while (list.Count > 1)
            {
                (max1, max2) = (0, 0);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > max1)
                    {
                        if (max1 > max2)
                            (max2, max2Index) = (max1, max1Index);
                        (max1, max1Index) = (list[i], i);
                    }
                    else if (list[i] > max2)
                    {
                        (max2, max2Index) = (list[i], i);
                    }
                }

                if (max1 == max2)
                {
                    list.RemoveAll(x => x == max1);
                }
                else
                {

                    list.Remove(max1);
                    list.Remove(max2);
                    list.Add(Math.Abs(max1 - max2));
                }
            }

            return list.Count == 1 ? list[0] : 0;
        }

        public static int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            var distance = new int[rows * cols][];

            for (int i = 0, j = 0; i < rows; i++)
                for (int k = 0; k < cols; j++, k++)
                    distance[j] = new int[] { i, k, Math.Abs(i - rCenter) + Math.Abs(k - cCenter) };

            Array.Sort(distance, (a, b) => a[2].CompareTo(b[2]));

            return distance.Select(x => new[] { x[0], x[1] }).ToArray();
        }

        public static string RemoveOuterParentheses(string s)
        {
            var stack = new Stack<char>();
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push('(');
                else
                    stack.Pop();

                if (stack.Count != 0)
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
        public static IList<bool> PrefixesDivBy5(int[] nums)
        {
            var result = new List<bool>();
            var num = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                num = num << 1;
                num = (num + nums[i]);
                result.Add(num == 0);
            }

            return result;
        }

        public static IList<int> AddToArrayForm(int[] num, int k)
        {
            var result = new List<int>();
            var kConverted = ConvertIntToList(k);
            var j = 0;
            var remainder = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                var sum = 0;
                if (j < kConverted.Count)
                {
                    sum = num[i] + kConverted[j++] + remainder;
                }
                else
                {
                    sum = num[i] + remainder;
                }

                if (sum > 10)
                {
                    result.Add(sum % 10);
                    remainder = sum / 10;
                }
                else
                {
                    result.Add(sum);
                }
            }

            if (remainder != 0)
                result.Add(remainder);

            result.Reverse();
            return result;
        }

        private static IList<int> ConvertIntToList(int k)
        {
            var result = new List<int>();

            for (int i = k; i > 0; i /= 10)
                result.Add(i % 10);

            return result;
        }

        public static bool IsLongPressedName(string name, string typed)
        {
            var (nameIndex, typedIndex, nameLength, typedLength) = (0, 0, name.Length, typed.Length);
            var prevNameLetter = default(char);

            if (typedLength < nameLength) return false;

            while (typedIndex < typedLength)
            {
                while (nameIndex < nameLength && typedIndex < typedLength && name[nameIndex] == typed[typedIndex])
                {
                    prevNameLetter = name[nameIndex];
                    nameIndex++;
                    typedIndex++;
                }

                while (typedIndex < typedLength && prevNameLetter == typed[typedIndex])
                {
                    typedIndex++;
                }
            }

            return nameIndex == nameLength;
        }

        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var list = new List<int>();
            AddLeafToList(root1, list);
            var index = 0;
            return ComareLeafInList(root2, list, ref index);
        }

        private static void AddLeafToList(TreeNode root, List<int> list)
        {
            if (root == null) return;

            if (root.left == null)
                list.Add(root.val);

            AddLeafToList(root.left, list);
            AddLeafToList(root.right, list);
        }

        private static bool ComareLeafInList(TreeNode root, List<int> list, ref int index)
        {
            if (root == null) return false;

            if (root.left == null)
            {
                if (list[index] != root.val)
                    return false;
                index++;
            }

            return ComareLeafInList(root.left, list, ref index) && ComareLeafInList(root.right, list, ref index);
        }
        public static bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length || s.Length < 2)
                return false;

            var first = ' ';
            var second = ' ';
            var isFindSecond = false;
            var count = 0;

            // if(s.Equals(goal))
            // {
            //     var set = new HashSet<char>(s);
            //     return set.Count < s.Length ;
            // }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    count++;
                    if (count == 0)
                    {
                        first = s[i];
                        second = goal[i];
                    }
                    else
                    {
                        if (first == goal[i] && second == s[i])
                            isFindSecond = true;
                    }

                    // if(count > 2)
                    //     return false;
                }
            }

            return isFindSecond;
        }

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            var wordsDic = new Dictionary<string, int>();
            var words = paragraph.ToLower().Split(new[] { ' ', '!', '?', ',', ';', '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                var isBunned = false;

                if (banned.Length > 0)
                {
                    for (int i = 0; i < banned.Length; i++)
                    {
                        if (banned[i] == word)
                        {
                            isBunned = true;
                            break;
                        }
                    }
                }

                if (!isBunned) AddWordToDictionary(wordsDic, word);
            }

            return wordsDic.OrderByDescending(n => n.Value).First().Key;
        }

        private static void AddWordToDictionary(Dictionary<string, int> wordsDic, string word)
        {
            if (!wordsDic.ContainsKey(word))
                wordsDic[word] = 0;

            wordsDic[word]++;
        }

        public static bool RotateString(string s, string goal)
        {
            var count = s.Count(x => x == goal[0]);
            var startIndex = 0;

            while (count > 0)
            {
                var substring = s.Substring(startIndex);
                startIndex += substring.IndexOf(goal[0]);

                var resultString = s.Substring(startIndex);
                resultString += s.Substring(0, startIndex);

                if (resultString == goal) return true;

                startIndex++;
                count--;
            }

            return false;
        }
        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[0].Length - 1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                        return false;
                }
            }

            return true;
        }
        public static int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length < 3) return cost[0] > cost[1] ? cost[1] : cost[0];
            var result = 0;
            int i = -1;
            while (i < cost.Length - 2)
            {
                if (i == -1)
                {
                    if (cost[0] + cost[2] > cost[1])
                    {
                        result += cost[1];
                        i = 1;
                    }
                    else if (cost[0] == cost[1])
                    {
                        result += cost[1];
                        i = 1;
                    }
                    else if (cost[0] < cost[1])
                    {
                        result += cost[++i];
                    }
                }
                else
                {
                    if (cost[i + 1] >= cost[i + 2])
                    {
                        result += cost[i + 2];
                        i += 2;
                    }
                    else
                        result += cost[i++ + 1];
                }
            }

            return result;
        }

        public static int MinimumRightShifts(IList<int> nums)
        {
            var minLeft = nums[0];
            var isLeft = true;
            var maxLeft = 0;

            var minRight = 0;
            var maxRight = 0;
            var shiftIndex = 0;

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (isLeft)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        isLeft = false;
                        maxLeft = nums[i];
                        minRight = nums[i + 1];
                        shiftIndex = nums.Count - i - 1;
                    }
                }
                else
                {
                    if (nums[i] < nums[i + 1])
                    {
                        maxRight = nums[i + 1];
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            if (maxRight > maxLeft || minLeft < minRight) return -1;

            return isLeft ? 0 : shiftIndex;
        }

        public static int CountSymmetricIntegers(int low, int high)
        {
            var result = 0;

            for (int i = low; i <= high; i++)
            {
                result += IsSymmetric(i) ? 1 : 0;
            }

            return result;
        }

        private static bool IsSymmetric(int num)
        {
            var n = CountDigits(num);
            var sum = 0;

            if (n % 2 != 0) return false;

            var half = n / 2;

            for (int j = num; half > 0; j /= 10)
            {
                sum += j % 10;
                half--;
            }

            half = n / 2;

            for (int j = num; half > 0 && sum >= 0; j /= 10)
            {
                sum -= j % 10;
                half--;
            }

            return sum == 0;
        }

        private static int CountDigits(int num)
        {
            var result = 0;

            for (int i = num; i > 0; i /= 10)
                result++;

            return result;
        }


        private static List<int> IntToDigits(int num)
        {
            var list = new List<int>();

            for (int i = num; i > 0; i /= 10)
                list.Add(i % 10);

            return list;
        }

        public static int MaxSum(int[] nums)
        {
            var dic = new Dictionary<int, List<int>>();
            var maxNum = 0;
            var maxNumTwo = 0;
            var maxSum = -1;

            foreach (var num in nums)
            {
                for (int i = num; i > 0; i /= 10)
                {
                    maxNum = Math.Max(maxNum, i % 10);
                }

                if (!dic.ContainsKey(maxNum))
                    dic.Add(maxNum, new List<int>());

                dic[maxNum].Add(num);

                maxNum = 0;
            }

            foreach (var d in dic)
            {
                var list = d.Value;

                if (list.Count == 2)
                {
                    maxSum = Math.Max(maxSum, list.Sum());
                }
                else if (list.Count > 2)
                {
                    foreach (var num in list)
                    {
                        if (num > maxNum)
                        {
                            if (maxNum > maxNumTwo)
                                maxNumTwo = maxNum;

                            maxNum = num;
                        }
                        else if (num > maxNumTwo)
                        {
                            maxNumTwo = num;
                        }
                    }

                    maxSum = Math.Max(maxSum, maxNum + maxNumTwo);
                }
            }

            return maxSum;
        }

        public static int MissingInteger(int[] nums)
        {
            if (nums.Length == 1) return nums[0] + 1;

            var prefix = 0;
            var maxNum = nums[0];
            var sumPrefix = nums[0];

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] - 1 != nums[i])
                    prefix = nums[i];

                if (prefix == 0)
                    sumPrefix += nums[i + 1];

                maxNum = Math.Max(maxNum, nums[i + 1]);
            }

            return sumPrefix >= maxNum ? sumPrefix : maxNum + 1;
        }
        public static int MinimumPushes(string word)
        {
            var dic = new Dictionary<char, int>();

            foreach (var c in word)
            {
                if (!dic.ContainsKey(c))
                {
                    dic[c] = 0;
                }

                dic[c]++;
            }

            var pushes = 0;
            var n = 1;

            foreach (var d in dic.OrderByDescending(x => x.Value))
            {
                pushes += n;

                if (pushes % 8 == 0)
                    n++;
            }

            return pushes;
        }

        public static int SumOfEncryptedInt(int[] nums)
        {
            var result = 0;
            var maxDigit = int.MinValue;
            var numLength = 0;
            var encryptedEl = 0;

            foreach (var num in nums)
            {
                maxDigit = int.MinValue;
                numLength = 0;
                encryptedEl = 0;

                for (var i = num; i > 0; i /= 10)
                {
                    numLength++;
                    maxDigit = Math.Max(maxDigit, i % 10);
                }

                encryptedEl = maxDigit;
                for (int i = 1; i < numLength; i++)
                {
                    encryptedEl = encryptedEl * 10 + encryptedEl;
                }

                result += encryptedEl;
            }

            return result;
        }

        public static int DuplicateNumbersXOR(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            var result = 0;

            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 1);
                }
                else
                {
                    dict[num]++;
                }
            }

            foreach (var item in dict)
            {
                if (item.Value > 1)
                {
                    result ^= item.Key;
                }
            }

            return result;
        }

        public static int CountCompleteDayPairs(int[] hours)
        {
            if (hours.Length == 1) return 0;

            var countDays = 0;

            for (int i = 0; i < hours.Length - 1; i++)
            {
                for (int j = i + 1; j < hours.Length; j++)
                {
                    if ((hours[i] + hours[j]) % 24 == 0)
                        countDays++;
                }
            }

            return countDays;
        }

        public static bool RepeatedSubstringPattern(string s)
        {
            if (s.Length == 1) return false;

            var isSubstring = false;

            for (int i = 0; i < s.Length / 2 && !isSubstring; i++)
            {
                if (s.Length % (i + 1) != 0) continue;

                var subIndex = 0;
                isSubstring = true;

                for (int j = 0; j < s.Length && isSubstring; j++)
                {
                    if (s[subIndex] != s[j])
                    {
                        isSubstring = false;
                        break;
                    }


                    if (subIndex == i)
                    {
                        subIndex = 0;
                    }
                    else
                    {
                        subIndex++;
                    }

                }
            }

            return isSubstring;
        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var list = new List<int>();
            var expected = 1;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                while (expected < nums[i])
                {
                    list.Add(expected);
                    expected++;
                }

                expected = nums[i] + 1;
            }

            return list;
        }

        public static int CountSegments(string s)
        {
            if (s == string.Empty)
                return 0;

            var words = s.Split(' ');
            var cnt = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (!char.IsWhiteSpace(words[i][0]))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public static string AddStrings(string num1, string num2)
        {
            int carry = 0;
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            var sb = new StringBuilder();

            while (i >= 0 || j >= 0 || carry != 0)
            {
                int numOne = i >= 0 ? num1[i] - '0' : 0;
                int numTwo = j >= 0 ? num2[j] - '0' : 0;
                int sum = numOne + numTwo + carry;
                carry = sum / 10;
                sb.Append(sum % 10);
                i--;
                j--;
            }

            var result = new StringBuilder();
            for (int k = sb.Length - 1; k >= 0; k--)
            {
                result.Append(sb[k]);
            }

            return result.ToString();
        }

        public static int ThirdMax(int[] nums)
        {
            var first = int.MinValue;
            var second = int.MinValue;
            var third = int.MinValue;
            var cnt = 0;
            var cntMinInt = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != first && nums[i] != second && nums[i] != third)
                {
                    if (nums[i] > first && nums[i] > second && nums[i] > third)
                    {
                        (first, second, third) = (nums[i], first, second);
                        cnt++;
                    }
                    else if (nums[i] > second && nums[i] > third)
                    {
                        (second, third) = (nums[i], second);
                        cnt++;
                    }
                    else if (nums[i] > third)
                    {
                        (third) = (nums[i]);
                        cnt++;
                    }
                }
                else if (cntMinInt < 1 && nums[i] == int.MinValue)
                {
                    cntMinInt++;
                }
            }

            if (cnt + cntMinInt == 1) return first;
            else if (cnt + cntMinInt == 2) return Math.Max(second, first);
            else
                return third;
        }

        public static bool CanConstructV1(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (dict.ContainsKey(ransomNote[i]))
                {
                    dict[ransomNote[i]]++;
                }
                else
                {
                    dict.Add(ransomNote[i], 1);
                }
            }

            for (int i = 0; i < magazine.Length; i++)
            {
                if (dict.ContainsKey(magazine[i]))
                {
                    dict[magazine[i]]--;
                }
            }

            var isSelled = dict.FirstOrDefault(x => x.Value > 0).Value;

            return isSelled <= 0;
        }

        public bool CanConstructV0(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (dict.ContainsKey(ransomNote[i]))
                {
                    dict[ransomNote[i]]++;
                }
                else
                {
                    dict.Add(ransomNote[i], 1);
                }
            }

            foreach (var element in dict)
            {
                var magazineCount = 0;

                for (int i = 0; i < magazine.Length; i++)
                {
                    if (magazine[i] == element.Key)
                    {
                        magazineCount++;
                    }
                }

                if (magazineCount < element.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            var numsMax = new int[0];
            var numsMin = new int[0];
            if (nums1.Length > nums2.Length)
            {
                numsMin = nums2;
                numsMax = nums1;
            }
            else
            {
                numsMin = nums1;
                numsMax = nums2;
            }
            Array.Sort(numsMin);
            var cnt = 1;
            var cntMax = 0;
            var prev = numsMin[0];

            for (int i = 0; i < numsMin.Length; i++)
            {
                cnt = 1;

                while (i + 1 < numsMin.Length && numsMin[i] == numsMin[i + 1])
                {
                    cnt++;
                    if (i + 1 == numsMin.Length)
                    {
                        break;
                    }
                    i++;
                }

                cntMax = 0;

                for (int j = 0; j < numsMax.Length; j++)
                {
                    if (numsMin[i] == numsMax[j])
                    {
                        cntMax++;
                    }

                }
                cnt = Math.Min(cnt, cntMax);

                while (cnt > 0)
                {
                    list.Add(numsMin[i]);
                    cnt--;
                }
            }
            return list.ToArray();
        }

        public static string ReverseVowels(string s)
        {
            var sb = new StringBuilder(s);
            var vowels = "aeiouAEIOU";
            var last = s.Length - 1;

            for (int i = 0; i < last; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    for (int j = last; j > i; j--)
                    {
                        if (vowels.Contains(s[j]))
                        {
                            (sb[i], sb[j]) = (s[j], s[i]);
                            last--;
                            break;
                        }
                        last--;
                    }
                }
            }

            return sb.ToString();
        }

        public static void ReverseString(char[] s)
        {
            var center = s.Length % 2 == 1 ? (s.Length - 1) / 2 : (s.Length - 1) / 2 + 1;
            char temp = ' ';
            var last = s.Length - 1;
            for (int i = 0; i <= center; i++)
            {
                temp = s[i];
                s[i] = s[last];
                s[last] = temp;
                last--;
            }
        }

        public static bool IsPowerOfThree(int n)
        {
            double pow = 0;
            if (n == 0) return false;

            for (int i = 1; i <= n; i++)
            {
                pow = Math.Pow(3, i);

                if (pow == n)
                    return true;

                if (pow > n)
                    return false;

            }

            return false;
        }

        public static int MaximumLength(string s)
        {
            int[,] counts = new int[26, s.Length + 1];

            // For each character, count the number of times it appears consecutively
            char last = '0';
            int repeatCount = 0;
            foreach (char c in s)
            {
                int index = c - 'a';
                if (c == last)
                {
                    repeatCount++;
                }
                else
                {
                    last = c;
                    repeatCount = 1;
                }
                counts[index, repeatCount]++;
            }

            // Acuumulate suffix sum
            for (int i = 0; i < 26; i++)
            {
                for (int j = s.Length - 1; j >= 0; j--)
                {
                    counts[i, j] += counts[i, j + 1];
                }
            }

            // Find the maximum length of special substring
            int result = -1;
            for (int i = 0; i < 26; i++)
            {
                int j = 0;
                while (counts[i, j] >= 3) j++;
                result = Math.Max(result, j - 1);
            }

            return result;
        }

        public static long LargestPerimeter(int[] nums)
        {
            long result = 0;
            long sum = 0;
            long maxNum = 0;
            long curPerimeter = 0;
            Array.Sort(nums);

            if (nums.Length == 3)
            {
                return nums[nums.Length - 1] < nums[0] + nums[1]
                    ? nums[nums.Length - 1] + nums[0] + nums[1]
                    : -1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            for (int i = nums.Length - 1; i > 1; i--)
            {
                maxNum = nums[i];
                sum -= maxNum;

                if (sum > maxNum)
                {
                    curPerimeter = sum + maxNum;

                    if (curPerimeter > result)
                    {
                        result = curPerimeter;
                    }
                    else
                    {
                        break;
                    }

                }

            }

            return result > 0 ? result : -1;
        }

        public static int LargestPerimeterTwo(int[] nums)
        {
            var result = 0;
            var w = 2;
            var sum = 0;
            Array.Sort(nums);
            int c = nums[nums.Length - 1];

            for (int i = 0; i < nums.Length - w; i++)
            {
                for (int j = i; j < w + i; j++)
                {
                    sum += nums[j];
                }

                if (sum > c)
                {
                    var perimeter = sum + c;

                    result = result < perimeter ? perimeter : result;
                }
                sum = 0;
            }
            return result;
        }
        public static string StringChallengeTwo(string str)
        {
            //Or i can use just split(' ') and than change firs letter
            //Or use regex to finde firs letter and then change them;
            if (str.Length == 0)
            {
                return string.Empty;
            }

            var result = new StringBuilder();
            var prevLetter = char.IsLower(str[0]) ? char.ToUpper(str[0]) : str[0];
            result.Append(prevLetter);

            for (int i = 1; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(prevLetter) && char.IsLower(str[i]))
                {
                    result.Append(char.ToUpper(str[i]));
                }
                else
                {
                    result.Append(str[i]);
                }

                prevLetter = str[i];
            }

            return result.ToString();
        }

        public static string StringChallenge(long num)
        {
            var nums = num.ToString();
            var curNum = 0;
            var prevNum = 0;
            var result = new StringBuilder();

            for (int i = 1; i < nums.Length; i++)
            {
                prevNum = int.Parse(nums[i - 1].ToString());
                curNum = int.Parse(nums[i].ToString());

                if (prevNum != 0 && curNum != 0)
                {
                    if (prevNum % 2 != 0 && curNum % 2 != 0)
                    {
                        result.Append($"{prevNum}-");
                    }
                    else if (prevNum % 2 == 0 && curNum % 2 == 0)
                    {
                        result.Append($"{prevNum}*");
                    }
                    else
                    {
                        result.Append($"{prevNum}");
                    }
                }
                else
                {
                    result.Append($"{prevNum}");
                }
            }

            result.Append($"{curNum}");

            return result.ToString();
        }

        public static int IncremovableSubarrayCount(int[] nums)
        {
            var w = 0;
            var result = 0;
            var prev = 0;
            var start = 0;
            var last = 0;
            var isIncremovable = false;

            for (; w < nums.Length; w++)
            {

                for (int i = 0; i < nums.Length - w; i++)
                {
                    isIncremovable = true;

                    start = i;
                    last = i + w;

                    if (nums.Length - w - 2 > 0)
                    {
                        prev = start > 0 ? nums[0] : nums[last + 1];
                        int j = start == 0 ? last + 2 : start > 1 ? 1 : last + 1;

                        for (; j < nums.Length; j++)
                        {
                            if (j < start || j > last)
                            {
                                var num = nums[j];
                                if (prev < num)
                                {
                                    prev = nums[j];
                                }
                                else
                                {
                                    isIncremovable = false;
                                    break;
                                }
                            }
                        }

                        result = isIncremovable ? result + 1 : result;
                    }
                    else
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        public static bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0) return true;
            var j = 0;
            for (int i = 0; i < t.Length && j < s.Length; i++)
            {
                if (s[i] == s[j])
                {
                    j++;
                }
            }
            return (j == s.Length) ? true : false;

            //if (s.Length == 0) return true;
            //var sb = new StringBuilder(t);
            //var j = 0;
            //for (int i = 0; i < sb.Length; i++)
            //{
            //    if (j == sb.Length) return true;
            //    if (sb[i] == s[j])
            //    {
            //        j++;

            //    }
            //    else
            //    {
            //        sb.Remove(i, 1);
            //        i--;
            //    }
            //}
            //return (sb.ToString() == s) ? true : false;
        }

        public static void MoveZeroes(int[] nums)
        {
            var j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[j], nums[i]) = (nums[i], nums[j++]);
                }
            }
        }

        public static void MergeSort(int[] array)
        {
            if (array.Length <= 1) return;
            int middle = array.Length / 2;
            int[] leftArr = new int[middle];
            int[] rightArr = new int[array.Length - middle];
            int i = 0, j = 0;

            for (; i < array.Length; i++)
            {
                if (i < middle)
                {
                    leftArr[i] = array[i];
                }
                if (i >= middle)
                {
                    rightArr[j++] = array[i];
                }
            }
            MergeSort(leftArr);
            MergeSort(rightArr);
            Merge(leftArr, rightArr, array);
        }

        public static void Merge(int[] leftArr, int[] rightArr, int[] array)
        {
            int i = 0, l = 0, r = 0;
            while (l < leftArr.Length && r < rightArr.Length)
            {
                if (leftArr[l] < rightArr[r])
                {
                    array[i++] = leftArr[l++];
                }
                else
                {
                    array[i++] = rightArr[r++];
                }
            }
            while (l < leftArr.Length)
            {
                array[i++] = leftArr[l++];
            }
            while (r < rightArr.Length)
            {
                array[i++] = rightArr[r++];
            }
        }

        public static void BubleSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                    }
                }
            }
        }

        public static IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 1)
            {
                return new List<string>() { $"{nums[0]}" };
            }
            var list = new List<string>();
            var firstNum = nums[0];
            var isSingleNum = true;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] - nums[i] != -1)
                {
                    if (isSingleNum)
                    {
                        list.Add($"{firstNum}");
                        firstNum = nums[i];
                    }
                    else
                    {
                        list.Add($"{firstNum}->{nums[i - 1]}");
                        firstNum = nums[i];
                        isSingleNum = true;
                    }
                }
                else
                {
                    isSingleNum = false;
                }
            }
            return list;
        }

        public static char NextGreatestLetter(char[] letters, char target)
        {
            var i = BinarySearch(letters, target);
            return i;
        }

        public static int BinarySearchRecursive(int[] nums, int target, int index)
        {
            if (nums.Length == 1) return nums[0] == target ? index : -1;
            int middle = nums.Length / 2;

            if (nums[middle] > target)
            {
                var leftArr = new int[middle];
                for (int i = 0; i < nums.Length - middle; i++)
                {
                    if (i < middle) leftArr[i] = nums[i];
                }
                return BinarySearchRecursive(leftArr, target, index);
            }
            else
            {
                var j = 0;
                var rightArr = new int[nums.Length - middle];
                for (int i = middle; i < nums.Length; i++)
                {
                    if (i >= middle) rightArr[j++] = nums[i];
                }
                return BinarySearchRecursive(rightArr, target, middle += index);
            }
        }

        public static char BinarySearch(char[] letters, char target)
        {
            if (target >= letters[letters.Length - 1]) return letters[0];
            if (target < letters[0]) return letters[0];

            var left = 0;
            var right = letters.Length - 1;
            var mid = 0;
            while (left <= right && target <= letters[right])
            {
                mid = (left + right) / 2;
                if (target == letters[mid])
                {
                    var i = 1;
                    while (letters[mid + i] == target)
                    {
                        i++;
                    }
                    return letters[mid + i];
                }

                if (target < letters[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (left > 0) return letters[left];

            return target;
        }

        public static int BinarySearchSecond(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var dictS = new Dictionary<char, int>();
            var dictT = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                AddToTictionary(s[i], dictS, i);
                AddToTictionary(t[i], dictT, i);
            }
            if (dictS.Count != dictT.Count) return false;

            for (int i = 0; i < dictS.Count; i++)
            {
                //if (dictS.ElementAt(i).Key == dictT.ElementAt(i).Key) return false;
                if (dictS.ElementAt(i).Value != dictT.ElementAt(i).Value) return false;
            }

            return true;
        }

        public static void AddToTictionary(char s, Dictionary<char, int> dict, int i)
        {
            if (dict.ContainsKey(s))
            {
                dict[s] += 1 + i;
            }
            else
            {
                dict.Add(s, 1);
            }
        }


        public static void InOrder(TreeNode root, ref int value, ref int delta)
        {
            if (root == null) return;
            InOrder(root.left, ref value, ref delta);
            delta = Math.Min(delta, Math.Abs(value - root.val));
            value = root.val;
            InOrder(root.right, ref value, ref delta);



        }

        static void Test(int[] nums1, int m, int[] nums2, int n)
        {
            var a = m - 1;
            var b = n - 1;
            for (int i = m + n - 1; i >= 0; i--)
            {
                if (a >= 0 && b >= 0)
                {
                    if (nums1[a] > nums2[b])
                    {
                        nums1[i] = nums1[a];
                        nums1[a] = 0;
                        a--;
                    }
                    else if (nums1[a] < nums2[b])
                    {
                        nums1[i] = nums2[b];
                        b--;
                    }
                    else if (nums1[a] == nums2[b])
                    {
                        nums1[i] = nums2[b];
                        b--;
                        i--;
                        nums1[i] = nums1[a];
                        if (a != i)
                        {
                            nums1[a] = 0;
                        }
                        a--;

                    }
                }
                else
                {
                    if (a < 0 && b >= 0)
                    {
                        nums1[i] = nums2[b];
                        b--;
                    }
                    else if (a >= 0 && b < 0)
                    {
                        nums1[i] = nums1[a];
                        //nums1[a] = 0;
                        a--;
                    }
                }
            }
        }

        static void SingleResponsibilityOne()
        {
            IPrinter printer = new _1.SingleResponsibilityPrinciple.GroupedByMethod.GoodPractice.ConsolePrinter();
            Report report = new Report();
            report.Text = "Hello Wolrd";
            report.Print(printer);
        }

        static void SingleResponsibilityTwo()
        {
            MobileStore store = new MobileStore(
                new ConsolePhoneReader(),
                new GeneralPhoneBinder(),
                new GeneralPhoneValidator(),
                new TextPhoneSaver());
            store.Process();
        }

        static void OpenClosedPrinciplePatternStrategy()
        {
            PatternStrategy.Cook bob = new PatternStrategy.Cook("Bob");
            bob.MakeDinner(new PatternStrategy.Models.PotatoMeal());
            Console.WriteLine();
            bob.MakeDinner(new PatternStrategy.Models.SaladMeal());
        }

        static void OpenClosedPrinciplePatternTemplatesMethod()
        {
            PatternTemplateMethod.Models.AbstractMealBase[] menu = new PatternTemplateMethod.Models.AbstractMealBase[]
            {
                new PatternTemplateMethod.Models.PotatoMeal(),
                new PatternTemplateMethod.Models.SaladMeal() };

            PatternTemplateMethod.Cook bob = new PatternTemplateMethod.Cook("Bob");
            bob.MakeDinner(menu);
        }

        static void LiskovSubstitutionPrincipleBadPractice()
        {
            BadPractice.Rectangle rect = new BadPractice.Square();

            rect.Height = 5;
            rect.Width = 10;
            if (rect.GetArea() != 50)
                Console.WriteLine("Некорректная площадь!");
        }

        /*С точки зрения класса Account метод InitializeAccount() вполне является работоспособным. 
         * Однако при передаче в него объекта MicroAccount мы столкнемся с ошибкой. 
         * В итоге пинцип Лисков будет нарушен.*/
        static void LiskovSubstitutionPrincipleBadPracticePrecoonditions()
        {
            BadPractice.Preconditions.Account acc = new BadPractice.Preconditions.MicroAccount();
            acc.SetCapital(200);
            Console.WriteLine(acc.Capital);
        }

        /*Исходя из логики класса Account, в методе CalculateInterest мы ожидаем получить в качестве результата числа 1200. 
         * Однако логика класса MicroAccount показывает другой результат. 
         * В итоге мы приходим к нарушению принципа Лисков, 
         * хотя формально мы просто применили стандартные принципы ООП - полиморфизм и наследование.*/
        static void LiskovSubstitutionPrincipleBadPracticePostconditions()
        {
            BadPractice.Postconditions.Account acc = new BadPractice.Postconditions.MicroAccount();
            decimal sum = acc.GetInterest(1000, 1, 10); // 1000 + 1000 * 10 / 100 + 100 (бонус)
            if (sum != 1200) // ожидаем 1200
                Console.WriteLine("Неожиданная сумма при вычислениях");
        }

        static void DependencyInversionPrinciple()
        {
            Book book = new Book(new _5.DependencyInversionPrinciple.GoodPractice.Models.ConsolePrinter());
            book.Print();
            book.Printer = new HtmlPrinter();
            book.Print();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class MyKey
        {
            public string Key { get; }

            public MyKey(string key)
            {
                Key = key;
            }

            public override bool Equals(object obj)
            {
                if (obj is MyKey other)
                {
                    return other != null &&
                       Key.Equals(other.Key);
                }

                return false;
            }

            // Переопределяем GetHashCode так, чтобы все объекты имели одинаковый хэш-код
            public override int GetHashCode()
            {
                return Key.GetHashCode(); // Намеренно возвращаем одно и то же значение для всех ключей
            }

            public override string ToString()
            {
                return Key;
            }
        }

        public interface IDataProvider : IDisposable
        {
            int LongRunningCalculation(int firstValue, int secondValue);
        }

        public sealed class DataProvider : IDataProvider
        {
            public int LongRunningCalculation(int firstValue, int secondValue)
            {
                return firstValue + secondValue;
            }

            public void Dispose() { }
        }

        //Код для ревью:
        public sealed class DataProviderService
        {
            private static ConcurrentDictionary<(int, int), object> _dictionary;

            static DataProviderService()
            {
                _dictionary = new ConcurrentDictionary<(int, int), object>();
                InitDictionary();
            }

            public int? GetValue(int index, int index2)
            {
                var keys = (index, index2);
                if (_dictionary.TryGetValue(keys, out var value) && value is int)
                    return (int)_dictionary[keys];

                return null;
            }

            private static void InitDictionary()
            {
                using (DataProvider provider = new DataProvider())
                {
                    for (int i = 0; i <= 99; i++)
                        for (int j = 0; j <= 12; j++)
                            _dictionary[(i, j)] = provider.LongRunningCalculation(i, j);
                }
            }
        }
    }
}
