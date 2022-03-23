using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieComponent : MonoBehaviour
{
    public float zombieDamage = 5;

    public NavMeshAgent zombieNavmeshAgent;
    public Animator zombieAnimator;
    public ZombieStateMachine statemachine;
    public GameObject followTarget;

    private void Awake()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieNavmeshAgent = GetComponent<NavMeshAgent>();
        statemachine = GetComponent<ZombieStateMachine>();
        
    }

    private void Start()
    {
        Initialize(followTarget);
    }


    public void Initialize(GameObject _followTarget)
    {
        followTarget = _followTarget;

        ZombieIdleState idlestate = new ZombieIdleState(this, statemachine);
        statemachine.AddState(ZombieStateType.Idling, idlestate);

        ZombieFollowState followState = new ZombieFollowState(followTarget, this, statemachine);
        statemachine.AddState(ZombieStateType.Following, followState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, statemachine);
        statemachine.AddState(ZombieStateType.Attacking, attackState);

        ZombieDeadState deadState = new ZombieDeadState(this, statemachine);
        statemachine.AddState(ZombieStateType.isDead, deadState);

        statemachine.Initialize(ZombieStateType.Following);
    }
}
