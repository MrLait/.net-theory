namespace CommandPattern.Metanit
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class TVOnCommand : ICommand
    {
        readonly TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }

        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }
}
