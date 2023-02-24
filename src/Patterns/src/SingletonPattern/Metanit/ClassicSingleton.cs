namespace SingletonPattern.Metanit
{
    class ClassicSingleton
    {
        private static ClassicSingleton _instance;
        static ClassicSingleton()
        {
        }

        public static ClassicSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClassicSingleton();
            }
            return _instance;
        }

        // Наконец, любой одиночка должен содержать некоторую бизнес-логику,
        // которая может быть выполнена на его экземпляре.
        public void SomeBusinessLogic()
        {
            // ...
        }
    }
}
