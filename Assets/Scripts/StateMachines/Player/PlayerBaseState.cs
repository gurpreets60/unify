using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    //we want shared player state methods as well as a reference to the player.
    protected PlayerStateMachine stateMachine; //protected is when only this filel and files which inherit this class can have access
                                               //compared to private where only this file has access and public where everyone that references this file has access.

    //inorder to pass in the statemachine we need, we can use a constructor to fill it in.
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine; //this refers to variables declared in this class.
        
    }
}
