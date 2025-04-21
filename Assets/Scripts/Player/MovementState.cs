using UnityEngine;

public enum MovementState { Walking, Running, Air }

public class MovementStateMachine
{
    public MovementState State;

    public void UpdateState(bool grounded, bool running)
    {
        if (!grounded)
            State = MovementState.Air;
        else if (running)
            State = MovementState.Running;
        else
            State = MovementState.Walking;
    }
}
