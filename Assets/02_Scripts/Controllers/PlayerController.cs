using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cam;

    Rigidbody rb;
    CapsuleCollider capsule;

    // 이동 구현
    float h;
    float v;
    float moveSpeed = 3f;
    Vector3 moveDir;

    bool jump = false;
    float jumpForce = 5f;

    // 회전 구현
    float mouseX;
    float mouseY;

    float sensitivityX = 2f;
    float sensitivityY = 2f;

    float pitch = 0f;
    float yaw = 0f;

    float minX = -80f;
    float maxX = 80f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = rb.GetComponent<CapsuleCollider>();        
    }    
    void Update()
    {
        MoveInput();
        MouseInput();
        
    }

    private void FixedUpdate()
    {
        Move();        
        
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float distance = (capsule.height / 2) - capsule.radius + 0.1f;
        return Physics.SphereCast(transform.position, capsule.radius, Vector3.down, out hit, distance);
    }

    void MoveInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDir = (cam.right * h + cam.forward * v);
        moveDir.y = 0f;
        moveDir = moveDir.normalized;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jump = true;
        }
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveDir * Time.fixedDeltaTime * moveSpeed);

        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }

    void MouseInput()
    {
        // 회전
        // 1. 마우스인풋 가져오기
        // 2. 회전 추가
        // 3. 위, 아래는 각도 제한걸기 80도         
        mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minX, maxX);

        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        cam.localRotation = Quaternion.Euler(pitch, 0, 0);
    }


    public bool IsMoving => (h != 0 || v != 0);
    public bool IsGroundedCheck => IsGrounded();
    
}
