using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    // Start is called before the first frame update
    public event Action JumpEvent;//we create a jump event. When adding other actions/keys we add those as events as well.
    public event Action DodgeEvent;

    //movement will not be an event. we just need a property to know what type of movement we are currently doing.
    public Vector2 movementval { get; private set; }
    //once again, we can get publicly, but can only set privately.

    private Controls controls;//we need access to the controls, so lets create an object for that


    private void Start()
    {
        //create a new instance of the controls
        controls = new Controls();//this class handles recieving the input, but so far doesn't know to call the jump method when jump is pressed.
        controls.Player.SetCallbacks(this);//whenever the actions happen, it will call the functions associated with those actions, ie onjump
        //player is our action map
        //on start we should enable.
        controls.Player.Enable();

    }

    
    private void OnDestroy()
    {
        controls.Player.Disable();// when we are done or need to switch action maps, we need to disable the player action map, to one we need.
    }
    
    //the parameter for the onjump function, is context. this will basically let us know what happened:tells us how the jump button was used.
    //in our example, we only care when the jump button is pressed, not held down or tapped slightly.
    public void OnJump(InputAction.CallbackContext context)//whenever we press the jump button, this code will execute
    {
        //we want to know if the button was performed(context.performed means pressed). If not, then return, else invoke the jump event.
        if (!context.performed) //context. has many different types of functions, such as cancelled and etc. good to look into further.
        {
            return;
        }
        JumpEvent?.Invoke();
        //Debug.Log("Jump");
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        DodgeEvent?.Invoke();
    }


    //whenver the wasd keys are pressed, onmove will be called and we can assign the movementval to the respected values.
    public void OnMove(InputAction.CallbackContext context)
    {
        movementval = context.ReadValue<Vector2>(); //we use context to see what we have pressed. then we assign that value into our movementval.

    }
}
