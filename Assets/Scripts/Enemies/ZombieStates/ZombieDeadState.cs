using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    int movementZHash = Animator.StringToHash("MovementZ");
    int isDeadHash = Animator.StringToHash("isDead");
    public ZombieDeadState(ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {

    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavmeshAgent.isStopped = true;
        ownerZombie.zombieNavmeshAgent.ResetPath();

        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavmeshAgent.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isDeadHash, false);
    }
}
