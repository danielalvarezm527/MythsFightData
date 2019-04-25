using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRange : MonoBehaviour
{
    public GameObject A, B;
    public float distanciax,distanciay,rangex,rangey = 0;
    public CinemachineVirtualCamera Camera;

    void Update()
    {
        distanciax = Mathf.Sqrt(Mathf.Pow(B.transform.position.x - A.transform.position.x, 2));
        distanciay = Mathf.Sqrt(Mathf.Pow(B.transform.position.y - A.transform.position.y, 2));
        rangex = distanciax / 2 + 2;
        rangey = distanciay+ 2;

        if(rangey < 7 && rangex < 7)
            Camera.m_Lens.OrthographicSize = 7;
        else if (rangey > 9.25f || rangex > 9.25f)
            Camera.m_Lens.OrthographicSize = 9.25f;
        else if (rangey > rangex)
            Camera.m_Lens.OrthographicSize = rangey;
        else
            Camera.m_Lens.OrthographicSize = rangex;


    }
}

//3.5,10
//5,9.25