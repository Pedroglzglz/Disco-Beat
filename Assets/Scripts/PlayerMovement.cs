using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.2f;

    [Header("Rotación con Ratón")]
    [SerializeField] private float mouseSensitivity = 100f;

    private CharacterController controller;
    private Vector3 velocity;
    private float verticalInput, horizontalInput;
    private float yRotation = 0f;
    private bool isGrounded;
    public bool canMove = true;


    //private Animator animator; // 👈 Referencia al Animator

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>(); // 👈 Obtener Animator

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!canMove) return;

        // Movimiento
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(move * movementSpeed * Time.deltaTime);

        // Calcular velocidad para el Animator
        float currentSpeed = new Vector2(horizontalInput, verticalInput).magnitude;
        //animator.SetFloat("Speed", currentSpeed); // 👈 Actualizar parámetro de Animator
        Debug.Log("Speed: " + currentSpeed);

        // Gravedad
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Rotación con ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Salto (opcional)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}