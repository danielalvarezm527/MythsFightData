using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Stats2 : MonoBehaviour
{

    public Rigidbody2D Rigidbody2Dp;
    public CameraPos CameraPos;
    public Slider Vida;

    public AudioSource coin;
    public AudioSource heal;
    public AudioSource daño;

    public float forces;
    public float life;
    public float Tiempo = 0;

    public static float tiempofinal;

    public static int Monedas = 0;

    public GameObject Jugador;

    public Text ElNombreDelJugador;
    public TextMeshProUGUI NumeroMonedas;
    public TextMeshProUGUI TiempoEnJuego;

    void Start()
    {
        Vida.maxValue = life;
        Monedas = 0;
    }

    void Update()
    {
        Tiempo += Time.fixedDeltaTime;

        ElNombreDelJugador.text = Edad.nombre;

        NumeroMonedas.text = Monedas.ToString();

        TiempoEnJuego.text = Tiempo.ToString();

        Vida.value = life;

        ElNombreDelJugador.transform.position = new Vector2(Jugador.transform.position.x, Jugador.transform.position.y + 2.5f);

        Vida.transform.position = new Vector2(Jugador.transform.position.x, Jugador.transform.position.y + 2f);

        if (life <= 0)
        {
            SceneManager.LoadScene(0);

        }

        if (life > 20)
        {
            life = 20;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Manzana")
        {
            SceneManager.LoadScene(2);
            tiempofinal = Tiempo;


        }

        if (collision.gameObject.tag == "Cura")
        {
            life += 2.5f;
            heal.Play();
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Moneda")
        {
            coin.Play();
            Destroy(collision.gameObject);
            Monedas += 1;

        }

        if (collision.gameObject.tag == "Multiplicador")
        {
            Destroy(collision.gameObject);
            Monedas = Monedas * 2;

        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AmigosPorSiempre")
        {
            daño.Play();
            life -= 5;
            Rigidbody2Dp.velocity = new Vector2(0, 0);
            Rigidbody2Dp.AddForce(transform.up * forces);
            CameraPos.Use = true;
        }
    }
}
