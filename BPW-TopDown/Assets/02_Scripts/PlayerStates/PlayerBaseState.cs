using UnityEngine;

public abstract class PlayerBaseState
{
    public virtual void OnEnter(PlayerStateManager player) { }
    public virtual void OnUpdate(PlayerStateManager player) { }
    public virtual void OnExit(PlayerStateManager player) { }

}
