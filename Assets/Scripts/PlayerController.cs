using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Joystick joystick;
    [SerializeField] private bool isRunning;
    [SerializeField] private Transform charakter;
    private Animator animator;
    private Vector3 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        joystick.OnJoystickInputChanged += StartMove;
        joystick.OnJoystickUpDelegate += StopMove;
    }

    public void StopMove()
    {
        movement = Vector3.zero;
        animator.SetBool("IsRunning", false);
        isRunning = false;
    }

    private void StartMove(Vector3 inputDirection)
    {
        movement = new Vector3(inputDirection.x, 0f, inputDirection.y) * moveSpeed;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = targetRotation;
        }

        //transform.Translate(movement, Space.World);
        animator.SetBool("IsRunning", true);
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            transform.Translate(movement * Time.deltaTime, Space.World);
        }      
    }

    private void OnDestroy()
    {
        joystick.OnJoystickInputChanged -= StartMove;
        joystick.OnJoystickUpDelegate -= StopMove;
    }
}