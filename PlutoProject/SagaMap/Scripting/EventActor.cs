using SagaDB.Actor;

namespace SagaMap.Scripting
{
    public abstract class EventActor : Event
    {
        ActorEvent actor;

        public ActorEvent Actor
        {
            get { return this.actor; }
            set { this.actor = value; }
        }

        public abstract EventActor Clone();
    }
}
