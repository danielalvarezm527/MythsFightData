using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAtaqueScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Jugador")
        {
            collision.gameObject.GetComponent<CharacterControlerFinal>().TakeUlti(15);
            collision.gameObject.GetComponent<CharacterControlerFinal>().TomarDaño(5);
            gameObject.GetComponentInParent<CharacterControlerFinal>().TakeUlti(10);

        }
    }
}
