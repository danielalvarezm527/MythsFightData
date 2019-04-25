using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class Edad : MonoBehaviour {

    [Header("Edad")]
    
    public BotonPre EdadMas;
    public BotonPre EdadMen;

    public TextMeshProUGUI SubeEdad;

    public static int edad = 0;

    [Header("Genero")]

    public Toggle Masculino;
    public Toggle Femenino;
    public Toggle Otro;

    public static string Genero;

    [Header("Nombre")]

    public Text Nombre;
    public Text CargaNombre;

    public static string nombre;

    [Header("Guardado Y Cargado")]

    public BotonPre Guardado;
    public BotonPre Cargado;

    void Update()
    {
        if (EdadMas.isPressed && Input.GetButtonDown("Fire1"))
        {
            edad += 1;

        }

        if (EdadMen.isPressed && Input.GetButtonDown("Fire1"))
        {
            edad -= 1;

        }

        else if (edad < 0)
        {
            edad = 0;
        }

        SubeEdad.text = edad.ToString();

        if (Masculino.isOn == true)
        {
            Genero = "Masculino";

        }

        if (Femenino.isOn == true)
        {
            Genero = "Femenino";

        }

        if (Otro.isOn == true)
        {
            Genero = "Otro";

        }

        nombre = Nombre.text;

        if (Guardado.isPressed == true)
        {
            Save();

        }

        if (Cargado.isPressed == true)
        {
            Load();

        }

    }

    public void Save()
    {
        BinaryFormatter binFor = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/info.dat");
        Keeper keeper = new Keeper();

        keeper.NombreJugador = nombre;
        keeper.EdadJugador = edad;
        keeper.GeneroJugador = Genero;

        binFor.Serialize(file, keeper);
        file.Close();

    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/info.dat"))
        {
            BinaryFormatter binFor = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/info.dat", FileMode.Open);
            Keeper keeper = (Keeper)binFor.Deserialize(file);
            file.Close();

            CargaNombre.text = keeper.NombreJugador;

            edad = keeper.EdadJugador;

            Genero = keeper.GeneroJugador;

            if (Genero == "Otro")
            {
                Otro.isOn = true;
            }

            if (Genero == "Masculino")
            {
                Masculino.isOn = true;
            }

            if (Genero == "Femenino")
            {
                Femenino.isOn = true;
            }

        }

    }

}

[Serializable]
class Keeper{

    public int EdadJugador;

    public string NombreJugador;
    public string GeneroJugador;

}
