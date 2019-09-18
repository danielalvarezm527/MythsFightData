using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaImpulso : MonoBehaviour
{
    // Script de impulso

    public Rigidbody2D jugador;
    public float force;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {            
            // Cuando el jugador entra en contacto con la plataforma, esta obtiene los componentes y le hace un impulso al player hacia arriba 

            jugador = collision.gameObject.GetComponent<Rigidbody2D>();
            force = jugador.velocity.y;
            jugador.velocity = Vector3.zero;
            jugador.AddForce(transform.up * force * -60);
        }
    }
}
