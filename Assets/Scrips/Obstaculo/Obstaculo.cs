using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public Transform initialPosition; // La posición inicial del jugador

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica si el objeto tocado es el jugador
        {
            // Si el jugador toca el objeto dañino, lo enviamos de vuelta a la posición inicial
            collision.gameObject.transform.position = initialPosition.position;
            
        }
    }
}
