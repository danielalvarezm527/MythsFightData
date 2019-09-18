using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasGame : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoNombre;
    public TextMeshProUGUI textoTiempo;

    // asigancion de textos en la UI
    void Awake()
    {
        if(textoTiempo == null)
            textoTiempo = GameObject.FindGameObjectWithTag("TextTiempo").GetComponent<TextMeshProUGUI>();

        if (textoMonedas == null)
            textoMonedas = GameObject.FindGameObjectWithTag("TextMoneda").GetComponent<TextMeshProUGUI>();

        if (textoNombre == null)
            if(GameObject.FindGameObjectWithTag("TextNombre").GetComponent<TextMeshProUGUI>() != null)
                textoNombre = GameObject.FindGameObjectWithTag("TextNombre").GetComponent<TextMeshProUGUI>(); // asignacion del texto en la UI

            textoTiempo.text = AudioManager.audioManager.tiempo + "s";
            textoMonedas.text = AudioManager.audioManager.monedas.ToString();
            textoNombre.text = AudioManager.audioManager.nombre;
    }
}
