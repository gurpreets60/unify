using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    //private int remainingTime = 10*60;
    //private float timer = 5f;//symbolizes 5 seconds
    //private float timer;//new timer will be used to track how long we have been in the state for.
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter");
        stateMachine.InputReader.JumpEvent += OnJump;
        stateMachine.InputReader.DodgeEvent += OnDodge;
    }

    public override void Tick(float deltaTime)
    {
        //stateMachine.InputReader.JumpEvent += Enter;
        //^ above is a way to subscribe to the jump event, which we access through the input reader. we subscribe to the enter function, if its plus, if it's minus, we stop subscribing to enter.

        //timer += deltaTime;//delta time is how much time is past from the previous frame and the current frame.
        //Debug.Log(timer);
        
        /*if (timer <= 0f)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));//must use statemachine because only it has the switchstate function access
            //when creating the new playerTestState, we have to use reference to the stateMachine instead of this
            //this line creates a new object for playerteststate with the current stateMachine, but it provides a new statemachine
            //in all new instance of playerteststate is formed.
            //in the playerteststate class, we call the constructors of all the parents, as such the playerbase state class, we use the constructor to reasign a new statemachine
        }
        */

        /*if (remainingTime == 0)
        {
            Exit();
        }
        Debug.Log(remainingTime);
        remainingTime -= 1;
        */
    }
    private void OnJump()
    {
        Debug.Log("jump");
        stateMachine.SwitchState(new PlayerTestState(stateMachine));//timer resets because when we subscribe to the jumpevent, jump method is called and a playerteststate is switched as the state which then leads to the timer being 0, as when we create a new player test state object, that timer starts at 0, and every tick increments the timer
        //also since we subscribed to the jumpevent on start, we can call the onjump function whenever we press space.
        //same method applies for our dodgeevent, and others which i decide to implement in the future.
        //we can have different timers for each to test, and remember we don't just use this for timers, timers is just there for us to test, our functions should actually be doing something, like jump will move the player up. dodge will dodge.
    }

    private void OnDodge()
    {
        Debug.Log("dodge");
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
        //remember when we switch states, our switch state method exits the current state, then enters the new state.
    }

    public override void Exit()
    {
        Debug.Log("Exit");
        stateMachine.InputReader.JumpEvent -= OnJump;
        stateMachine.InputReader.DodgeEvent -= OnDodge;
    }
}
