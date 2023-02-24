namespace SingletonPattern.Metanit
{
    class LockSingleton
    {
        private static LockSingleton _instance;
        private static object _syncRoot = new object();

        static LockSingleton()
        {
        }

        public static LockSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new LockSingleton();
                    }
                }
            }

            return _instance;
        }
    }
}
