using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    // posicion inicial y final de la plataforma
    public float posInicial = 0;
    public float posFinal = 0;

    // unidades de movimiento para la plataforma
    public int adicion;

    // bool generico para seleccionar si la plataforma se mueve en X o Y
    public bool Y = false;

    void Start()
    {
        // asignacion de las posiciones 

        if (Y == false)
        {
            posInicial = this.gameObject.transform.position.x;
            posFinal = this.gameObject.transform.position.x + adicion;
        }
        else
        {
            posInicial = this.gameObject.transform.position.y;
            posFinal = this.gameObject.transform.position.y + adicion;
        }
        
        StartCoroutine(mover());
    }

    // Corrutina encargada del movimiento de las plataformas 
    IEnumerator mover()
    {
        if (Y == false)
            posFinal = this.gameObject.transform.position.x + adicion;
        else
            posFinal = this.gameObject.transform.position.y + adicion;


        while (posInicial < posFinal)
        {
            if (Y == false)
            {
                posInicial = this.gameObject.transform.position.x;
                this.gameObject.transform.Translate(0.15f, 0, 0);
            }
            else
            {
                posInicial = this.gameObject.transform.position.y;
                this.gameObject.transform.Translate(0, 0.15f, 0);
            }

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.7f);

        if (Y == false)
            posFinal = this.gameObject.transform.position.x - adicion;
        else
            posFinal = this.gameObject.transform.position.y - adicion;

        while (posInicial > posFinal)
        {
            if (Y == false)
            {
                posInicial = this.gameObject.transform.position.x;
                this.gameObject.transform.Translate(-0.15f, 0, 0);

            }
            else
            {
                posInicial = this.gameObject.transform.position.y;
                this.gameObject.transform.Translate(0, -0.15f, 0);

            }

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(mover());
    }
}
