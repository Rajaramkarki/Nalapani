using UnityEngine;


//core logic for switching states
//will be inherited by PlayerStateMachine
//----can be used later for enemies/NPCs as well

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;


    //for switching states
    //calls exit on the current state enters the new one
    public void SwitchState(State state)
    {
        //Here ?. is null-conditional operator

        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }


    //same as from Monobehaviour, calls every frame
    //We want the tick function to execute every frame so we put it under here
    private void Update()
    {
        //Here ?. is null-conditional operator

        currentState?.Tick();
    }
}