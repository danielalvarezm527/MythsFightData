using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GetCharacter : MonoBehaviour
{

    int count = 0;

    void Awake()
    {
        // instancia en la scena de juego del personaje seleccionado
        count = 0;
        foreach (GameObject contenedor in GameObject.FindGameObjectsWithTag("Jugador2"))
        {
            if(SelectorPersonaje.selectorPersonaje.inGame == false)
            {
                if(count == 0)
                {
                    GameObject character = Instantiate(SelectorPersonaje.selectorPersonaje.charactersPrefabs[(int)SelectorPersonaje.selectorPersonaje.character1], contenedor.transform.position, contenedor.transform.rotation);
                    character.transform.localScale = new Vector3(0.2f, 0.2f, .2f);
                    character.name = "Player1";
                    Destroy(contenedor);
                    count++;
                }
                else
                {
                    GameObject character = Instantiate(SelectorPersonaje.selectorPersonaje.charactersPrefabs[(int)SelectorPersonaje.selectorPersonaje.character2], contenedor.transform.position, contenedor.transform.rotation);
                    SelectorPersonaje.selectorPersonaje.inGame = true;
                    character.GetComponent<CharacterControlerFinal>().P1 = false;
                    character.transform.localScale = new Vector3(0.2f, 0.2f, .2f);
                    character.name = "Player2";
                    Destroy(contenedor);
                }
            }
        }
    }
}