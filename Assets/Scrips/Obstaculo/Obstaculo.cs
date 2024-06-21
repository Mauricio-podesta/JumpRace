using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public Transform initialPosition; // La posici�n inicial del jugador

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica si el objeto tocado es el jugador
        {
            // Si el jugador toca el objeto da�ino, lo enviamos de vuelta a la posici�n inicial
            collision.gameObject.transform.position = initialPosition.position;
            
        }
    }
}
