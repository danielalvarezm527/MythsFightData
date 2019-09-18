using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

    public GameObject DontDestroy;

    public AudioMixer mixer;

    public Sound[] sounds;

    AudioSource Actualsound;

    public string tiempo = "2";
    public string nombre = "s";
    public int monedas = 4;

    void Awake()
	{
        DontDestroyOnLoad(DontDestroy);


        if (audioManager == null)
            audioManager = this;
        else
            Destroy(this.gameObject);

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = s.mixerGroup;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " Nombre no encontrado!");
			return;
        }

        if(Actualsound != null)
        {
            StartCoroutine(FadeOut(Actualsound));
            StartCoroutine(FadeIn(s.source));
            Actualsound = s.source;
        }
        else
        {
            StartCoroutine(FadeIn(s.source));
            Actualsound = s.source;
        }

    }

    public void EventTriger(string value)
    {
        Analytics.CustomEvent(value);
    }

    IEnumerator FadeIn(AudioSource audio)
    {
        float fade = 0f;
        audio.Play();
        while (fade <1)
        {
            audio.volume = fade;
            fade += Time.deltaTime / 3;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    IEnumerator FadeOut(AudioSource audio)
    {
        float fade = 1f;
        while (fade > 0)
        {
            audio.volume = fade;
            fade -= Time.deltaTime / 2;
            yield return new WaitForEndOfFrame();
        }
        audio.Stop();

        yield return null;
    }

}
