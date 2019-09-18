using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBala : MonoBehaviour
{
    // Movimiento constante del ataque a distancia
    public float speed;

    void Update()
    {
        gameObject.transform.Translate(transform.right * speed * gameObject.transform.localScale.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Jugador")
        {
            collision.gameObject.GetComponent<CharacterControlerFinal>().TomarDaño(3);
        }
    }

}
