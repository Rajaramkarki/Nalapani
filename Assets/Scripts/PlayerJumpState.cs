using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private const float CrossFadeDuration = 0.1f;

    public PlayerJumpState(PlayerStateMachine statemachine) : base(statemachine) { }

    public override void Enter()
    {
        stateMachine.Velocity = new Vector3(stateMachine.Velocity.x, stateMachine.jumpSpeed, stateMachine.Velocity.z);

        stateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
    }

    public override void Tick()
    {
        ApplyGravity();
        Move();

        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }

        //FaceMoveDirection();
        //Move();
    }

    public override void Exit() { }
}