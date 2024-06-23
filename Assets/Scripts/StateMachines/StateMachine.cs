using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    // Update is called once per frame
    private void Update()
    {
        if(currentState != null)
        {
            currentState.Tick(Time.deltaTime);
        }
        //or currentState?.Tick(Time.deltaTime); this does the same thing as the if statement. ? is the null conditional operator

    }
    public void SwitchState(State newState)
    {
        //if(currentState != null) //make sure to check if the current state is not null.
        //{
        currentState?.Exit();
        currentState = newState;//its possible that your newState could be null, just do a check with ? operator
        currentState?.Enter();
        //}
        
        
    }
}
