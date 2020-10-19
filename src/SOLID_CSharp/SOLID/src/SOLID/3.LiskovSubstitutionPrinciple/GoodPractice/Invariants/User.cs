using System;

namespace SOLID._3.LiskovSubstitutionPrinciple.GoodPractice.Invariants
{
    /*Поле age выступает инвариантом. 
     * И поскольку его установка возможна только через конструктор или свойство, 
     * то в любом случае выполнение предусловия и в конструкторе, 
     * и в свойстве гарантирует, что возраст не будет меньше 0. 
     * И данное объектоятельство сохранит свою истинность на протяжении всей жизни объекта User.*/
    class User
    {
        protected int age;

        public User(int age)
        {
            if (age < 0)
                throw new Exception("возраст меньше нуля");

            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new Exception("возраст меньше нуля");
                age = value;
            }
        }
    }
}
