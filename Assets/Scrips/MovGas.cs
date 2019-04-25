using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGas : MonoBehaviour
{
    public CameraPos CameraPos;
    GameObject gas;
    float y;

    void Start()
    {
        gas = this.gameObject;
        y = gas.transform.position.y;
    }

    void Update()
    {

        if(CameraPos.aunMasRapido == true)
        {
            y += Time.deltaTime * 4;
        }
        else if (CameraPos.rapido == true)
        {
            y += Time.deltaTime * 2;
        }
        else
            y += Time.deltaTime;

        gas.transform.position = new Vector2(gas.transform.position.x, y);
    }
}
