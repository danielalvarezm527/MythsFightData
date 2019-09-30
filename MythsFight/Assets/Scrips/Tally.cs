using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tally : MonoBehaviour
{
    public static string tiempo;
    public static string nombre;
    public static int monedas;

    void Awake()
    {
        if(FindObjectOfType<Tally>() != null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
