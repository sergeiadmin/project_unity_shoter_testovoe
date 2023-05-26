using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Настройки персонажа")]
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

        // Поворот игрока по оси Y
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(-Vector3.up, mouseX);

        // Перемещение игрока
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        move.y = 0f; // Отключаем вертикальное движение
        move.Normalize(); // Нормализуем вектор перемещения, чтобы сохранить постоянную скорость

        controller.Move(move * moveSpeed * Time.deltaTime);
    }


}
