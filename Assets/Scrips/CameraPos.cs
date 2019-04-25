using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{

    public GameObject A, B;
    float pos = 0;
    public float shaketime;
    [Range(0, 5)] public float radio;
    public bool Use;
    public bool rapido,aunMasRapido = false;
    float y = 0;

    void Update()
    {

        if (A.transform.position.y > y || B.transform.position.y > y)
        {
            y += Time.deltaTime * 2;
            rapido = true;
        }
        else if(A.transform.position.y > y +3 || B.transform.position.y > y + 3)
        {
            y += Time.deltaTime * 4;
            aunMasRapido = true;
        }
        else
        {
            y += Time.deltaTime;
            rapido = false;
        }

        pos = A.transform.position.x - B.transform.position.x;

        if (Use)
            StartCoroutine(shaking());
        else
            transform.position = new Vector3(A.transform.position.x - pos/2,y,-10);
    }

    IEnumerator shaking()
    {
        float timer = 0;
        while (Use)
        {
            timer += Time.deltaTime;
            transform.position = transform.position + Random.insideUnitSphere * radio;
            yield return new WaitForEndOfFrame();
            if (timer > shaketime)
                Use = false;
        }
        yield return null;
    }
}
