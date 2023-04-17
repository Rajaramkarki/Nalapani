using UnityEngine;


//basically contains all the common logic for all the states
public abstract class PlayerBaseState : State
{
    protected readonly PlayerStateMachine stateMachine;

    //constructor of the class
    //creates a PlayerStateMachine and then assigns reference to the stateMachine
    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    //this calculates the direction for moving the player based on the position of the camera
    //forward is always where the camera is facing at
    //and similarly  the left, right and back
    //all controlled by W, A, S and D
    //the actual movement is not done here, the values are just put into Velocity.x and Velocity.z
    //this will be called later in Tick method so it calculated the position and velocity every frame
    protected void CalculateMoveDirection()
    {
        //the y value is not necessary as we are only concerned with the position.

        Vector3 cameraForward = new(stateMachine.MainCamera.forward.x, 0, stateMachine.MainCamera.forward.z);
        Vector3 cameraRight = new(stateMachine.MainCamera.right.x, 0, stateMachine.MainCamera.right.z);

        Vector3 moveDirection = cameraForward.normalized * stateMachine.InputReader.MoveComposite.y + cameraRight.normalized * stateMachine.InputReader.MoveComposite.x;

        stateMachine.Velocity.x = moveDirection.x * stateMachine.MovementSpeed;
        stateMachine.Velocity.z = moveDirection.z * stateMachine.MovementSpeed;
    }

    //we face the player so that it faces the direction it is moving.
    //If we just move forward and move the camera, the player is still centered in the camera
    protected void FaceMoveDirection()
    {
        Vector3 faceDirection = new(stateMachine.Velocity.x, 0f, stateMachine.Velocity.z);

        if (faceDirection == Vector3.zero)
            return;

        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), stateMachine.LookRotationDampFactor * Time.deltaTime);
    }


    //applies constant downward force to the player's velocity in the Y-axis
    //Compares with the Physics.gravity.y (default is -9.8)
    //Can be used for Jump action, is also used for Move
    protected void ApplyGravity()
    {
        if (stateMachine.Velocity.y > Physics.gravity.y)
        {
            stateMachine.Velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    //the velocity calculated above is used to move in that respective direction.
    //the character controller component is used here
    protected void Move()
    {
        stateMachine.Controller.Move(stateMachine.Velocity * Time.deltaTime);
    }
}