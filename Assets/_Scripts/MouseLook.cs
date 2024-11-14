using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 2f;
    
    float _minVert = -45f;
    float _maxVert = 45f;

    private float _verticalInput = 0f;
    private float _horizontalInput = 0f;
    private Rigidbody _rb;


    public enum RotationAxis
    {
        XRotation,
        YRotation,
        XYRotation
    }

    public RotationAxis rotationAxis = RotationAxis.XYRotation;


    private void Start()
    {
        if (_rb != null)
            _rb.freezeRotation = true;
    }

    private void Update()
    {
        Look(this.rotationAxis);
    }

    private void Look(RotationAxis rotationAxis)
    {
        float delta = Input.GetAxis("Mouse X") * _sensitivity;
        _horizontalInput = transform.localEulerAngles.y + delta;

        _verticalInput -= Input.GetAxis("Mouse Y") * _sensitivity;
        _verticalInput = Mathf.Clamp(_verticalInput, _minVert, _maxVert);

        if (rotationAxis == RotationAxis.XRotation)
        {
            transform.localEulerAngles = new Vector3(transform.rotation.x, _horizontalInput, 0);
        }
        else
        {

            transform.localEulerAngles = new Vector3(_verticalInput, transform.rotation.y, 0);
        }

    }

}
