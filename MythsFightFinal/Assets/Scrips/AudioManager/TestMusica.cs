using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusica : MonoBehaviour
{
    public void Test(string name)
    {
        AudioManager.audioManager.Play(name);
    }
}
