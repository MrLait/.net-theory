namespace SingletonPattern.Metanit
{
    class LazySingleton
    {
        private LazySingleton() { }

        public static LazySingleton GetInstance()
        {
            return NestedSingleton._instance;
        }

        private class NestedSingleton
        {
            internal static readonly LazySingleton _instance = new LazySingleton();
            static NestedSingleton() {}

        }
    }
}
