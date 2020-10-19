using System;
using System.Collections.Generic;

namespace Ch_12_Generics
{
    // Частично определенный открытый тип
    internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue>
    {
    }
}
