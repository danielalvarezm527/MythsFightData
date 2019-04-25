using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public Rigidbody2D camara;

    public ZonaMed entroMede;
    public ZonaSupe entroSupe;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (entroSupe.EnSu == true)
        {
            camara.velocity = new Vector2(0f, 0f);
            camara.AddForce(transform.up * entroSupe.VelocidadS);
        }

        if (entroMede.EnMe == true)
        {
            camara.velocity = new Vector2(0f, 0f);
            camara.AddForce(transform.up * entroMede.VelocidadM);
        }


    }

}
