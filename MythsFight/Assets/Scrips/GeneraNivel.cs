using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraNivel : MonoBehaviour
{
    public GameObject[] variaciones = new GameObject[2];

    private void Awake()
    {

        int value = Random.Range(0, variaciones.Length);

        for(int i = 0;i < variaciones.Length; i++)
        {
            if(i == value)
            {
                variaciones[i].SetActive(true);
            }
            else
            {
                variaciones[i].SetActive(false);
            }
        }

    }
}
