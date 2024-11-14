using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 3f;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 movDir = new Vector3(horizontalMovement, 0, verticalMovement);

        movDir = transform.TransformDirection(movDir);

        if (_characterController != null)
        {

            _characterController.Move(movDir.normalized * _speed * Time.deltaTime);
        }
    }


}
