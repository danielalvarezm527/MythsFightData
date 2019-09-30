using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManzanaFin : MonoBehaviour
{
    float tiempo;
    TextMeshProUGUI textoTiempo;

    private void Awake()
    {
        tiempo = 0;
        textoTiempo = GameObject.FindGameObjectWithTag("TextTiempo").GetComponent<TextMeshProUGUI>(); // asignacion del texto en la UI
    }


    private void FixedUpdate()
    {
        tiempo += Time.fixedDeltaTime; // contador de tiempo en partida 
        textoTiempo.text = tiempo.ToString("00");
        AudioManager.audioManager.tiempo = tiempo.ToString("00");
    }

    // cuando el jugador colisiona con la manzana se carga la scena final
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            AudioManager.audioManager.nombre = collision.gameObject.name;
            SelectorPersonaje.selectorPersonaje.inGame = false; // bool falso para indicar que ya no se esta en juego
            AudioManager.audioManager.EventTriger("Manzana");
            SceneManager.LoadScene(2);
        }
    }
}
