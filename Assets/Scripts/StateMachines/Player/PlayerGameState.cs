using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : PlayerBaseState
{
    public PlayerGameState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //throw new System.NotImplementedException();
    }

    public override void Tick(float deltaTime)
    {
        //Debug.Log(stateMachine.InputReader.movementval);//we fetch the movementval every tick/frame. Remember movementval is our movement: x and y is our vector2.
        //now time to move the player in a 3d place.
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.movementval.x;
        movement.y = 0; //y in this case is our height. we will implement increase when jumping later.
        movement.z = stateMachine.InputReader.movementval.y;
        //stateMachine.transform.Translate(movement * deltaTime);//movement amount will therefore be same regardless of the framerate.

        //now we can use charactercontroller to handle the collisions properly as well as move the player instead of using that above line..
        stateMachine.charactercontroller.Move(movement * deltaTime * stateMachine.FreeLookMovementSpeed);
        //character controller class, which unity has predifined, and i created a character controller object in player statemachine,
        //so the object has a move function: and the amount is movement's x, y and z:symbolizing unit sphere direction, and we multiply it with also the freelook movement speed.

        //now ill do something so that there is player rotation
        if(stateMachine.InputReader.movementval == Vector2.zero) { return; }//if the player is not moving, get out, dont do anything. We know its not moving because the movement variable is a vector 3, and if a vector2.zero holds 0,0 then that means that movement would be 0,0,0 as we currently dont' have a way to change height.
        //we are using movementval which is just a simple vecto2, so we if that vector2 is zero, then there is no movement, so there is no reason to continue on with the function.
        //but if they are moving, then we want to set the rotation:
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);//this line, the player is literaly refered as statemachine here, and we have a function for the player which is to transform its rotation.
                                            //how we transform is via quaternion. This method is a quick implementation, its not as good as it can be, which i will change in the future.


    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }

    

    // Start is called before the first frame update
    
}
