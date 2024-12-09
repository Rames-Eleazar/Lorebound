using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //movement speed of character
    private Rigidbody myRigidbody;
    private Vector3 change; //value of location change of character
    private Animator animator;
    public VectorValue startingPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.constraints = RigidbodyConstraints.FreezePositionY |
                                  RigidbodyConstraints.FreezeRotationX |
                                  RigidbodyConstraints.FreezeRotationZ;
        myRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.z = Input.GetAxisRaw("Vertical"); //Unlike 2D, 3D allows Z-axis to use default vertical movement inputs
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveZ", change.z);
            animator.SetBool("Moving", true);

        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        Vector3 targetPosition = transform.position + change * speed * Time.deltaTime;
        myRigidbody.MovePosition(targetPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = myRigidbody.position;
        change = Vector3.zero;
    }
}