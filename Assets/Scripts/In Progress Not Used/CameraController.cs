//using UnityEngine;
//using UnityEngine.InputSystem;

//public class CameraController : MonoBehaviour
//{
//    [SerializeField] private Transform _targetTransform;
//    [SerializeField] private float _distance = 5f;
//    [SerializeField] private float _height = 2f;
//    [SerializeField] private float _rotationDamping = 3f;
//    [SerializeField] private float _zoomSpeed = 10f;
//    [SerializeField] private float _minZoomDistance = 2f;
//    [SerializeField] private float _maxZoomDistance = 10f;

//    private Vector2 _zoomInput;
//    private float _currentDistance;

//    private void LateUpdate()
//    {
//        if (_targetTransform == null) return;

//        // Zoom in/out based on the input value
//        _currentDistance -= _zoomInput.y * _zoomSpeed * Time.deltaTime;
//        _currentDistance = Mathf.Clamp(_currentDistance, _minZoomDistance, _maxZoomDistance);

//        // Calculate the position and rotation of the camera based on the target position and distance
//        Vector3 targetPosition = _targetTransform.position + Vector3.up * _height - _targetTransform.forward * _currentDistance;
//        Quaternion targetRotation = Quaternion.LookRotation(_targetTransform.position + Vector3.up * _height - transform.position, Vector3.up);

//        // Smoothly move the camera to the new position and rotation
//        transform.position = Vector3.Lerp(transform.position, targetPosition, _rotationDamping * Time.deltaTime);
//        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationDamping * Time.deltaTime);
//    }

//    public void OnZoom(InputValue value)
//    {
//        _zoomInput = value.Get<Vector2>();
//    }
//}
