using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasFinal : MonoBehaviour {

    // Script del canvas 

    public TextMeshProUGUI ElTiempo;
    public TextMeshProUGUI LasMonedas;
	
	// asignacion del tiempo y la cantidad de monedas
	void Update () {

        ElTiempo.text = CharacterControlerFinal.tiempofinal.ToString();

        LasMonedas.text = CharacterControlerFinal.monedas.ToString();
        
	}
}
