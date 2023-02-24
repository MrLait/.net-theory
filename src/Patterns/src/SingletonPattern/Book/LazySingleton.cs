namespace SingletonPattern.Book
{
    public sealed class LazySingleton
    {
        private LazySingleton() { }
        public static LazySingleton Instance
        {
            get { return SingletonHolder._instance; }
        }
        // Именно вложенный класс делает реализацию полностью «ленивой»
        private static class SingletonHolder
        {
            public static readonly LazySingleton _instance = new LazySingleton();
            // Пустой статический конструктор уже не нужен, если мы будем
            // обращаться к полю _instance лишь из свойства Instance
            // класса LazyFieldSingleton
        }
    }
}
