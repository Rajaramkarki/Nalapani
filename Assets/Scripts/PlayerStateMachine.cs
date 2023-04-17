using UnityEngine;


//Using RequireComponent not necessary - just good practice
//PlayerStateMachine required the GameObject (Player) to have InputReader, Animator and a Character Controller
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class PlayerStateMachine : StateMachine
{
    public Vector3 Velocity;
    public float MovementSpeed { get; private set; } = 5f;
    public float LookRotationDampFactor { get; private set; } = 10f;
    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }

    //jump is not implemented yet -- still debugging
    //public float JumpForce { get; private set; } = 5f;

    //is called once when Unity loads the scene
    private void Start()
    {
        //the transform component from camera is taken.
        //its position and rotation is later used to determine forward for the player
        MainCamera = Camera.main.transform;

        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();

        //used while debugging. Tried to set the gameobject to active before switching states
        //not necessary
        //gameObject.SetActive(true);

        //passes the PlayerMoveState by reference to the StateMachine
        SwitchState(new PlayerMoveState(this));
    }
}