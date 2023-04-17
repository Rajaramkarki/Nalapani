//not working, still debugging

using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Jump");
    private const float CrossFadeDuration = 0.1f;

    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Velocity.y = 0f;

        stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);
    }

    public override void Tick()
    {
        ApplyGravity();
        Move();

        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }

    public override void Exit() { }
}