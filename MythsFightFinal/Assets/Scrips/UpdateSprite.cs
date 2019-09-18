using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    // actualizador de sprite del seleccion de personaje

    public bool p1;

    public void change(int value)
    {
        GetComponent<SpriteRenderer>().sprite = SelectorPersonaje.selectorPersonaje.sprites[value];
        GetComponent<Image>().sprite = SelectorPersonaje.selectorPersonaje.sprites[value];
    }

}
