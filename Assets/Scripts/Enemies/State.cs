using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected ZombieStateMachine stateMachine;

    public float UpdateInterval { get; protected set; } = 1f;

    protected State(ZombieStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Start()
    {

    }

    public virtual void IntervalUpdate()
    {

    }

    public virtual void Update()
    {


    }

    public virtual void FixedUpdate()
    { 
    
    }

    public virtual void Exit()
    { 
    
    }

}
