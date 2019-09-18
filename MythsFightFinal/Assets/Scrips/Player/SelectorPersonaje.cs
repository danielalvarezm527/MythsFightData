using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine;
using TMPro;

public class SelectorPersonaje : MonoBehaviour
{
    public enum Character { Llorona, Sombreron, Madre_Agua, Mohan }; // Personajes
    public Sprite[] sprites = new Sprite[4]; // Array de personajes
    public Character character1,character2 = (Character)1;
    public static SelectorPersonaje selectorPersonaje;
    public GameObject dontDestroy;
    public GameObject shotPref;
    public GameObject [] charactersPrefabs = new GameObject[4]; // prefbs de los personajes
    public bool inGame = false; // verificador de "En juego"

    int change
    {
        get
        {
            return (int)character1;
        }
        set
        {
            character1 = (Character)value;
            GameObject[] spriteCharacter = GameObject.FindGameObjectsWithTag("CharacterSprite");
            UpdateSprite[] updateSprites = new UpdateSprite[spriteCharacter.Length];

            for (int i = 0; i < spriteCharacter.Length; i++)
            {
                updateSprites[i] = spriteCharacter[i].GetComponent<UpdateSprite>();

            }

            foreach (UpdateSprite x in updateSprites)
            {
                if (x.p1)
                {
                    x.change(value);
                    FindObjectOfType<TextCharacters>().t1.text = character1.ToString();
                }
            }


        }

    }


    int change2
    {
        get
        {
            return (int)character2;
        }
        set
        {
            character2 = (Character)value;
            GameObject[] spriteCharacter = GameObject.FindGameObjectsWithTag("CharacterSprite");
            UpdateSprite[] updateSprites = new UpdateSprite[spriteCharacter.Length];

            for (int i = 0; i < spriteCharacter.Length; i++)
            {
                updateSprites[i] = spriteCharacter[i].GetComponent<UpdateSprite>();

            }

            foreach (UpdateSprite x in updateSprites)
            {
                if (!x.p1)
                {
                    x.change(value);
                    FindObjectOfType<TextCharacters>().t2.text = character2.ToString();
                }
            }

            
        }

    }

    void Awake()
    {
        // singleton
        if (selectorPersonaje == null)
        {
            selectorPersonaje = this;
            DontDestroyOnLoad(dontDestroy);
        }
        else
            Destroy(this.gameObject);
    }

    /// <summary>
    /// cada personaje tiene un numero aignado
    /// </summary>
    /// <param name="value"> Retorna el numero del personaje seleccionado </param>
    public void ChangeCharacter(int value)
    {
        change = value;

    }


    public void ChangeCharacter2(int value)
    {
        change2 = value;

    }

}
