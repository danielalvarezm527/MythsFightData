using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QueEmpieceEljuego : MonoBehaviour {

    public BotonPre QueEmpieceElJuego;

	void Start () {
		
	}
	
	void Update () {

        if (QueEmpieceElJuego.isPressed)
        {
            SceneManager.LoadScene(1);

        }

	}

}
