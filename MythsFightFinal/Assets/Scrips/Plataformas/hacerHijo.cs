using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacerHijo : MonoBehaviour
{
    // Mientras el jugador este en contacto con la plataforma, va a ser hijo de esta.

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            collision.transform.SetParent(this.gameObject.transform);
        }
    }

    // Cuando el jugador salga de la colision con la plataforma deja de ser hijo de esta

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            collision.transform.SetParent(null);
        }
    }
}
