using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextoPC : MonoBehaviour
{
    public string[] unArrayDeStrins;
    TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        texto = this.gameObject.GetComponent<TextMeshProUGUI>();

        texto.text = unArrayDeStrins[Random.Range(0, 10)];
    }
}
