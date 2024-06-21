using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForceMin = 5f; // Fuerza mínima del salto
    public float jumpForceMax = 15f; // Fuerza máxima del salto
    public float maxJumpTime = 0.5f; // Tiempo máximo que se puede mantener presionada la tecla de salto
    public float moveSpeed = 5f; // Velocidad de movimiento lateral

    private float jumpTimeCounter;
    private bool isJumping = false;
    private float initialXPosition; // Posición inicial en X al comenzar el salto

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTimeCounter = 0f;
            initialXPosition = transform.position.x; // Guardar la posición inicial en X
        }

        // Control del salto
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter < maxJumpTime)
            {
                jumpTimeCounter += Time.deltaTime;
            }
            else
            {
                jump(maxJumpTime);
            }
        }

        // Finalizar el salto si se suelta la tecla
        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            jump(jumpTimeCounter);
        }
    }

    void FixedUpdate()
    {
        // Ajustar la posición en X basándonos en la duración del salto
        if (isJumping)
        {
            float distanceX = Mathf.Abs(transform.position.x - initialXPosition); // Distancia en X desde el inicio del salto
            float moveAmount = Mathf.Lerp(0f, moveSpeed, distanceX / maxJumpTime); // Cantidad de movimiento basada en la distancia en X y la duración del salto
            transform.position += Vector3.right * moveAmount * Time.fixedDeltaTime;
        }
    }

    void jump(float jumpTime)
    {
        float jumpForce = Mathf.Lerp(jumpForceMin, jumpForceMax, jumpTime / maxJumpTime);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float direction = Mathf.Sign(horizontalInput); // Dirección del movimiento lateral

        rb.velocity = new Vector2(moveSpeed * direction, jumpForce);
        isJumping = false;
    }
}
