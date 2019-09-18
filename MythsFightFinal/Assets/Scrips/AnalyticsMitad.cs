using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsMitad : MonoBehaviour
{
    public string evento;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Jugador")
            AudioManager.audioManager.EventTriger(evento);

    }
}
