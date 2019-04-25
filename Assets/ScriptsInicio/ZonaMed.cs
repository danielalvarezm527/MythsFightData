using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMed : MonoBehaviour {

    public float VelocidadM = 0;

    public bool EnMe;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            EnMe = true;
            VelocidadM = 40f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnMe = false;

    }

}
