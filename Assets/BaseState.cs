using UnityEngine;

public abstract class BaseState
{

    public abstract void EnterState(AgentController theAgent);

    public abstract void Update(AgentController theAgent);

    public abstract void OnCollistionEnter(AgentController theAgent);

}
