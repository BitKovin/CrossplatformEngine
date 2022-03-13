using Box2DX.Dynamics;

namespace Engine.Physics
{
    public class Solver : ContactListener
    {
        public delegate void EventSolver(Entity body1, Entity body2,ContactPoint point);
        public event EventSolver OnAdd;
        public event EventSolver OnPersist;
        public event EventSolver OnResult;
        public event EventSolver OnRemove;

        public override void Add(ContactPoint point)
        {
            base.Add(point);

            OnAdd?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData(), point);
        }

        public override void Persist(ContactPoint point)
        {
            base.Persist(point);

            OnPersist?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData(),point);
        }

        public override void Result(ContactResult point)
        {
            base.Result(point);

            OnResult?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData(), null);
        }

        public override void Remove(ContactPoint point)
        {
            base.Remove(point);

            OnRemove?.Invoke((Entity)point.Shape1.GetBody().GetUserData(), (Entity)point.Shape2.GetBody().GetUserData(), point);
        }
    }

}
