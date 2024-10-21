using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;
    [SerializeField] private Transform _groundCheckObject;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;
     private Animator _characterAnimator;
    private CharacterController _playerController;


    private float x;
    private float z;



    private Vector3 _velocity;
    private bool _isGrounded;


    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
        _characterAnimator = GetComponent<Animator>();
    }

    
   private void Update()
    {
        PlayerMovement();
        Jump();
        CheckingOnGrounded();

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }


    private void PlayerMovement()
    {

        _characterAnimator.SetBool("IsMoving", false);
        



        if (x < 0 || x > 0 || z < 0 || z > 0)
        {
            _characterAnimator.SetBool("IsMoving", true);


        }
        Vector3 moving = transform.right * x + transform.forward * z;
        _playerController.Move(moving * _movementSpeed * Time.deltaTime);
        _playerController.Move(_velocity * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;



    }


    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _characterAnimator.SetBool("IsJump", true);
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);

        }
        else if (_playerController.isGrounded)
        {
            _characterAnimator.SetBool("IsJump", false);
        }

    }

    private void CheckingOnGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundCheckObject.position, _groundDistance, _groundMask);


        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }

}
