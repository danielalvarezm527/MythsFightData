using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ControlDeGrupos : MonoBehaviour
{

    public bool master, musica, sfx;

    private void Awake()
    {
        float value = 0f;
        if (master)
        {
            AudioManager.audioManager.mixer.GetFloat("master", out value);
            this.gameObject.GetComponent<Slider>().value = value;
        }
        else if (musica)
        {
            AudioManager.audioManager.mixer.GetFloat("Musica", out value);
            this.gameObject.GetComponent<Slider>().value = value;
        }
        else if(sfx)
        {
            AudioManager.audioManager.mixer.GetFloat("sfx", out value);
            this.gameObject.GetComponent<Slider>().value = value;
        }
    }

    public void OnValueChangeMaster(float value)
    {
        AudioManager.audioManager.mixer.SetFloat("master", value);
    }

    public void OnValueChangeMusica(float value)
    {
        AudioManager.audioManager.mixer.SetFloat("Musica", value);
    }
    
    public void OnValueChangeSFX(float value)
    {
        AudioManager.audioManager.mixer.SetFloat("sfx", value);
    }
}
