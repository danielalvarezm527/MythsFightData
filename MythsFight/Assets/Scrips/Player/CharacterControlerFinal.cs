    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class CharacterControlerFinal : MonoBehaviour
{
    public enum Character { Llorona, Sombreron, MadreAgua, Mohan }; // jugadores
    public bool P1 = true; // jugador 1
    bool P2 = false; // jugador 2
    Character character;
    Animator playerAnimator;
    public bool inAirControl, inGround;
    bool jump, caida,dash, golpeGas = false;
    public bool inAccion;

    Rigidbody2D characterRigidbody;
    float timer = 0;
    float holdtime = 0;
     
    public Collider2D colliderAtaque;
    public Collider2D colliderAtaqueLlorona;
    public GameObject []particles;
    public GameObject []Audios;
    public Slider vidaSlider, ultiSlider;

    float vida = 100, ulti = 0;
    
    public static float tiempofinal,monedas;

    void Start() // asiganacion del animator y el rigidbody
    {
        playerAnimator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody2D>();

        vidaSlider.maxValue = 100;
        ultiSlider.maxValue = 100;

        vidaSlider.value = vida;
        ultiSlider.value = ulti;
    }

    void FixedUpdate()
    {
        if(vida <= 0)
        {
            foreach(GameObject x in GameObject.FindGameObjectsWithTag("Jugador"))
            {
                if(x != this.gameObject)
                {
                    AudioManager.audioManager.nombre = x.name;
                }
            }

            SelectorPersonaje.selectorPersonaje.inGame = false; // bool falso para indicar que ya no se esta en juego
            SceneManager.LoadScene(2);
        }
        

        if (inAccion == false)
        {
            
            if (P1)
            {
                // condicionales de cada accion 

                if (Input.GetKeyDown(KeyCode.W))
                {
                    Jump();
                }

                if (Input.GetKey(KeyCode.A))
                {
                    Mover(-1);
                    playerAnimator.SetBool("Camina", true);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Mover(1);
                    playerAnimator.SetBool("Camina", true);
                }
                else
                {
                    Mover(0);
                    playerAnimator.SetBool("Camina", false);
                }

                if (Input.GetKeyDown(KeyCode.J) && dash)
                {
                    Dash();
                }

                if (Input.GetKeyDown(KeyCode.K) && !inAirControl && inGround && !playerAnimator.GetBool("Camina") && ultiSlider.value == 100)
                {
                    playerAnimator.SetTrigger("Ulti");
                    TakeUlti(-100);
                }

                if (Input.GetKey(KeyCode.G))
                {
                    holdtime += Time.deltaTime;
                }
                else if (Input.GetKeyUp(KeyCode.G))
                {
                    if (holdtime < .5f )
                    {
                        playerAnimator.SetTrigger("Ataque");
                    }
                    else if (holdtime > .5f)
                    {
                        playerAnimator.SetTrigger("AtaqueDistancia");
                    }
                }
                else
                {
                    holdtime = 0;
                }

                if (Input.GetKeyDown(KeyCode.H))
                {
                    playerAnimator.SetTrigger("EscudandoT");
                    playerAnimator.SetBool("Escudando", true);
                }
                else if (Input.GetKeyUp(KeyCode.H))
                {
                    playerAnimator.SetBool("Escudando", false);
                }
                
            }
            else
            {
                // condicionales de cada accion 

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Mover(-1);
                    playerAnimator.SetBool("Camina", true);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    Mover(1);
                    playerAnimator.SetBool("Camina", true);
                }
                else
                {
                    Mover(0);
                    playerAnimator.SetBool("Camina", false);
                }

                if (Input.GetKey(KeyCode.Keypad3) && dash)
                {
                    Dash();
                }

                if (Input.GetKey(KeyCode.Keypad5) && !inAirControl && inGround && !playerAnimator.GetBool("Camina") && ultiSlider.value == 100)
                {
                    playerAnimator.SetTrigger("Ulti");
                    TakeUlti(-100);

                }

                if (Input.GetKey(KeyCode.Keypad1))
                {
                    holdtime += Time.deltaTime;
                }
                else if (Input.GetKeyUp(KeyCode.Keypad1))
                {
                    if (holdtime < .5f)
                    {
                        playerAnimator.SetTrigger("Ataque");
                    }
                    else if (holdtime > .5f)
                    {
                        playerAnimator.SetTrigger("AtaqueDistancia");
                    }
                }
                else
                {
                    holdtime = 0;
                }

                if (Input.GetKey(KeyCode.Keypad2))
                {
                    playerAnimator.SetTrigger("EscudandoT");
                    playerAnimator.SetBool("Escudando", true);
                }
                else
                {
                    playerAnimator.SetBool("Escudando", false);
                }
            }
        }

        if (!golpeGas)
        {
            if (!playerAnimator.GetBool("Dash") && !jump && caida)
            {
                characterRigidbody.velocity = new Vector2(characterRigidbody.velocity.x, -5f / timer);
                timer -= Time.fixedDeltaTime;
                if (timer < .1f)
                {
                    timer = .1f;
                }
            }
            else if (jump)
            {
                timer += Time.fixedDeltaTime;
                characterRigidbody.velocity = new Vector2(characterRigidbody.velocity.x, 3.5f / timer);
                playerAnimator.SetBool("Salta", true);
                if (timer > 0.7f)
                {
                    jump = false;
                    caida = true;
                    playerAnimator.SetBool("Caida", true);
                }
            }

        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // "Amigos por simpre" collision con la nuve

        if (collision.gameObject.tag == "AmigosPorSiempre")
        {
            StartCoroutine(GolpeGas());
            SelectorPersonaje.selectorPersonaje.inGame = false;
            Analytics.CustomEvent("Gas");
            TomarDaño(20);
        }
        else if (collision.gameObject.tag == "Piso")
        {
            StopCoroutine(Dashear());
            timer = 0.7f;
            caida = true;
            jump = false;
            inAccion = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            
            playerAnimator.SetBool("Salta", false);
            playerAnimator.SetBool("Caida", false);
            playerAnimator.SetBool("Dash", false);
            inGround = true;
            dash = true;
            inAirControl = false;
            caida = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            if (!jump)
            {
                timer = 0.7f;
                caida = true;
                playerAnimator.SetBool("Caida", true);
            }
            else
            {
                playerAnimator.SetBool("Salta", true);
                playerAnimator.SetBool("Caida", false); 
                inGround = false;
                inAirControl = true;
            }
        }
    }

    void ADLlorona(int value)
    {
        if(value == 0)
            colliderAtaqueLlorona.enabled = false;
        else
            colliderAtaqueLlorona.enabled = true;

    }

    void ActualizarVida(int value)
    {
        vida += value;
        vidaSlider.value = vida;
        if(value < 0)
        {
            playerAnimator.SetTrigger("Daño");
        }
    }

    void AtaqueDis()
    {
        GameObject shot = Instantiate(SelectorPersonaje.selectorPersonaje.shotPref);
        shot.transform.position = new Vector2(this.transform.position.x + (10 * gameObject.transform.localScale.x), this.transform.position.y);
        shot.transform.localScale = transform.localScale*10;
    }

    void AtaqueIn()
    {
        colliderAtaque.enabled = true;
    }

    void AtaqueOff()
    {
        colliderAtaque.enabled = false;
    }

    public void TomarDaño(int value)
    {
        vida -= value;
        playerAnimator.SetBool("Atacado", true);
        vidaSlider.value = vida;
        CameraPos.needShake = true;
    }

    void UseUlti()
    {
        foreach(CharacterControlerFinal obj in FindObjectsOfType<CharacterControlerFinal>())
        {
            if(obj != this && obj.inGround)
            {
                obj.TomarDaño(20);
            }
        }
    }

    void Jump()
    {
        if (jump != true && !inAirControl && inGround)
        {
            jump = true;
            timer = Time.deltaTime;
            inAirControl = true;
        }
    }

    void Dash()
    {
        playerAnimator.SetTrigger("Dash");
        dash = false;
        inAccion = true;
        characterRigidbody.velocity = new Vector2(150 * transform.localScale.x, 3);
        StartCoroutine(Dashear());
    }

    IEnumerator GolpeGas()
    {
        golpeGas = true;
        float value = 40;
        while (value > 1)
        {
            value -= Time.deltaTime * 20;
            characterRigidbody.velocity = new Vector2(characterRigidbody.velocity.x, value);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        timer = 0.8f;
        golpeGas = false;
    }

    IEnumerator Dashear()
    {
        yield return new WaitForSeconds(.5f);
        timer = 0.7f;
        caida = true;
        jump = false;
        inAccion = false;
        yield return null;
    }

    void Mover(int direccion)
    {
        characterRigidbody.velocity = new Vector2(20 * direccion, characterRigidbody.velocity.y);
        if (direccion == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if(direccion < 0)
        {
            transform.localScale = new Vector3(-.2f, transform.localScale.y, transform.localScale.z);
        }
        else if (direccion > 0)
        {
            transform.localScale = new Vector3(.2f, transform.localScale.y, transform.localScale.z);
        }
    }

    void EjecutarParticula(int value)
    {
        particles[value].GetComponent<ParticleSystem>().Play();
    }


    void EjecutarAudio(int value)
    {
        Audios[value].GetComponent<AudioSource>().Play();
    }

    public void SetActiveFalse(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void TakeUlti(int value)
    {
        ulti += value;

        if (ulti > 100)
            ulti = 100;

        ultiSlider.value = ulti;
    }

    void Flipar()
    {
        StartCoroutine(InAccionCorrutine());
    }

    IEnumerator InAccionCorrutine()
    {
        inAccion = true;
        yield return new WaitForSeconds(0.5f);
        inAccion = false;
    }

}