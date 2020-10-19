namespace SOLID._3.LiskovSubstitutionPrinciple.BadPractice
{
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }
}
