using Mediator.MetanitExOne.Abstract;

namespace Mediator.MetanitExOne
{
    abstract class Colleague
    {
        protected MediatorAbstract mediator;

        public Colleague(MediatorAbstract mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
}
