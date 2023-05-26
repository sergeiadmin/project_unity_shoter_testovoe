using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("��������� ���������")]
    public float moveSpeed = 5f;
    public float gravity = 9.81f;
    public float jumpHeight = 2f;
    public float rotationSpeed = 5f;


    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isGrounded = controller.isGrounded;

        // ������� ������ �� ��� Y
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(-Vector3.up, mouseX);

        // ����������� ������
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        move.y = 0f; // ��������� ������������ ��������
        move.Normalize(); // ����������� ������ �����������, ����� ��������� ���������� ��������

        controller.Move(move * moveSpeed * Time.deltaTime);
    }


}
