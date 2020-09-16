using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_12_Generics
{
    internal sealed class GenericTypeThatRequiresAnEnum<T>
    {
        static GenericTypeThatRequiresAnEnum()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }
    }
}
