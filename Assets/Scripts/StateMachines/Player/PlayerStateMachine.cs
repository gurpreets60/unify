using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField]  public InputReader InputReader { get; private set; }
    //the get and set mean, that you can publicly get the inputreader, so anyone can read this, but only privately can you set it.

    //unity by default does not have every variable serialized, to make it a serialized field, include serialize field before the variable declaration,
    //but keep in mind, since our input reader is a property, and properties are not automatically put into a serialized field even after the keyword,
    //you must use the field infront.

    //so now whenever you want to reference something from outside of our state, we add field:serializefield public and whatever it is and get;private set; then we can access it from our state.
    //we can do this with the animator, the character controller, the health script, and etc. we can add a line like above, but we change what it actually is, and then referencing it in the inspector.

    //Gonna add a charactercontroller as a reference for the playerstatemachine. To do this, I'll do the same technique as what i did with add input reader as a reference.
    [field: SerializeField] public CharacterController charactercontroller { get; private set; }

    //here im creating a movement speed variable. We can have multiple, not just for free look, but for other states as well, so i will add them in the future.
    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    //another example could be targeting movement speed.
    private void Start()
    {
        //SwitchState(new PlayerTestState(this));//this is the keyword referencing the instance we are currently in.
        //more importantly PlayerTestState(this) returns the PlayerTestState we wish to use as our state.
        SwitchState(new PlayerGameState(this));
    }

    /* Update is called once per frame
    void Update()
    {
        
    }*/
}
