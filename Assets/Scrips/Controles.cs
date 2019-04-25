using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour {
    public float MovHOrizontal;
  
    [Header("animator")]
    public Animator PlayerMueve;
    public bool Salto;

    


    void Update()
    {
        MovHOrizontal = Input.GetAxis("Horizontal");

        if (MovHOrizontal < 0 || MovHOrizontal > 0)
        {
            //Caminar animation  on
            PlayerMueve.SetBool("Camina", true);

            /*if (MovHOrizontal < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (MovHOrizontal > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            } */
        }
        // caminar Animation off
        else
        {
            PlayerMueve.SetBool("Camina", false);
        }

        if (Input.GetButton("Jump"))
        {

            // Salto on
            PlayerMueve.SetBool("Salta", true);
        }
        else
        {
            //Salto off
            PlayerMueve.SetBool("Salta", false);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            // Ataque on
            PlayerMueve.SetBool("Ataque", true);

        }
        else
        {
            // Ataque off
            PlayerMueve.SetBool("Ataque", false);

        }

    }
}
