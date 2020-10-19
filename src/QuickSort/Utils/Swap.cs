namespace Sorts.Utils
{
    public class Swap
    {
        public static void GetSwap<T>(ref T start, ref T end)
        {
            T t = start;
            start = end;
            end = t;
        }
    }
}
