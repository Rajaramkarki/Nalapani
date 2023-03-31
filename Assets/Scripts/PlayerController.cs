//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] private float moveSpeed = 5f;

//    private PlayerInput playerInput;
//    private Rigidbody playerRigidbody;

//    private void Start()
//    {
//        playerInput = GetComponent<PlayerInput>();
//        playerRigidbody = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {
//        if (_rigidbody != null)
//        {
//            Vector3 movement = new Vector3(_movementInput.x, 0f, _movementInput.y);
//            movement = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * movement;
//            _rigidbody.MovePosition(_rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
//        }
//    }

//    private void LateUpdate()
//    {
//        Vector3 targetPosition = transform.position;
//        targetPosition.y = 0f;
//        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition - transform.forward * 10f + Vector3.up * 3f, Time.deltaTime * 10f);
//    }

//    public void OnMovementInput(InputValue value)
//    {
//        _movementInput = value.Get<Vector2>();
//    }
//}
