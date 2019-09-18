using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMusica : MonoBehaviour
{

    public bool mainMenu;

    void Start()
    {
        if (mainMenu)
        {
            AudioManager.audioManager.Play("menu");
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                AudioManager.audioManager.Play("batalla1");
            }
            else
            {
                AudioManager.audioManager.Play("batalla2");
            }
        }
    }
        
}
