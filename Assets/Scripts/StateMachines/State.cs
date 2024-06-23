using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter();
    public abstract void Tick(float deltaTime); //tick is called every frame. We want movement to be smooth regardless of framerate. deltatime is required for time between previous and curr frame.
    public abstract void Exit();
}
