using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeCharacterUI : MonoBehaviour
{

    public void Change(int value)
    {
        SelectorPersonaje.selectorPersonaje.ChangeCharacter(value);
    }

    public void Change2(int value)
    {
        SelectorPersonaje.selectorPersonaje.ChangeCharacter2(value);
    }
}
