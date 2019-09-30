using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{

    public GameObject[] players;
    public bool arriba;
    float y = 0;
    public float incremento = 1;
    public float shaketime;
    [Range(0, 5)] public float radio;
    
    Vector3 originpos;
    public static bool needShake = false;

    private void Start()
    {
        originpos = transform.position;
        StartCoroutine(GetPlayers());
        StartCoroutine(MovCam());
    }

    IEnumerator GetPlayers()
    {
        yield return new WaitForSeconds(0.2f);
        players = GameObject.FindGameObjectsWithTag("Jugador");
        yield return null;
    }

    void Update()
    {
        float y2 = 0;

        for (int i = 0; i<players.Length;i++)
        {
            if(players[i].transform.position.y > y2)
            {
                y2 = players[i].transform.position.y;
            }
        }

        if(y2 > y)
        {
            arriba = true;
        }
        else
        {
            arriba = false;
        }

        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        if (needShake)
            StartCoroutine(shaking());
    }

    IEnumerator MovCam()
    {
        while (true)
        {

            if (arriba)
            {
                incremento += Time.deltaTime;
            }

            if (!arriba)
            {
                incremento -= Time.deltaTime * 10;
                if(incremento < 1)
                {
                    incremento = 1;
                }
            }

            y += Time.deltaTime * incremento;

            yield return null;
        }
    }

    IEnumerator shaking()
    {
        float timer = 0;
        while (needShake)
        {
            timer += Time.deltaTime;
            transform.position = transform.position + Random.insideUnitSphere * radio;
            yield return new WaitForEndOfFrame();
            if (timer > shaketime)
                needShake = false;
        }
        while (transform.position.x < originpos.x)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
            yield return null;
        }
        while (transform.position.x > originpos.x)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
            yield return null;
        }
        yield return null;
    }
}
