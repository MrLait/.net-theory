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

namespace SOLID
{
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
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2 };
            var data = list.Where(x => x == 1);

            list.Add(1);
            var count = data.Count();
            list.Add(1);
            count = data.Count();



            Hashtable openWith = new Hashtable();
            // Add some elements to the hash table. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add(1, 1);

            foreach(var key in openWith.Values) {
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
            var nums = new int[] { 3, 1, 6, 2, 4, 5, 9, 8, 7 };
            var numsTwo = new int[] { 3, 0, 6, 0, 4, 5, 9, 0, 0 };
            var numsThree = new int[] { 0, 1, 0, 3, 12 };
            var numsFour = new int[] { 0,0, 1 };
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
                if(i >= middle)
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
            while(l < leftArr.Length && r < rightArr.Length)
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
            while(l< leftArr.Length)
            {
                array[i++] = leftArr[l++];
            }
            while(r < rightArr.Length)
            {
                array[i++] = rightArr[r++];
            }
        }

        public static void BubleSort(int[] nums)
        {
            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < nums.Length - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        (nums[j], nums[j + 1]) = (nums[j+1], nums[j]);
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
                    return letters[mid +i];
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
                    if(nums1[a] > nums2[b])
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
                        if(a != i) {
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
    }
}
