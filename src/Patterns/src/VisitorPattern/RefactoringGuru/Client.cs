using System.Collections.Generic;

namespace VisitorPattern.RefactoringGuru
{
    public class Client
    {
        // Клиентский код может выполнять операции посетителя над любым набором
        // элементов, не выясняя их конкретных классов. Операция принятия
        // направляет вызов к соответствующей операции в объекте посетителя.
        public static void ClientCode(List<IElement> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }
}
