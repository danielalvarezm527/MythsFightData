using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaSupe : MonoBehaviour {

    public float VelocidadS = 0;
    public float Tiempo = 0;

    public bool EnSu;

    // Use this for initialization
    void Start () {
        VelocidadS = 60f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            EnSu = true;

            VelocidadS += Time.deltaTime * 15;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        VelocidadS = 60f;

        EnSu = false;

    }
}
