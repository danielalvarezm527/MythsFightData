using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasFinal : MonoBehaviour {

    public TextMeshProUGUI ElTiempo;
    public TextMeshProUGUI LasMonedas;
    public TextMeshProUGUI ElNombre;

    public BotonPre BReiniciar;
	
	// Update is called once per frame
	void Update () {

        ElTiempo.text = Stats.tiempofinal.ToString();

        LasMonedas.text = Stats.Monedas.ToString();

        ElNombre.text = Edad.nombre;

        if (BReiniciar.isPressed)
        {
            SceneManager.LoadScene(0);

        }
	}
}
