using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    // Script encargado de la pantalla de carga del juego

    public GameObject loadingPanel;
    public Slider slider;
    public TextMeshProUGUI progressTx;

    public void startChange(int value) {
        Tally.monedas = 0;
        StartCoroutine(LoadAsinc(value));
    }

    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator LoadAsinc(int sIndex) {
        AsyncOperation asyncOP = SceneManager.LoadSceneAsync(sIndex);
        loadingPanel.SetActive(true);
        while (!asyncOP.isDone) {
            float progress = Mathf.Clamp01(asyncOP.progress / 0.9f);
            slider.value = progress;
            progressTx.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }

    }

}
